using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCapFrontend {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            Enabled = false;
            chkImmediate.Checked = true;
            ddlPreset.SelectedIndex = ddlPreset.Items.IndexOf("slow");

            txtOutputDir.Text = Environment.CurrentDirectory;
            txtFilename.Text = DateTime.UtcNow.ToString("u").Replace(':', '-').Replace(' ', '_');

            foreach (string path in new[] {
                Environment.CurrentDirectory,
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            }.Concat(Environment.GetEnvironmentVariable("PATH").Split(Path.PathSeparator))) {
                string p = path;
                while (p.EndsWith("\"")) {
                    p = path.Substring(0, path.Length - 1);
                }
                string f = Path.Combine(p, "ffmpeg.exe");
                if (File.Exists(f)) {
                    lblFfmpegPath2.Text = f;
                    Enabled = true;
                    break;
                }   
            }
        }

        private void chkImmediate_CheckedChanged(object sender, EventArgs e) {
            dtStartTime.Enabled = !chkImmediate.Checked;
        }

        private async void btnStart_Click(object sender, EventArgs e) {
            Enabled = false;

            try {
                DateTime startTime = DateTime.Today + dtStartTime.Value.TimeOfDay;
                if (startTime < DateTime.Now) startTime += TimeSpan.FromDays(1);
                if (chkImmediate.Checked) startTime = DateTime.Now;

                string filename = txtFilename.Text;
                if (!filename.EndsWith(".mp4", StringComparison.CurrentCultureIgnoreCase)) {
                    filename += ".mp4";
                }
                string filepath = Path.Combine(txtOutputDir.Text, filename);

                string audio = null;
                string video = null;

                var psi1 = new ProcessStartInfo(lblFfmpegPath2.Text, $"-f dshow -list_devices true -i dummy") {
                    UseShellExecute = false,
                    RedirectStandardError = true
                };
                var p1 = Process.Start(psi1);
                await Task.Run(() => {
                    using (var sr = p1.StandardError) {
                        string line;
                        string mode = null;
                        while ((line = sr.ReadLine()) != null) {
                            if (line.Contains("DirectShow video devices")) {
                                mode = "video";
                            } else if (line.Contains("DirectShow audio devices")) {
                                mode = "audio";
                            } else if (line.Contains("USB Video Device") || line.Contains("USB Audio Device")) {
                                line = line.Substring(line.IndexOf('"') + 1);
                                line = line.Substring(0, line.LastIndexOf('"'));
                                if (line.Length > 0) {
                                    Console.WriteLine(line);
                                    if (mode == "video") video = line;
                                    if (mode == "audio") audio = line;
                                }
                            }
                        }
                    }
                    p1.WaitForExit();
                });

                var psi2 = new ProcessStartInfo(
                    lblFfmpegPath2.Text,
                    $"-t {numDuration.Value * 60} -f dshow -video_size 720x240 -framerate 30 " +
                    $"-pixel_format yuyv422 -i video=\"{video}\":audio=\"{audio}\" " +
                    $"-f mp4 -pix_fmt yuv420p -s 720x540 -c:v libx264 -preset {ddlPreset.Text} -crf {(int)numCrf.Value} -c:a libmp3lame -qscale:a 0 " +
                    $"\"{filepath}\""
                ) {
                    UseShellExecute = false,
                    RedirectStandardError = true
                };

                var ts = startTime - DateTime.Now;
                if (ts < TimeSpan.Zero) ts = TimeSpan.Zero;

                await Task.Delay(ts);

                if (File.Exists(filepath)) File.Delete(filepath);

                var p2 = Process.Start(psi2);
                await Task.Run(() => {
                    using (var sr = p2.StandardError) {
                        string line;
                        while ((line = sr.ReadLine()) != null) {
                            Console.Error.WriteLine(line);
                        }
                    }
                    p2.WaitForExit();
                });
            } catch (Exception ex) {
                Console.Error.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show(this, ex.Message);
            }

            Enabled = true;
        }
    }
}

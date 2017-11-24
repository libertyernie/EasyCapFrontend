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
        private static string INPUT_OPTIONS = "-framerate 30 -video_size 720x240 -pixel_format yuyv422";
        private Process ffmpeg = null;

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

            FillDevices();
        }

        private async void FillDevices() {
            try {
                var psi1 = new ProcessStartInfo(lblFfmpegPath2.Text, $"-f dshow -list_devices true -i dummy") {
                    UseShellExecute = false,
                    RedirectStandardError = true
                };
                var p1 = Process.Start(psi1);
                using (var sr = p1.StandardError) {
                    string line;
                    string mode = null;
                    while ((line = await sr.ReadLineAsync()) != null) {
                        if (line.Contains("DirectShow video devices")) {
                            mode = "video";
                        } else if (line.Contains("DirectShow audio devices")) {
                            mode = "audio";
                        } else if (mode != null && line.Where(c => c == '"').Count() >= 2) {
                            line = line.Substring(line.IndexOf('"') + 1);
                            line = line.Substring(0, line.LastIndexOf('"'));
                            if (line.Length > 0) {
                                if (mode == "audio") {
                                    ddlAudio.Items.Add(line);
                                    if (line.Contains("USB Audio Device")) {
                                        ddlAudio.SelectedIndex = ddlAudio.Items.Count - 1;
                                    }
                                }
                                if (mode == "video") {
                                    ddlVideo.Items.Add(line);
                                    if (line.Contains("USB Video Device")) {
                                        ddlVideo.SelectedIndex = ddlVideo.Items.Count - 1;
                                    }
                                }
                            }
                        }
                    }
                }
                p1.WaitForExit();
            } catch (Exception e) {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
                MessageBox.Show(this, e.Message, e.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkImmediate_CheckedChanged(object sender, EventArgs e) {
            dtStartTime.Enabled = !chkImmediate.Checked;
        }

        private async void btnStart_Click(object sender, EventArgs e) {
            btnStart.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            textBox1.Clear();

            try {
                DateTime startTime = DateTime.Today + dtStartTime.Value.TimeOfDay;
                if (startTime < DateTime.Now) startTime += TimeSpan.FromDays(1);
                if (chkImmediate.Checked) startTime = DateTime.Now;

                string filename = txtFilename.Text;
                if (!filename.EndsWith(".mp4", StringComparison.CurrentCultureIgnoreCase)) {
                    filename += ".mp4";
                }
                string filepath = Path.Combine(txtOutputDir.Text, filename);
                if (File.Exists(filepath)) {
                    throw new Exception("File already exists: " + filepath);
                }

                decimal seconds = numDuration.Value * 60;
                progressBar1.Maximum = (int)(seconds * 1000);

                string audio = ddlAudio.SelectedItem?.ToString();
                string video = ddlVideo.SelectedItem?.ToString();
                if (audio == null || video == null) {
                    MessageBox.Show(this, "You must select both audio and video inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    int exitCode = await RunEncoder(startTime, seconds, INPUT_OPTIONS, video, audio, filepath);
                    if (exitCode == 1) {
                        await RunEncoder(startTime, seconds, "", video, audio, filepath);
                    }
                }
            } catch (Exception ex) {
                Console.Error.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show(this, ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnStop.Enabled = false;
            btnStart.Enabled = true;
            progressBar1.Visible = false;
        }

        private async Task<int> RunEncoder(DateTime startTime, decimal seconds, string input_options, string video, string audio, string filepath) {
            var psi2 = new ProcessStartInfo(
                        lblFfmpegPath2.Text,
                        $"-t {seconds} -f dshow " +
                        $"{input_options} " +
                        $"-i video=\"{video}\":audio=\"{audio}\" " +
                        $"-f mp4 -pix_fmt yuv420p -s 720x540 -c:v libx264 -preset {ddlPreset.Text} -crf {(int)numCrf.Value} -c:a libmp3lame -qscale:a 0 " +
                        $"\"{filepath}\""
                    ) {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = true
            };

            var ts = startTime - DateTime.Now;
            if (ts < TimeSpan.Zero) ts = TimeSpan.Zero;

            await Task.Delay(ts);

            if (File.Exists(filepath)) File.Delete(filepath);

            btnStop.Enabled = true;
            var p2 = ffmpeg = Process.Start(psi2);
            using (var sr = p2.StandardError) {
                string line;
                while ((line = await sr.ReadLineAsync()) != null) {
                    if (line.Contains("time=")) {
                        string time = line.Substring(line.IndexOf("time=") + 5, 11);
                        if (TimeSpan.TryParse(time, out TimeSpan result)) {
                            progressBar1.Value = Math.Min(progressBar1.Maximum, (int)result.TotalMilliseconds);
                        }
                    } else {
                        textBox1.AppendText(line + Environment.NewLine);
                    }
                }
            }
            p2.WaitForExit();
            ffmpeg = null;

            return p2.ExitCode;
        }

        private void btnStop_Click(object sender, EventArgs e) {
            ffmpeg?.StandardInput?.WriteLine("q");
        }
    }
}

﻿using System;
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
            
            chkImmediate.Checked = true;
            ddlPreset.SelectedIndex = ddlPreset.Items.IndexOf("slow");

            txtOutputDir.Text = Environment.CurrentDirectory;
            txtFilename.Text = DateTime.UtcNow.ToString("u").Replace(':', '-').Replace(' ', '_');

            FillDevices();
        }

        private async void FillDevices() {
            try {
                var psi1 = new ProcessStartInfo("ffmpeg", $"-f dshow -list_devices true -i dummy") {
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
            btnStart.Enabled = btnPreview.Enabled = false;
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

            btnStart.Enabled = btnPreview.Enabled = true;
            progressBar1.Visible = false;
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            textBox1.Clear();

            string audio = ddlAudio.SelectedItem?.ToString();
            string video = ddlVideo.SelectedItem?.ToString();
            string args = $"-f dshow " +
                $"{INPUT_OPTIONS} " +
                $"-i video=\"{video}\":audio=\"{audio}\" " +
                $"-vf scale=720x540";
            
            textBox1.AppendText("ffplay " + args);

            var psi2 = new ProcessStartInfo("ffplay", args);

            Process.Start(psi2);
        }

        private async Task<int> RunEncoder(DateTime startTime, decimal seconds, string input_options, string video, string audio, string filepath) {
            string args = $"-t {seconds} -f dshow " +
                $"{input_options} " +
                $"-i video=\"{video}\":audio=\"{audio}\" " +
                $"-f mp4 -pix_fmt yuv420p -s 720x540 -c:v libx264 -preset {ddlPreset.Text} -crf {(int)numCrf.Value} -c:a libmp3lame -qscale:a 0 " +
                $"\"{filepath}\"";

            textBox1.AppendText("----------------------------------------");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("ffmpeg " + args);
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("----------------------------------------");
            textBox1.AppendText(Environment.NewLine);

            var psi2 = new ProcessStartInfo("ffmpeg", args) {
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
            btnStop.Enabled = false;
            ffmpeg = null;

            return p2.ExitCode;
        }

        private void btnStop_Click(object sender, EventArgs e) {
            ffmpeg?.StandardInput?.WriteLine("q");
        }

        private void btnOpenDir_Click(object sender, EventArgs e) {
            if (Directory.Exists(txtOutputDir.Text)) {
                Process.Start(txtOutputDir.Text);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(linkLabel1.Text);
        }
    }
}

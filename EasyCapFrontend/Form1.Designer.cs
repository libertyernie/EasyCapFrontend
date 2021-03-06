﻿namespace EasyCapFrontend {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblStartTime = new System.Windows.Forms.Label();
            this.chkImmediate = new System.Windows.Forms.CheckBox();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ddlTune = new System.Windows.Forms.ComboBox();
            this.lblTune = new System.Windows.Forms.Label();
            this.ddlPreset = new System.Windows.Forms.ComboBox();
            this.lblPreset = new System.Windows.Forms.Label();
            this.numCrf = new System.Windows.Forms.NumericUpDown();
            this.lblCRF = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ddlAudio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlVideo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrf)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(6, 22);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(3);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(54, 13);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "Start time:";
            // 
            // chkImmediate
            // 
            this.chkImmediate.AutoSize = true;
            this.chkImmediate.Location = new System.Drawing.Point(66, 21);
            this.chkImmediate.Name = "chkImmediate";
            this.chkImmediate.Size = new System.Drawing.Size(79, 17);
            this.chkImmediate.TabIndex = 3;
            this.chkImmediate.Text = "Immedately";
            this.chkImmediate.UseVisualStyleBackColor = true;
            this.chkImmediate.CheckedChanged += new System.EventHandler(this.chkImmediate_CheckedChanged);
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(151, 19);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(103, 20);
            this.dtStartTime.TabIndex = 4;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(6, 49);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(3);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "Duration:";
            // 
            // numDuration
            // 
            this.numDuration.DecimalPlaces = 2;
            this.numDuration.Location = new System.Drawing.Point(66, 47);
            this.numDuration.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(60, 20);
            this.numDuration.TabIndex = 6;
            this.numDuration.ThousandsSeparator = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblStartTime);
            this.groupBox1.Controls.Add(this.numDuration);
            this.groupBox1.Controls.Add(this.chkImmediate);
            this.groupBox1.Controls.Add(this.lblDuration);
            this.groupBox1.Controls.Add(this.dtStartTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scheduling";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "minutes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlTune);
            this.groupBox3.Controls.Add(this.lblTune);
            this.groupBox3.Controls.Add(this.ddlPreset);
            this.groupBox3.Controls.Add(this.lblPreset);
            this.groupBox3.Controls.Add(this.numCrf);
            this.groupBox3.Controls.Add(this.lblCRF);
            this.groupBox3.Location = new System.Drawing.Point(12, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 73);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encoding";
            // 
            // ddlTune
            // 
            this.ddlTune.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTune.FormattingEnabled = true;
            this.ddlTune.Items.AddRange(new object[] {
            "",
            "film",
            "animation",
            "grain",
            "stillimage",
            "fastdecode",
            "zerolatency"});
            this.ddlTune.Location = new System.Drawing.Point(93, 46);
            this.ddlTune.Name = "ddlTune";
            this.ddlTune.Size = new System.Drawing.Size(161, 21);
            this.ddlTune.TabIndex = 5;
            // 
            // lblTune
            // 
            this.lblTune.AutoSize = true;
            this.lblTune.Location = new System.Drawing.Point(6, 49);
            this.lblTune.Name = "lblTune";
            this.lblTune.Size = new System.Drawing.Size(81, 13);
            this.lblTune.TabIndex = 4;
            this.lblTune.Text = "Tune (optional):";
            // 
            // ddlPreset
            // 
            this.ddlPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPreset.FormattingEnabled = true;
            this.ddlPreset.Items.AddRange(new object[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow"});
            this.ddlPreset.Location = new System.Drawing.Point(154, 19);
            this.ddlPreset.Name = "ddlPreset";
            this.ddlPreset.Size = new System.Drawing.Size(100, 21);
            this.ddlPreset.TabIndex = 3;
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.Location = new System.Drawing.Point(109, 22);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(40, 13);
            this.lblPreset.TabIndex = 2;
            this.lblPreset.Text = "Preset:";
            // 
            // numCrf
            // 
            this.numCrf.Location = new System.Drawing.Point(43, 19);
            this.numCrf.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.numCrf.Name = "numCrf";
            this.numCrf.Size = new System.Drawing.Size(60, 20);
            this.numCrf.TabIndex = 1;
            this.numCrf.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lblCRF
            // 
            this.lblCRF.AutoSize = true;
            this.lblCRF.Location = new System.Drawing.Point(6, 22);
            this.lblCRF.Name = "lblCRF";
            this.lblCRF.Size = new System.Drawing.Size(31, 13);
            this.lblCRF.TabIndex = 0;
            this.lblCRF.Text = "CRF:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(463, 276);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOpenDir);
            this.groupBox2.Controls.Add(this.txtFilename);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtOutputDir);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(278, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 71);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDir.Location = new System.Drawing.Point(234, 19);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(20, 20);
            this.btnOpenDir.TabIndex = 4;
            this.btnOpenDir.Text = "↗";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(64, 45);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(190, 20);
            this.txtFilename.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filename:";
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDir.Location = new System.Drawing.Point(64, 19);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(164, 20);
            this.txtOutputDir.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Directory:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.ddlAudio);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.ddlVideo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(278, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 73);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input";
            // 
            // ddlAudio
            // 
            this.ddlAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAudio.FormattingEnabled = true;
            this.ddlAudio.Location = new System.Drawing.Point(49, 46);
            this.ddlAudio.Name = "ddlAudio";
            this.ddlAudio.Size = new System.Drawing.Size(205, 21);
            this.ddlAudio.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Audio:";
            // 
            // ddlVideo
            // 
            this.ddlVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlVideo.FormattingEnabled = true;
            this.ddlVideo.Location = new System.Drawing.Point(49, 19);
            this.ddlVideo.Name = "ddlVideo";
            this.ddlVideo.Size = new System.Drawing.Size(205, 21);
            this.ddlVideo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Video:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 168);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(526, 102);
            this.textBox1.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 276);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(382, 276);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(18, 281);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(239, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/libertyernie/EasyCapFrontend";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(301, 276);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 311);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel1);
            this.Name = "Form1";
            this.Text = "EasyCap Frontend";
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrf)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.CheckBox chkImmediate;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCRF;
        private System.Windows.Forms.NumericUpDown numCrf;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.ComboBox ddlPreset;
        private System.Windows.Forms.ComboBox ddlTune;
        private System.Windows.Forms.Label lblTune;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox ddlAudio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlVideo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnPreview;
    }
}


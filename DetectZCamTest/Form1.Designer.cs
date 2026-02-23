namespace DetectZCamTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpBoxVideo = new GroupBox();
            groupBox1 = new GroupBox();
            grpBoxCameras = new GroupBox();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxVideo
            // 
            grpBoxVideo.Dock = DockStyle.Right;
            grpBoxVideo.Location = new Point(550, 0);
            grpBoxVideo.Name = "grpBoxVideo";
            grpBoxVideo.Size = new Size(250, 450);
            grpBoxVideo.TabIndex = 0;
            grpBoxVideo.TabStop = false;
            grpBoxVideo.Text = "groupBox1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 325);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(550, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // grpBoxCameras
            // 
            grpBoxCameras.Dock = DockStyle.Fill;
            grpBoxCameras.Location = new Point(0, 0);
            grpBoxCameras.Name = "grpBoxCameras";
            grpBoxCameras.Size = new Size(550, 325);
            grpBoxCameras.TabIndex = 2;
            grpBoxCameras.TabStop = false;
            grpBoxCameras.Text = "groupBox2";
            // 
            // button1
            // 
            button1.Location = new Point(71, 25);
            button1.Name = "button1";
            button1.Size = new Size(133, 29);
            button1.TabIndex = 0;
            button1.Text = "Scan Cameras";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Scan_OnClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(grpBoxCameras);
            Controls.Add(groupBox1);
            Controls.Add(grpBoxVideo);
            Name = "Form1";
            Text = "Form1";
            Load += MainUI_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxVideo;
        private GroupBox groupBox1;
        private GroupBox grpBoxCameras;
        private Button button1;
    }
}

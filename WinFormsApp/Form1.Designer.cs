namespace WinFormsApp
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
            brightnessTrackBar = new TrackBar();
            brightnessLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).BeginInit();
            SuspendLayout();
            // 
            // brightnessTrackBar
            // 
            brightnessTrackBar.Location = new Point(10, 10);
            brightnessTrackBar.Maximum = BrightnessControl.SizeConstNum;
            brightnessTrackBar.Minimum = 50;
            brightnessTrackBar.Name = "brightnessTrackBar";
            brightnessTrackBar.Size = new Size(500, 50);
            brightnessTrackBar.TabIndex = 0;
            brightnessTrackBar.Value = 50;
            brightnessTrackBar.Scroll += brightnessTrackBar_Scroll;
            // 
            // brightnessLabel
            // 
            brightnessLabel.AutoSize = true;
            brightnessLabel.Font = new Font("Yu Gothic UI", 28F, FontStyle.Regular, GraphicsUnit.Point, 128);
            brightnessLabel.Location = new Point(520, 0);
            brightnessLabel.Name = "brightnessLabel";
            brightnessLabel.Size = new Size(200, 100);
            brightnessLabel.TabIndex = 1;
            brightnessLabel.Text = "255";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(822, 124);
            Controls.Add(brightnessLabel);
            Controls.Add(brightnessTrackBar);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar brightnessTrackBar;
        private Label brightnessLabel;
    }
}

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void AddBrightnessTrackBar()
        {
            TrackBar trackBar = new TrackBar();

            brightnessTrackBar.Location = new Point(10, 10);
            brightnessTrackBar.Maximum = BrightnessControl.SizeConstNum;
            brightnessTrackBar.Minimum = 50;
            brightnessTrackBar.Name = "brightnessTrackBar";
            brightnessTrackBar.Size = new Size(500, 50);
            brightnessTrackBar.TabIndex = 0;
            brightnessTrackBar.Value = 50;
            brightnessTrackBar.Scroll += brightnessTrackBar_Scroll;
            Controls.Add(brightnessTrackBar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var workingArea = Screen.PrimaryScreen.WorkingArea;

            // �t�H�[���̈ʒu����ʉ����ɐݒ�
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                (workingArea.Width - this.Width) / 2,   // ���͒����ɔz�u
                workingArea.Bottom - this.Height - 100       // �c�͉��ɔz�u
            );

            SetBrightness(200);
        }

        private void SetBrightness(int brightness)
        {
            BrightnessControl.SetBrightness(brightness);
            brightnessLabel.Text = brightness.ToString();
            if (brightness != brightnessTrackBar.Value)
            {
                brightnessTrackBar.Value = brightness;
            }
        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            SetBrightness(brightnessTrackBar.Value);
        }
    }
}

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        readonly TrackBar brightnessTrackBar;
        readonly Label brightnessLabel;

        public Form1()
        {
            InitializeComponent();

            brightnessTrackBar = CreateAndAddControl(    BrightnessTrackBar.Make(SetBrightness)    );
            brightnessLabel = CreateAndAddControl(BrightnessLabel.Make());
        }

        private T CreateAndAddControl<T>(T control) where T : Control
        {
            Controls.Add(control);
            return control;
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

        private void brightnessTrackBar_Scroll(object? sender, EventArgs e)
        {
            SetBrightness(brightnessTrackBar.Value);
        }
    }
}

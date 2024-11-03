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

            // フォームの位置を画面下部に設定
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                (workingArea.Width - this.Width) / 2,   // 横は中央に配置
                workingArea.Bottom - this.Height - 100       // 縦は下に配置
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

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var trackBarLabel = new TrackBarLabel {
                
            };
            Controls.Add(trackBarLabel);
        }

        private T CreateAndAddControl<T>(T control) where T : Control
        {
            Controls.Add(control);
            return control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var maxBottom = 0;
            var maxRight = 0;
            foreach (var control in Controls)
            {
                if (control == null) continue;
                if (control is Control)
                {
                    maxBottom = ((Control)control).Bottom;
                    maxRight = ((Control)control).Right;
                }
            }
            var margin = 30;
            Height = maxBottom + margin;
            Width = maxRight + margin;

            if (Screen.PrimaryScreen != null)
            {
                var workingArea = Screen.PrimaryScreen.WorkingArea;

                // フォームの位置を画面下部に設定
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(
                    (workingArea.Width - this.Width) / 2,   // 横は中央に配置
                    workingArea.Bottom - this.Height - 70       // 縦は下に配置
                );
            }

            //SetBrightness(200);
        }
    }
}

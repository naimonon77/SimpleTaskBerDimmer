using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class TrackBarLabel : UserControl
    {
        public TrackBarLabel()
        {
            InitializeComponent();

            brightnessTrackBar = CreateAndAddControl(BrightnessTrackBar.Make(SetBrightness));
            brightnessLabel = CreateAndAddControl(BrightnessLabel.Make());
            SetBrightness(200);
        }

        readonly TrackBar brightnessTrackBar;
        readonly Label brightnessLabel;

        private T CreateAndAddControl<T>(T control) where T : Control
        {
            Controls.Add(control);
            return control;
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

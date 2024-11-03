using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public partial class BrightnessTrackBar
    {
        public static TrackBar Make(Action<int> SetBrightness)
        {
            var brightnessTrackBar_ = new TrackBar
            {
                Location = new Point(10, 10),
                Maximum = BrightnessControl.SizeConstNum,
                Minimum = 50,
                Name = "brightnessTrackBar_",
                Size = new Size(500, 50),
                TabIndex = 0,
                Value = 50,
            };

            brightnessTrackBar_.Scroll += (object? sender, EventArgs e) =>
            {
                SetBrightness(brightnessTrackBar_.Value);
            };
            return brightnessTrackBar_;
        }
    }
}

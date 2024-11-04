using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public partial class BrightnessTrackBar
    {
        const int LocationX = 10;
        const int LocationY = 20;
        const int Width = 500;
        public const int Height = 30;
        public const int Right = LocationX + Width;
        public const int Bottom = LocationY + Height;

        public static TrackBar Make(Action<int> SetBrightness)
        {
            var brightnessTrackBar_ = new TrackBar
            {
                Location = new Point(LocationX, LocationY),
                Maximum = BrightnessControl.SizeConstNum,
                Minimum = 50,
                Name = "brightnessTrackBar_",
                Width = Width,
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

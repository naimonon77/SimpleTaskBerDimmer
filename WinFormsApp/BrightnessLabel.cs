using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    class CutomControl : Control
    {

    }

    internal class BrightnessLabel
    {
        public static Label Make()
        {
            var brightnessLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Yu Gothic UI", 28F, FontStyle.Regular, GraphicsUnit.Point, 128),
                Location = new Point(BrightnessTrackBar.Right, 0),
                Margin = new Padding(4, 0, 4, 0),
                Name = "brightnessLabel",
                Size = new Size(145, 88),
                TabIndex = 1,
                Text = "255",
            };
            return brightnessLabel;
        }
    }
}

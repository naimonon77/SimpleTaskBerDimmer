using System;
using System.Runtime.InteropServices;

class BrightnessControl
{
    // SetDeviceGammaRampを呼び出すためのP/Invoke宣言
    [DllImport("gdi32.dll")]
    private static extern bool SetDeviceGammaRamp(IntPtr hdc, ref RAMP lpRamp);

    // GetDCを呼び出すためのP/Invoke宣言
    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hWnd);

    // ReleaseDCを呼び出すためのP/Invoke宣言
    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    // ガンマランプ構造体
    private struct RAMP
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public ushort[] Red;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public ushort[] Green;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public ushort[] Blue;
    }

    // 明るさを設定する関数
    public static bool SetBrightness(int brightness)
    {
        if (brightness < 0 || brightness > 100)
        {
            Console.WriteLine("Brightness must be between 0 and 100.");
            return false;
        }

        // ガンマランプの生成
        RAMP gammaRamp = new RAMP
        {
            Red = new ushort[256],
            Green = new ushort[256],
            Blue = new ushort[256]
        };

        for (int i = 0; i < 256; i++)
        {
            int value = i * (brightness + 128) / 256;
            if (value > 255) value = 255;

            gammaRamp.Red[i] = gammaRamp.Green[i] = gammaRamp.Blue[i] = (ushort)(value << 8);
        }

        // ディスプレイのデバイスコンテキストを取得
        IntPtr hdc = GetDC(IntPtr.Zero);
        if (hdc == IntPtr.Zero)
        {
            Console.WriteLine("Failed to get device context.");
            return false;
        }

        // ガンマランプを設定
        bool result = SetDeviceGammaRamp(hdc, ref gammaRamp);

        // リソースの解放
        ReleaseDC(IntPtr.Zero, hdc);

        if (!result)
        {
            Console.WriteLine("Failed to set brightness.");
        }

        return result;
    }

}

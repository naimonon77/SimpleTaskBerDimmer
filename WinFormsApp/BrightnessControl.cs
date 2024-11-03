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

    public const int SizeConstNum = 256;

    // ガンマランプ構造体
    private struct RAMP
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SizeConstNum)]
        public ushort[] Red;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SizeConstNum)]
        public ushort[] Green;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SizeConstNum)]
        public ushort[] Blue;
    }

    // 明るさを設定する関数
    public static bool SetBrightness(int brightness)
    {
        if (brightness < 0 || brightness > SizeConstNum)
        {
            Console.WriteLine("Brightness must be between 0 and 100.");
            return false;
        }

        // ガンマランプの生成
        RAMP gammaRamp = new RAMP
        {
            Red = new ushort[SizeConstNum],
            Green = new ushort[SizeConstNum],
            Blue = new ushort[SizeConstNum]
        };

        for (int i = 0; i < SizeConstNum; i++)
        {
            int value = Math.Min(SizeConstNum - 1, i * brightness / SizeConstNum);
            //if (value > SizeConstNum - 1) value = SizeConstNum - 1;

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

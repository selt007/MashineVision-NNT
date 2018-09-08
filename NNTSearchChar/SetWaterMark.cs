﻿#region
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion
/// <summary>
/// Change namespace !!!
/// </summary>
namespace NNTSearchChar
{
    public static class TextBoxWatermarkExtensionMethod
    {
        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)] private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public static void SetWatermark(this TextBox textBox, string watermarkText)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }
    }
}
/// <summary>
/// Использование textBox.SetWatermark("Same text");
/// </summary>
internal class WatermarkTextBox : TextBox
{
    private const uint ECM_FIRST = 0x1500;
    private const uint EM_SETCUEBANNER = ECM_FIRST + 1;
    private string watermarkText;
    public string WatermarkText
    {
        get { return watermarkText; }
        set
        {
            watermarkText = value;
            SetWatermark(watermarkText);
        }
    }
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)] private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    private void SetWatermark(string watermarkText)
    {
        SendMessage(Handle, EM_SETCUEBANNER, 0, watermarkText);
    }
}
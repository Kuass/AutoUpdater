using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoUpdater
{
    static class Program
    {
        public static readonly Main theMainForm = new Main();
        public static readonly Setting theSettingForm = new Setting();

        [DllImport("coredll.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("coredll.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        static void DisableAnimation(Form form)
        {
            const int WS_EX_NOANIMATION = 0x04000000;
            const int GWL_EX_STYLE = -20;

            int style = GetWindowLong(form.Handle, GWL_EX_STYLE);
            style |= WS_EX_NOANIMATION;
            SetWindowLong(form.Handle, GWL_EX_STYLE, style);
        }

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            DisableAnimation(theMainForm);
            DisableAnimation(theSettingForm);

            Application.Run(theMainForm);
        }
    }
}
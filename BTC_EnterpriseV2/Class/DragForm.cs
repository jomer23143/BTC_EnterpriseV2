using System.Runtime.InteropServices;

namespace BTCP_EnterpriseV2.Class
{
    internal class DragForm
    {
        #region Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
    }
}

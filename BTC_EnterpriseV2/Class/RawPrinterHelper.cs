using System.Runtime.InteropServices;

namespace BTC_EnterpriseV2.Class
{
    public partial class RawPrinterHelper
    {
        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
        public static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] ref DOCINFOA di);


        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        public static bool SendStringToPrinter(string printerName, string zpl)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(zpl);
            int dwCount = bytes.Length;
            IntPtr pBytes = Marshal.AllocCoTaskMem(dwCount);
            Marshal.Copy(bytes, 0, pBytes, dwCount);
            bool success = false;
            IntPtr hPrinter = IntPtr.Zero;

            try
            {
                if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                {
                    int error = Marshal.GetLastWin32Error();
                    MessageBox.Show($"Failed to open printer. Error code: {error}");
                    return false;
                }

                DOCINFOA di = new DOCINFOA
                {
                    pDocName = "ZPL Print Job",
                    pOutputFile = null,
                    pDatatype = "RAW"
                };

                if (!StartDocPrinter(hPrinter, 1, ref di))
                {
                    int error = Marshal.GetLastWin32Error();
                    MessageBox.Show($"Failed to start document. Error code: {error}");
                    return false;
                }

                if (!StartPagePrinter(hPrinter))
                {
                    int error = Marshal.GetLastWin32Error();
                    MessageBox.Show($"Failed to start page. Error code: {error}");
                    return false;
                }

                int dwWritten = 0;
                if (!WritePrinter(hPrinter, pBytes, dwCount, out dwWritten))
                {
                    int error = Marshal.GetLastWin32Error();
                    MessageBox.Show($"Failed to write to printer. Error code: {error}");
                    return false;
                }

                if (!EndPagePrinter(hPrinter))
                {
                    int error = Marshal.GetLastWin32Error();
                    MessageBox.Show($"Failed to end page. Error code: {error}");
                    return false;
                }

                if (!EndDocPrinter(hPrinter))
                {
                    int error = Marshal.GetLastWin32Error();
                    MessageBox.Show($"Failed to end document. Error code: {error}");
                    return false;
                }

                success = true;
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                {
                    ClosePrinter(hPrinter);
                }
                Marshal.FreeCoTaskMem(pBytes);
            }

            return success;
        }

    }
}

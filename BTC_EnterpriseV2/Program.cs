using Syncfusion.Windows.Forms.Grid.Grouping;

namespace BTCP_EnterpriseV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc3MTI2NUAzMjMyMmUzMDJlMzBnOEZsZlBUZGxxSkVPazZ6NksyNm1xaTBzZFd3aGYrcm1xam9yNlZyZDg0PQ==");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzk4NDE2MkAzMjM5MmUzMDJlMzAzYjMyMzkzYmk4QzNZdUlrVmdUclliT2VkRDFsZU0xcnJBeTQrN1JPMDB2MnNkYlJmOHM9"); //license for 29.1.33 version
            ApplicationConfiguration.Initialize();
            Application.Run(new BTC_EnterpriseV2.Modal.timerv3());
            //  Application.Run(new TestForm());
            // Application.Run(new ProcessFrm());
        }
    }
}
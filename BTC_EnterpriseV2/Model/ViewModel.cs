using System.ComponentModel;
using Syncfusion.WinForms.DataGrid.Enums;

namespace BTC_EnterpriseV2.Model
{
    public class ViewModel
    {
        public class ProcessViewModel
        {
            public string expandIcon { get; set; }
            public int Index { get; set; }
            public string? ProcessId { get; set; }
            public string Name { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string? Duration { get; set; }
            public string Status { get; set; } = "Open";
            public string? Color { get; set; } = "LightGray";
            public string StartButton { get; set; }
            public string EndButton { get; set; }
            public string HoldButton { get; set; }

            public bool IsStarted { get; set; }
            public bool IsOnHold { get; set; }
            public bool IsCancelled { get; set; }
            public bool IsEnded { get; set; }
            public bool IsExpanded { get; set; }

            // ✅ Use BindingList directly
            public BindingList<ChildProcessViewModel> SubProcesses { get; set; } = new BindingList<ChildProcessViewModel>();

            public RowType RowType { get; internal set; }
            public ProcessViewModel Data { get; internal set; }
        }

        public class ChildProcessViewModel
        {
            public int Id { get; set; }
            public string ProcessId { get; set; }
            public string TimeStart { get; set; }
            public string TimeEnd { get; set; }
            public string Remarks { get; set; }
        }


        public class SubProcessView
        {
            public int Index { get; set; }
            public int? MaterialID { get; set; }
            public string Name { get; set; }
            public string Ipn { get; set; }
            public string Torque { get; set; }

            public int IsSerialized { get; set; }
            public int IsTorque { get; set; }

            public string? Serial_qty { get; set; }
            public string? Serial_count { get; set; }
            public string? Torque_count { get; set; }

        }
    }
}

using System.ComponentModel;
using Syncfusion.WinForms.DataGrid.Enums;

namespace BTC_EnterpriseV2.Model
{
    public class ViewModel
    {
        public class ProcessViewModel
        {
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
            public string hide { get; set; }

            public bool IsStarted { get; set; }
            public bool IsOnHold { get; set; }
            public bool IsCancelled { get; set; }
            public bool IsEnded { get; set; }

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
        public class SubProcess
        {
            public int id { get; set; }
            public int manufacturing_order_process_id { get; set; }
            public object? name { get; set; }
            public object? ipn_number { get; set; }
            public object? serial_quantity { get; set; }
            public object? serial_count { get; set; }
            public int is_kit_list { get; set; }
            public int is_serial { get; set; }
            public int is_torque { get; set; }
        }
    }
}

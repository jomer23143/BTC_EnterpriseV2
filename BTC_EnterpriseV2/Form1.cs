using System.ComponentModel;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Interactivity;

namespace BTCP_EnterpriseV2
{
    public partial class Form1 : Form
    {
        BindingList<TestModel> data;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.AllowEditing = true;
            sfDataGrid1.Columns.Clear();

            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "Id", HeaderText = "#", Width = 50 });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "ProcessId", HeaderText = "Process", Width = 150 });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "NameA", HeaderText = "Name A", Width = 200 });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "NameB", HeaderText = "Name B", Width = 200, AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "TimeStart", HeaderText = "Time Start", Width = 150 });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "TimeEnd", HeaderText = "Time End", Width = 150 });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "Remarks", HeaderText = "Remarks", Width = 250 });

            data = new BindingList<TestModel>
    {
        new TestModel { Id = 1, ProcessId = "P001", NameA = "Process A1", NameB = "Description A1" },
        new TestModel { Id = 2, ProcessId = "P002", NameA = "Process B1", NameB = "Description B1" }
    };

            sfDataGrid1.DataSource = data;


        }


        // Model that notifies the grid when properties change
        public class TestModel : INotifyPropertyChanged
        {
            private int _id;
            private string _processId = "";
            private string _nameA = "";
            private string _nameB = "";
            private string _timeStart = "";
            private string _timeEnd = "";
            private string _remarks = "";

            public int Id { get => _id; set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } } }
            public string ProcessId { get => _processId; set { if (_processId != value) { _processId = value; OnPropertyChanged(nameof(ProcessId)); } } }
            public string NameA { get => _nameA; set { if (_nameA != value) { _nameA = value; OnPropertyChanged(nameof(NameA)); } } }
            public string NameB { get => _nameB; set { if (_nameB != value) { _nameB = value; OnPropertyChanged(nameof(NameB)); } } }
            public string TimeStart { get => _timeStart; set { if (_timeStart != value) { _timeStart = value; OnPropertyChanged(nameof(TimeStart)); } } }
            public string TimeEnd { get => _timeEnd; set { if (_timeEnd != value) { _timeEnd = value; OnPropertyChanged(nameof(TimeEnd)); } } }
            public string Remarks { get => _remarks; set { if (_remarks != value) { _remarks = value; OnPropertyChanged(nameof(Remarks)); } } }

            public event PropertyChangedEventHandler? PropertyChanged;
            protected void OnPropertyChanged(string propertyName) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int rowIndex = sfDataGrid1.CurrentCell.RowIndex;
            var record = sfDataGrid1.GetRecordAtRowIndex(rowIndex) as TestModel;
            if (record == null) return;

            var textBox = sender as TextBox;
            if (textBox == null) return;

            // Mirror NameA ? NameB in real-time
            record.NameB = textBox.Text;
        }



        private void sfDataGrid1_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            // Only if user is editing NameA column
            if (e.DataColumn.GridColumn.MappingName != "NameA")
                return;

            // Get the active editing control (TextBox for GridTextColumn)
            var textBox = sfDataGrid1.CurrentCell?.CellRenderer?.CurrentCellRendererElement as TextBox;
            if (textBox != null)
            {
                // Avoid duplicate subscriptions
                textBox.TextChanged -= textBox1_TextChanged;
                textBox.TextChanged += textBox1_TextChanged;
            }
        }

        private void sfDataGrid1_CurrentCellActivated(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatedEventArgs e)
        {   // Check if editing NameA column
            //    if (e.DataColumn.MappingName != "NameA")
            //        return;

            //    // Get the active renderer for TextBox columns
            //    var textRenderer = sfDataGrid1.CellRenderers["TextBox"] as GridTextBoxCellRenderer;
            //    if (textRenderer == null) return;

            //    // Active editing control
            //    var textBox = textRenderer.EditingControl as TextBox;
            //    if (textBox != null)
            //    {
            //        textBox.TextChanged -= TextBox_TextChanged; // avoid duplicates
            //        textBox.TextChanged += TextBox_TextChanged;
            //    }
        }

        private void sfDataGrid1_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            // Guard: only act on real data rows
            if (e.DataRow == null || e.DataRow.RowType != RowType.DefaultRow)
                return;

            // Get your bound object
            var record = e.DataRow.RowData as TestModel;
            if (record == null) return;
        }
    }
}

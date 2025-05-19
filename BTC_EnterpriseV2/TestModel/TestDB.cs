namespace BTCP_EnterpriseV2.TestModel
{
    public class TestDB
    {
        public class ManufacturingOrder
        {
            public string MOID { get; set; }
            public string BOMItem { get; set; }
            public string Status { get; set; }
            public List<Segment> Segments { get; set; }
        }

        public class Segment
        {
            public string Name { get; set; }
            public List<Station> Stations { get; set; }
        }

        public class Station
        {
            public string? Name { get; set; }
            public string? RefCode { get; set; }
            public string? SerialNumber { get; set; }
            public List<Process> Processes { get; set; }
        }

        public class Process
        {
            public string Name { get; set; }
            public string IPNNumber { get; set; }
            public int Quantity { get; set; }
        }

        public ManufacturingOrder GetStaticResponse()
        {
            return new ManufacturingOrder
            {
                MOID = "CE0000000035855",
                BOMItem = "202-0095-01",
                Status = "In Progress",
                Segments = new List<Segment>
            {
                    new Segment
                    {
                    Name = "Sub-Assembly",
                    Stations = new List<Station>
                    {
                        new Station
                        {
                            Name = "LCD Display",
                            RefCode = "300KWND",
                            SerialNumber = "300KWND25E0001",
                            Processes = new List<Process>
                            {
                                new Process
                                {
                                    Name = "Display Holder Attachment & fixing of touch panel cable",
                                    IPNNumber = "100-001-222",
                                    Quantity = 1
                                }
                            }
                        },
                        new Station
                        {
                            Name = "Cooling Unit and Motor Pump",
                            RefCode = "300KWD",
                            SerialNumber = "300KWD25E0003",
                            Processes = new List<Process>
                            {
                                new Process
                                {
                                    Name = "Cooling Unit Assembly",
                                    IPNNumber = "110-22332-232",
                                    Quantity = 3
                                }
                            }
                        },
                        new Station
                        {
                            Name = "Right Panel",
                            RefCode = "300KWF",
                            SerialNumber = "300KWF25E0005",
                            Processes = new List<Process>
                            {
                                new Process { Name = "PS3 & PS4 Attachment" },
                                new Process { Name = "PS3 & PS4 Attachment" },
                                new Process { Name = "SECC Board Attachment" }
                            }
                        },
                        new Station
                        {
                            Name = "Left Panel",
                            RefCode = "300KWG",
                            SerialNumber = "300KWG25E0006",
                            Processes = new List<Process>
                            {
                                new Process { Name = "PS1 & PS2 Attachment", Quantity = 3 },
                                new Process { Name = "PS1 & PS2 Attachment", Quantity = 2 },
                                new Process { Name = "Fiber Optic Attachment", Quantity = 2 }
                            }
                        },
                        new Station
                        {
                            Name = "Payment System Sub-Assy",
                            RefCode = "300KWH",
                            SerialNumber = "300KWH25E0007",
                            Processes = new List<Process>
                            {
                                new Process { Name = "RFID Plate Attachment" },
                                new Process { Name = "Speaker Attachment" },
                                new Process { Name = "Nayax Attachment" },
                                new Process { Name = "Button Attachment" }
                            }
                        }
                    }
                }
            }
            };
        }
    }

}

//Employee class added by the syncfusion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BTC_EnterpriseV2
{
    public class Employee : INotifyPropertyChanged
    {
        #region Private members

        private bool _selected;
        private string _name;
        private string _designation;
        private string _mail;
        private string _trust;
        private string _status;
        private int _proficiency; 
        private int _salary;
        private string _address;
        private string _gender;


        #endregion

        public Employee(bool selected, string name, string designation, string mail, string location, string trust, string status, int proficiency, int salary, string address, string gender)
        {
            Selected = selected;
            EmployeeName = name;
            Designation = designation;
            Mail = mail;
            Location = location;
            Trustworthiness = trust; 
            Status = status;
            SoftwareProficiency = proficiency;
            Salary = salary;
            Address = address;
            Gender = gender;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged("Selected");
            }
        }
        /// <summary>
        /// Gets or sets the Employee name.
        /// </summary>                
        public string EmployeeName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("EmployeeName");
            }
        }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>                
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value;
                RaisePropertyChanged("Designation");
            }
        }

        /// <summary>
        /// Gets or sets the mail ID.
        /// </summary>                
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                RaisePropertyChanged("Mail");
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>                
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Trustworthiness.
        /// </summary>                
        public string Trustworthiness
        {
            get
            {
                return _trust;
            }
            set
            {
                _trust = value;
                RaisePropertyChanged("Trustworthiness");
            }
        }
         
        /// <summary>
        /// Gets or sets the status.
        /// </summary>                
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Gets or sets the software proficiency .
        /// </summary>                
        public int SoftwareProficiency
        {
            get
            {
                return _proficiency;
            }
            set
            {
                _proficiency = value;
                RaisePropertyChanged("SoftwareProficiency");
            }
        }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>                
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                RaisePropertyChanged("Salary");
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>                
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>                
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                RaisePropertyChanged("Gender");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

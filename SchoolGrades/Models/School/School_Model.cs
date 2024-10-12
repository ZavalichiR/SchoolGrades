using SchoolGrades.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolGrades.Models.School
{
    public class School_Model : ViewModelBase
    {
        private string _schoolName;
        public string SchoolName
        {
            get { return _schoolName; }
            set { 
                _schoolName = value;
                OnPropertyChanged();
            }
        }

        private string _security_code;
        public string SecurityCode
        {
            get { return _security_code; }
            set
            {
                _security_code = value;
                OnPropertyChanged();
            }
        }
    }
}

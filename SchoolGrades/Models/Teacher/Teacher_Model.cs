using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolGrades.MVVM;

namespace SchoolGrades.Models.Teacher
{
    public class Teacher_Model : ViewModelBase
    {

        private string _name2;
        public string FullName
        {
            get { return _name2; }
            set
            {
                _name2 = value;
                OnPropertyChanged();
            }

        }

        private string _error_message;
        public string ErrorMessage
        {
            get { return _error_message; }
            set
            {
                _error_message = value;
                OnPropertyChanged();
            }
        }

    }
}

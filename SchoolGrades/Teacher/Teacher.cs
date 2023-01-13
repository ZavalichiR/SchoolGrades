using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolGrades.MVVM;
namespace SchoolGrades.Teacher
{
    public class Teacher : ViewModelBase
    {
        private int _teacherCount;
        public int TeacherCount
        {
            get { return _teacherCount; }
            set { _teacherCount = value;
                OnPropertyChanged();
            }
        }


        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; 
            OnPropertyChanged();}
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


        private string _name;
        public string First_Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged();
            }
            
        }

        private string _name2;
        public string Last_Name
        {
            get { return _name2; }
            set
            {
                _name2 = value;
                OnPropertyChanged();
            }

        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value;
                OnPropertyChanged();
            }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolGrades.MVVM;
using SchoolGrades.ViewModels;

namespace SchoolGrades.Student
{
    public class Student : ViewModelBase
    {

        private int _studentscount;
        public int StudentsCount
        {
            get { return _studentscount; }
            set { _studentscount = value;
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

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;
            OnPropertyChanged();
            }
        }

        private string _school_Address;
        public string Address
        {
            get { return _school_Address; }
            set
            {
                _school_Address = value;
                OnPropertyChanged();
            }
        }

        private string _class;
        public string Class
        {
            get { return _class; }
            set { _class = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
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

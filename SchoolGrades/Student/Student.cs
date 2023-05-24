using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolGrades.Classes;
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

        private ClassViewModel _selectedClass;
        public ClassViewModel SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                if (_selectedClass != value)
                {
                    _selectedClass = value;
                    OnPropertyChanged("SelectedClass");
                }
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
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

        private string _Class;
        public string Class
        {
            get { return _Class; }
            set
            {
                _Class = value;
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

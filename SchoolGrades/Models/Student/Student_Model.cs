using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolGrades.Models.School;
using SchoolGrades.Models.User;
using SchoolGrades.MVVM;

namespace SchoolGrades.Models.Student
{
    public class Student_Model : User_Model
    {
        private string _city;
        public string Student_City
        {
            get { return _city; }
            set { _city = value;
                OnPropertyChanged();
            }
        }

        private string _county;
        public string Student_County
        {
            get { return _county; }
            set
            {
                _county = value;
                OnPropertyChanged();
            }
        }

        private string _address;
        public string Student_Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private string _phone;
        public string Student_PhoneNumber
        {
            get { return _phone; }
            set { _phone = value; 
                OnPropertyChanged(); }
        }

        private School_Model _school_Model;
        public School_Model School
        {
            get { return _school_Model; }
            set { _school_Model = value; 
                OnPropertyChanged(); }
        }

    }
}

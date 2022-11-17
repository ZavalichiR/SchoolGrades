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
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;
            OnPropertyChanged();
            }
        }

        private string _school_course;
        public string Course
        {
            get { return _school_course; }
            set { _school_course = value;
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

        private int? _grade;
        public int? Grade
        {
            get { return _grade; }
            set { _grade = value;
                OnPropertyChanged();
            }
        }

        private int? _absent;
        public int? Absent
        {
            get { return _absent; }
            set
            {
                _absent = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand UnSelectCommand { get; }



    }
}

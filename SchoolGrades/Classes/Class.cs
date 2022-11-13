using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolGrades.MVVM;
using SchoolGrades.ViewModels;

namespace SchoolGrades.Classes
{
    public class Class : ViewModelBase
    {
        private string _name;
        public string Class_Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }


        private int _id;
        public int Class_ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }


        private int _students_limit;
        public int Class_Students_Limit
        {
            get { return _students_limit; }
            set
            {
                _students_limit = value;
                OnPropertyChanged();
            }
        }




    }
}

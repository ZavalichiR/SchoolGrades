using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SchoolGrades.MyUserController;
using SchoolGrades.MVVM;
using System.Windows;
using System.Windows.Input;
using GenericUi.Commands;

namespace SchoolGrades.ViewModels
{

    public class ViewModel
    {
        public ObservableCollection<StudentModel> Students { get; } = new ObservableCollection<StudentModel>();

    }


    public class StudentModel
    {
        private string _student;
        public string Name
        {
            get { return _student; }
            set { _student = value; }
        }

        private string _class;

        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }

        private int _grade;
        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }


        private int _absent;
        public int Absent
        {
            get { return _absent; }
            set { _absent = value; }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

    }

}


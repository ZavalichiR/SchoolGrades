using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SchoolGrades.ViewModels
{
    public class StudentModel
    {
        ObservableCollection<StudentModel> Students { get; set; }

        private string _student;
        public string Name
        {
            get { return _student; }
            set { _student = value; }
        }

        private string _student_class;

        public string Class
        {
            get { return _student_class; }
            set { _student_class = value; }
        }

        private string _grade;
        public string Grade
        {
            get { return _grade; } 
            set { _grade = value; }
        }

    }
}

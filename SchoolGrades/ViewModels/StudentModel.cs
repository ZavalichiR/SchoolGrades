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
        public string Student_name
        {
            get { return _student; }
            set { _student = value; }
        }
    }
}

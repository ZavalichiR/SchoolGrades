using SchoolGrades.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGrades.Student
{
    public class StudentGrade : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _grade;
        public string Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                OnPropertyChanged();
            }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description= value;
                OnPropertyChanged();
            }
        }
    }
}

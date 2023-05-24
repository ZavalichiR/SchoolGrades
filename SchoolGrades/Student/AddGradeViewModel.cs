using GenericUi.Commands;
using MaterialDesignThemes.Wpf;
using SchoolGrades.MVVM;
using SchoolGrades.MyUserController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace SchoolGrades.Student
{
    public class AddGradeViewModel : ViewModelBase
    {
        private ObservableCollection<StudentGrade> _students = new ObservableCollection<StudentGrade>();
        public ObservableCollection<StudentGrade> Grades
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private StudentGrade _selectedStudent = new StudentGrade();
        public StudentGrade StudentGrade
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UnSelectCommand { get; }


        public AddGradeViewModel()
        {
            AddCommand = new RelayCommand(_ => Add());
            UnSelectCommand = new RelayCommand(y => UnSelect((Student)y));

            Grades.Add(new StudentGrade()
            {
                Name = "Ex. Razvan",
                Subject = "Math",
                Grade = "10",
                Description = "Good presentation in class."
            });


            Grades.Add(new StudentGrade()
            {
                Name = "Ex. Casian",
                Subject = "INOVAFEST",
                Grade = "10++",
                Description = "Very well done theme."
            });

            Grades.Add(new StudentGrade()
            {
                Name = "Ex. Petru Turcu",
                Subject = "Turkish",
                Grade = "10",
                Description = "Very well done homework."
            });

            Grades.Add(new StudentGrade()
            {
                Name = "Ex. Menegon",
                Subject = "Franceza",
                Grade = "8",
                Description = "The accent is very good, but it still needs work"
            });
            //  Grades.Add(new Student() { Name = "Ex. Razvan", Subject = "Math", Grade = "10" });
            /* Grades.Add(new Student() { Name = "Ex. Casian", Subject = "Geography", Grade = "7" });
             Grades.Add(new Student() { Name = "Ex. Stefi", Subject = "English", Grade = "5" });*/

        }

        public void Add()
        {

            foreach(StudentGrade student in Grades)
            { 
                // Adauga Student nou

                Grades.Add(StudentGrade);
                StudentGrade = new StudentGrade();
            }

        }


        public void UnSelect(Student student)
        {
            StudentAddGrade_UserController qwe = new StudentAddGrade_UserController();
            qwe.DataGrid_StudentsGrade.UnselectAllCells();
            StudentGrade = new StudentGrade();
        }
    }
}


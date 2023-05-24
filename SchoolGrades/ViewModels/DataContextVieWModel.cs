using SchoolGrades.Student;
using SchoolGrades.Classes;
using SchoolGrades.Teacher;
using System.Collections.ObjectModel;
using SchoolGrades.MVVM;

namespace SchoolGrades.ViewModels
{
    public class DataContextVieWModel : ViewModelBase
    {
        public StudentViewModel StudentViewModel { get; set; }
        public Teacher_ViewModel TeacherViewModel { get; set; }
        public ClassViewModel ClassViewModel { get; set; }
        public AddGradeViewModel AddGradeViewModel { get; set; }

        public DataContextVieWModel()
        {
            StudentViewModel = new StudentViewModel();
            TeacherViewModel = new Teacher_ViewModel();
            ClassViewModel = new ClassViewModel();
            AddGradeViewModel = new AddGradeViewModel();
        }
    }
}

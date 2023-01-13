using SchoolGrades.Student;
using SchoolGrades.Classes;
using SchoolGrades.Teacher;

namespace SchoolGrades.ViewModels
{
    public class DataContextVieWModel 
    {
        public StudentViewModel StudentViewModel { get; set; }
        public Teacher_ViewModel TeacherViewModel { get; set; }
        public ClassViewModel ClassViewModel { get; set; }

        public DataContextVieWModel()
        {
            StudentViewModel = new StudentViewModel();
            TeacherViewModel = new Teacher_ViewModel();
            ClassViewModel = new ClassViewModel();
        }
    }
}

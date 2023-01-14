using System.Windows.Controls;
using SchoolGrades.Teacher;
using SchoolGrades.ViewModels;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Teacher_UserControl.xaml
    /// </summary>
    public partial class Teacher_UserControl : UserControl
    {
        public Teacher_UserControl()
        {
            InitializeComponent();
            Teacher_ViewModel qwe = new Teacher_ViewModel();
            DataContext = qwe;
        }
    }
}

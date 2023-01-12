using System.Windows.Controls;
using SchoolGrades.Student;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Students_UserControl.xaml
    /// </summary>
    public partial class Students_UserControl : UserControl
    {
        public Students_UserControl()
        {
            InitializeComponent();
            StudentViewModel abc = new StudentViewModel();
            DataContext = abc;
            
        }
    }
}

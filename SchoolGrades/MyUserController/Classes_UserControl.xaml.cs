using System.Windows.Controls;
using SchoolGrades.Classes;


namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Classes_UserControl.xaml
    /// </summary>
    public partial class Classes_UserControl : UserControl
    {
        public Classes_UserControl()
        {
            InitializeComponent();
            ClassViewModel abc = new ClassViewModel();
            DataContext = abc;
        }

    }
}

using System.Windows.Controls;
using SchoolGrades.ViewModels;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Dashboard_UserControl.xaml
    /// </summary>
    public partial class Dashboard_UserControl : UserControl
    {
        public Dashboard_UserControl()
        {
            InitializeComponent();
            DataContextVieWModel qwe = new DataContextVieWModel();
            DataContext = qwe;
        }
    }
}

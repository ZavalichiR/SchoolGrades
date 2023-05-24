using SchoolGrades.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for StudentAddGrade_UserController.xaml
    /// </summary>
    public partial class StudentAddGrade_UserController : UserControl
    {
        public StudentAddGrade_UserController()
        {
            InitializeComponent();
            DataContextVieWModel abc = new DataContextVieWModel();
            DataContext = abc;

        }
    }
}

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
using SchoolGrades.ViewModels;
using System.Collections.ObjectModel;
using System.Collections;

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

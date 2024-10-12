using SchoolGrades.MyUserController.MainWindow_UserControllers;
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
using System.Windows.Shapes;
using SchoolGrades.MyUserController.MainWindow_UserControllers.For_Students;
namespace SchoolGrades.Views
{
    /// <summary>
    /// Interaction logic for AppMainWindow.xaml
    /// </summary>
    public partial class AppMainWindow : Window
    {
        public AppMainWindow()
        {
            InitializeComponent();
        }

        private void Load_DashboardUserController(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new StudentsDashboard_UserController());
        }

        public void Load_DashboardUserController()
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new StudentsDashboard_UserController());
        }
    }
}

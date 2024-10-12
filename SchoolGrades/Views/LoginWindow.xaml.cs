using SchoolGrades.MyUserController.LoginWindow_UserControllers;
using SchoolGrades.ViewModels.LoginWindow_ViewModels;
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

namespace SchoolGrades.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginViewModel viewModel = new LoginViewModel();
            this.DataContext = viewModel;
        }

        private void Change_To_LoginUserControl(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new LoginUserControl());
        }

        public void Change_To_RegisterUserControl()
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new RegisterUserControl());
        }

        public void Change_To_LoginUserControl()
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new LoginUserControl());
        }
    }
}

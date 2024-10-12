using SchoolGrades.Views;
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

namespace SchoolGrades.MyUserController.LoginWindow_UserControllers
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
            var abc = Application.Current.MainWindow as LoginWindow;
            if (abc != null)
            {
                this.DataContext = abc.DataContext;
            }
        }

        private void Change_To_RegisterWindow(object sender, RoutedEventArgs e)
        {
            var mainLoginWindow= (LoginWindow)Window.GetWindow(this);
            if (mainLoginWindow == null)
            {
                MessageBox.Show("Error. Can't find LoginWindow. ");
            }
            else
            {
                mainLoginWindow.Change_To_RegisterUserControl();
            }

        }
    }
}

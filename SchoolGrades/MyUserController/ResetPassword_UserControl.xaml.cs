using SchoolGrades.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for ResetPassword_UserControl.xaml
    /// </summary>
    public partial class resetPasswordController : UserControl
    {
        /// <summary>
        ///  public event EventHandler BackButtonClick;
        /// </summary>

        public resetPasswordController()
        {
            InitializeComponent();
        }

        // Close Application
        private void Close_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        // Show Password
        private void MyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (fShowPassword.IsChecked == true)
            {
                fPasswordUnmask.Visibility = Visibility.Visible;
                fPasswordUnmask2.Visibility= Visibility.Visible;
                fPasswordHidden.Visibility = Visibility.Hidden;
                fNewPassword.Visibility = Visibility.Hidden;
                fPasswordUnmask.Text = fPasswordHidden.Password;
                fPasswordUnmask2.Text= fNewPassword.Password;
            }
        }

        private void MyCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            fPasswordUnmask.Visibility = Visibility.Hidden;
            fPasswordUnmask2.Visibility= Visibility.Hidden;
            fPasswordHidden.Visibility = Visibility.Visible;
            fNewPassword.Visibility = Visibility.Visible;
            fPasswordHidden.Password = fPasswordUnmask.Text;
            fNewPassword.Password = fPasswordUnmask2.Text;
        }

        // After pressing the Back button,
        // this usercontroller should appear back in
        // (LoginWindow named MainWindow)

        private void GoBack(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow._previousContent.Visibility = Visibility.Visible;
            mainWindow.Title_Login.Visibility = Visibility.Visible;
            mainWindow.Exit.Visibility = Visibility.Visible;
            fRenderPage.Visibility = Visibility.Collapsed;
        }
    }
}

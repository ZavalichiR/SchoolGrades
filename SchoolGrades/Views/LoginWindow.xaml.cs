using SchoolGrades.MyUserController;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades.Views
{
    public partial class MainWindow
    {

        public UIElement _previousContent;
        public MainWindow()
        {
            InitializeComponent();
            _previousContent = RenderPage.Children[2];
            ViewModels.LoginViewModel obj = new ViewModels.LoginViewModel();
            DataContext = obj;
        }


        // Movable Window
        private void Move_Window(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //Shutdown Application
        private void Close_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Show Password    
        private void MyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ShowPassword.IsChecked == true)
            {
                PasswordUnmask.Visibility = Visibility.Visible;
                PasswordHidden.Visibility = Visibility.Hidden;
                PasswordUnmask.Text = PasswordHidden.Password;

            }
        }

        // Return the password to passwordchar
        private void MyCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            PasswordUnmask.Visibility = Visibility.Hidden;
            PasswordHidden.Visibility = Visibility.Visible;
            PasswordHidden.Visibility = Visibility.Visible;
            PasswordHidden.Password = PasswordUnmask.Text;
        }

        private void ResetPassword_Button_Click(object sender, RoutedEventArgs e)
        {
            RenderPage.Children[0].Visibility = Visibility.Collapsed;
            Title_Login.Visibility = Visibility.Collapsed;
            RenderPage.Children.Add(new resetPasswordController());
        }
    }
}

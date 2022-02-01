using System.Windows;

namespace SchoolGrades.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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
    
    }
}

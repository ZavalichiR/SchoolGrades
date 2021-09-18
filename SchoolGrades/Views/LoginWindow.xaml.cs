
namespace SchoolGrades.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Movable Window
        private void Move_Window(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        //Shutdown
        private void Close_Application(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        // Show Password    
        private void MyCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShowPassword.IsChecked == true)
            {
                PasswordUnmask.Visibility = System.Windows.Visibility.Visible;
                PasswordHidden.Visibility = System.Windows.Visibility.Hidden;
                PasswordUnmask.Text = PasswordHidden.Password;
            }
        }

        // Return the password to passwordchar
        private void MyCheckBox_UnChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PasswordUnmask.Visibility = System.Windows.Visibility.Hidden;
            PasswordHidden.Visibility = System.Windows.Visibility.Visible;
        }
    }
}

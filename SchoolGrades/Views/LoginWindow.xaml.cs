using System.Windows;

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

        //Shutdown Application
        private void Close_Application(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
        private void MyCheckBox_UnChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PasswordUnmask.Visibility = Visibility.Hidden;
            PasswordHidden.Visibility = Visibility.Visible;
            PasswordHidden.Visibility = Visibility.Visible;
            PasswordHidden.Password = PasswordUnmask.Text;
        }

        // Validate UserName and Password with field
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user, pass;
            user = UserName_TextBOX.Text;
            pass = PasswordHidden.Password;
            PasswordUnmask.Text = PasswordHidden.Password;
            if (user == "student" && pass == "student_password")
            {
                User_Window sw = new User_Window();
                sw.Show();
                this.Close();
            } else {
                MessageBox.Show("You'r UserName/Password is invalid or ShowPassword is activated!");
            }
        }
    }
}

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
using System.Threading;
using SchoolGrades.MyUserController;
using System.Windows.Threading;
using System.Timers;

namespace SchoolGrades.Views
{
    /// <summary>
    /// Interaction logic for ApplicationMainWindow.xaml
    /// </summary>
    public partial class ApplicationMainWindow : Window
    {
        Dashboard_UserControl DashboardController = new Dashboard_UserControl();
        Loading_UserController LoadingController = new Loading_UserController();
        public ApplicationMainWindow()
        {
            InitializeComponent();

            RenderPage.Children.Add(new Loading_UserController());

            // LoadingScreen (0)
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        // Working for LoadingScreen (1)
        private void Timer_Tick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            SwitchToDashboard();
        }

        // Working for LoadingScreen (2)
        private void SwitchToDashboard()
        {
            RenderPage.Children.RemoveAt(0);
            RenderPage.Children.Add(new Dashboard_UserControl());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region old_code
            /*RenderPage.Children.Clear();
            RenderPage.Children.Add(new MyUserController.Loading_UserController());
            System.Threading.Thread.Sleep(1000);

            RenderPage.Children.Add(new MyUserController.Dashboard_UserControl());*/
            #endregion
        }

        /*Button - Dashboard */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new Dashboard_UserControl());
        }

        /*Button - Classes*/
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new Classes_UserControl());
        }

        /*Button - Students*/
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new Students_UserControl());
        }

        /*Button - Log OUT */
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow nw = new MainWindow();
            nw.Show();
            this.Hide();
        }

        /*Application Move*/
        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /*Application Exit*/
        private void Application_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }

        /*Maximize*/
        private void Maximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        /*Minimize*/
        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /*Button - Teachers */
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new Teacher_UserControl());
        }
    }
}

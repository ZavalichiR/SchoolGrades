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

namespace SchoolGrades.Views
{
    /// <summary>
    /// Interaction logic for ApplicationMainWindow.xaml
    /// </summary>
    public partial class ApplicationMainWindow : Window
    {
        public ApplicationMainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new MyUserController.Dashboard_UserControl());
        }

        /*Button - Dashboard */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new MyUserController.Dashboard_UserControl());
        }

        /*Button - Classes*/
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new MyUserController.Classes_UserControl());
        }

        /*Button - Students*/
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new MyUserController.Students_UserControl());
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
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
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
            RenderPage.Children.Add(new MyUserController.Teacher_UserControl());
        }
    }
}

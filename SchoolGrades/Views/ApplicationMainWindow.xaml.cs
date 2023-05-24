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
using System.Collections.Specialized;
using SchoolGrades.Classes;

namespace SchoolGrades.Views
{
    /// <summary>
    /// Interaction logic for ApplicationMainWindow.xaml
    /// </summary>
    public partial class ApplicationMainWindow : Window
    {
        Dashboard_UserControl DashboardController = new Dashboard_UserControl();
        Loading_UserController LoadingController = new Loading_UserController();

        private bool isDashboardOrLoading = false;
        private bool isClassesOrStudentsOrTeachers = false;


        public ApplicationMainWindow()
        {
            InitializeComponent();

            RenderPage.Children.Add(new Loading_UserController());
            

            /*RenderPage.Loaded += OnRenderPageLoaded;
            RenderPage.Unloaded += OnRenderPageUnloaded;
*/

            RenderPage.LayoutUpdated += OnRenderPageChildrenChanged;




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



        private void OnRenderPageChildrenChanged(object sender, EventArgs e)
        {
            bool isDashboardOrLoading = false;
            bool isClassesOrStudentsOrTeachers = false;
            Grid renderPageGrid = RenderPage;

            foreach (UIElement child in renderPageGrid.Children)
            {
                if (child is Dashboard_UserControl || child is Loading_UserController)
                {
                    isDashboardOrLoading = true;
                    Grid.SetRowSpan(renderPageGrid, 2);
                    break;

                }
                else if (child is Students_UserControl || child is Teacher_UserControl || child is Classes_UserControl || child is StudentAddGrade_UserController)
                {
                    isClassesOrStudentsOrTeachers = true;
                    Grid.SetRowSpan(RenderPage, 1);
                    break;
                }
            }

            SetGridMenuHeight();

            Grid_Menu.Visibility = isDashboardOrLoading ? Visibility.Collapsed : Visibility.Visible;
            Grid_Menu.Visibility = isClassesOrStudentsOrTeachers ? Visibility.Visible : Visibility.Collapsed;

            
        }

        private void SetGridMenuHeight()
        {
            if (isDashboardOrLoading)
            {
                Grid_Menu.Height = 0;
            }
            else if (isClassesOrStudentsOrTeachers)
            {
                Grid_Menu.Height = 60;
            }
        }


        #region LoadUserControl_Dashboard
        public void LoadUserControl_Classes()
        {
            Grid renderPage = (Grid)this.RenderPage;
            renderPage.Children.Clear();
            renderPage.Children.Add(new Classes_UserControl());
        }

        public void LoadUserControl_Students()
        {
            Grid renderPage = (Grid)this.RenderPage;
            renderPage.Children.Clear();
            renderPage.Children.Add(new Students_UserControl());
        }

        public void LoadUserControl_Teachers()
        {
            Grid renderPage = (Grid)this.RenderPage;
            renderPage.Children.Clear();
            renderPage.Children.Add(new Teacher_UserControl());
        }

        public void LoadUserControl_AddStudentsGrade()
        {
            Grid renderPage = (Grid)this.RenderPage;
            renderPage.Children.Clear();
            renderPage.Children.Add(new StudentAddGrade_UserController());
        }
        #endregion
    }
}

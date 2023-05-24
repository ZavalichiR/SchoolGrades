using System.Windows.Controls;
using SchoolGrades.ViewModels;
using SchoolGrades.Views;
using System.Windows;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Dashboard_UserControl.xaml
    /// </summary>
    public partial class Dashboard_UserControl : UserControl
    {
        public Dashboard_UserControl()
        {
            InitializeComponent();
            DataContextVieWModel qwe = new DataContextVieWModel();
            DataContext = qwe;
        }

        private void Btn_Classes(object sender, RoutedEventArgs e)
        {
            ApplicationMainWindow mainWindow = (ApplicationMainWindow)Window.GetWindow(this);
            mainWindow.LoadUserControl_Classes();
        }

        private void Btn_AddStudents(object sender, RoutedEventArgs e)
        {
            ApplicationMainWindow mainWindow = (ApplicationMainWindow)Window.GetWindow(this);
            mainWindow.LoadUserControl_Students();
        }

        private void Btn_MenuTeacher(object sender, RoutedEventArgs e)
        {
            ApplicationMainWindow mainWindow = (ApplicationMainWindow)Window.GetWindow(this);
            mainWindow.LoadUserControl_Teachers();
        }
    }
}

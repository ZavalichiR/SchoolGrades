using System;
using System.Windows;
using System.Windows.Controls;
using SchoolGrades.Student;
using SchoolGrades.ViewModels;
using SchoolGrades.Views;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Students_UserControl.xaml
    /// </summary>
    public partial class Students_UserControl : UserControl
    {
        public Students_UserControl()
        {
            InitializeComponent();
            DataContextVieWModel abc = new DataContextVieWModel();
            DataContext = abc;

        }

        private void ChangeUserController(object sender, RoutedEventArgs e)
        {
            ApplicationMainWindow mainWindow = (ApplicationMainWindow)Window.GetWindow(this);
            mainWindow.LoadUserControl_AddStudentsGrade();
        }


        public event EventHandler<string> TextBoxTextChanged;
        private void Student_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newText = Student_Name.Text;
            TextBoxTextChanged?.Invoke(this, newText);
        }
    }
}

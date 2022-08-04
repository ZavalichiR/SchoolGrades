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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolGrades.ViewModels;

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
            StudentModel __student = new StudentModel();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentModel __student = new StudentModel();
            __student.Name = Student_Name.Text;
            __student.Class = Student_Class.Text;
            __student.Grade = Student_Grade.Text;

            DataGrid_Students.Items.Add(__student);
        }
    }
}

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
            Employee student = new Employee();
        }

        public class Employee
        {

             public string Name { get; set; }
             public string Class { get; set; }
             public string Grade { get; set; }

            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee student = new Employee();
            student.Name = Student_Name.Text;
            student.Class = Student_Class.Text;
            student.Grade = Student_Grade.Text;

            DataGrid_Students_List.Items.Add(student);
        }
    }
}

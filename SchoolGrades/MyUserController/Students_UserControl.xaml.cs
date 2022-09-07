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
using System.Collections.ObjectModel;
using System.Collections;

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

        #region Insert_Rows
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentModel __student = new StudentModel();
            __student.Name = Student_Name.Text;
            __student.Class = Student_Class.Text;




            /*STUDENT GRADE*/
        /*i*/
            if (Student_Grade.Text.Trim() == "") return;
            for (int i = 0; i < Student_Grade.Text.Trim().Length; i++)
            {
                if (!char.IsNumber(Student_Grade.Text[i]))
                {
                    MessageBox.Show("Please enter a valid number to Grade", "Error", MessageBoxButton.OK);
                    Student_Grade.Text = "";
                    return;
                } else
                {
                    __student.Grade = int.Parse(Student_Grade.Text);
                }
            }

            /*STUDENT ABSENT*/
        /*j*/
            if (Student_Absent.Text.Trim() == "") return;
            for (int j = 0; j < Student_Absent.Text.Trim().Length; j++)
            {
                if (!char.IsNumber(Student_Absent.Text[j]))
                {
                    MessageBox.Show("Please enter a valid date at absnet day", "Error", MessageBoxButton.OK);
                    Student_Absent.Text = "";
                    return;
                }
                else
                {
                    __student.Absent = int.Parse(Student_Absent.Text);
                }
            }

            /*STUDENT ID*/
        /*k*/
            if (Student_ID.Text.Trim() == "") return;
            for (int k = 0; k < Student_ID.Text.Trim().Length; k++)
            {
                if (!char.IsNumber(Student_ID.Text[k]))
                {
                    MessageBox.Show("Please enter an valid ID number!", "Error", MessageBoxButton.OK);
                    Student_ID.Text = "";
                    return;
                }
                else
                {
                    __student.ID = int.Parse(Student_ID.Text);
                }
            }

            DataGrid_Students.Items.Add(__student);
        }
        #endregion
        /*  Update Row - Button */
        #region Update_Row
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            

        }
        /*  Remove Button */
        #endregion

        #region Remove_Row
        private void Button_Remove(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}

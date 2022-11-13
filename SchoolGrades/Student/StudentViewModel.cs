using GenericUi.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolGrades.MVVM;
using SchoolGrades.MyUserController;
using System.Security.Claims;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Data;
using System.Dynamic;
using System.Windows.Markup;
using SchoolGrades.Classes;

namespace SchoolGrades.Student
{
    public class StudentViewModel : ViewModelBase
    {
        /*public Student _editingStudent = new Student();
        public Student EditingStudent
        {
            get { return _editingStudent; }
            set
            {
                _editingStudent = value;
                OnPropertyChanged();
            }
        }*/

        private ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private Student _selectedStudent = new Student();
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand UnSelectCommand { get; }



        public StudentViewModel()
        {

            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((Student)x));
            UnSelectCommand = new RelayCommand(y => UnSelect((Student)y));

            Students.Add(new Student() { Name = "Ex. Razvan", Subject = "Geography", Absent = 2, Class = "A", Grade = 10});
            Students.Add(new Student() { Name = "Ex. Casian", Subject = "Math", Absent = 3, Class = "A", Grade = 10});
            Students.Add(new Student() { Name = "Ex. Stefi", Subject = "History", Absent = 1, Class = "A", Grade = 10});
        }


        public ICollectionView View;
        private void Add()
        {
            foreach (Student student in Students)
            {
                SelectedStudent.ID = SelectedStudent.ID += 1; // Increase every new student by ID with +1
                if (!Students.Any(p => p.Name == SelectedStudent.Name)) // check if student id already exist or not
                {
                    if (SelectedStudent.ID > 0 && SelectedStudent.ID < 34) // Check if ( 0 < SelectStudent.ID < 34 ) 
                    {
                        if (string.IsNullOrEmpty(SelectedStudent.Name) || string.IsNullOrEmpty(SelectedStudent.Class) || string.IsNullOrEmpty(SelectedStudent.Subject))
                        {
                            MessageBox.Show("You can't leave the boxes empty!", "Error!");
                            break;
                        }
                        else
                        {
                            // Adding new student
                            Students.Add(SelectedStudent);
                            SelectedStudent = new Student();

                            // Sort students by ID
                            View = CollectionViewSource.GetDefaultView(Students);
                            View.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
                            View.Refresh();

                        }
                    } else if (SelectedStudent.ID > 34)
                    {
                        MessageBox.Show("You cannot exceed the maximum number of students! {Max 34}", "Error!");
                        break;

                    } else
                    {
                        MessageBox.Show("The student with this name:>> { " + SelectedStudent.Name + " } << already exists!", "Error"); ;
                        break;
                    }
                }
            }
        }
    
        private void Delete(Student student)
        {
            if (MessageBox.Show("Are you sure you want to do this operation?", "Security question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Students.Remove(student);
                //Student has been removed
            }
            else
            {
                MessageBox.Show("The operation was closed! Nothing has been changed!");
            }
        }

        private void UnSelect(Student student)
        {
            Students_UserControl qwe = new Students_UserControl();
            qwe.DataGrid_Students.UnselectAllCells();
            SelectedStudent = new Student();
        }
    }
}

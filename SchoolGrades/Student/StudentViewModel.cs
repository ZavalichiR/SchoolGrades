using GenericUi.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SchoolGrades.MVVM;
using SchoolGrades.MyUserController;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System.IO;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using SchoolGrades.Classes;
using SchoolGrades.Views;
using System.Security.Claims;

namespace SchoolGrades.Student
{
    public class StudentViewModel : ViewModelBase
    {
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
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public StudentViewModel()
        {

            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((Student)x));
            UnSelectCommand = new RelayCommand(y => UnSelect((Student)y));
            SaveCommand = new RelayCommand(z => SaveToFile((Student)z));
            LoadCommand = new RelayCommand(v => LoadFile((Student)v));


            Students.Add(new Student() { Name = "Ex. Razvan", Email = "@mail.com", Address = "Geography", Class = " Class A" });
            Students.Add(new Student() { Name = "Ex. Casian", Email = "@mail.com", Address = "Math", Class = "Class B" });
            Students.Add(new Student() { Name = "Ex. Stefi", Email = "@mail.com", Address = "History", Class = "Class C" });
            Students.Add(new Student() { Name = "Ex. Vasile", Email = "@mail.com", Address = "History", Class = "Class D" });

            SelectedStudent.StudentsCount = Students.Count();
        }


        public ICollectionView View;
        private void Add()
        {
            foreach (Student student in Students)
            {
                Classes.ClassViewModel qwe = new Classes.ClassViewModel();
                if (string.IsNullOrEmpty(SelectedStudent.Name) || string.IsNullOrEmpty(SelectedStudent.Address) || string.IsNullOrEmpty(SelectedStudent.Email) || string.IsNullOrEmpty(SelectedStudent.Class))
                {
                    SelectedStudent.ErrorMessage = "⚠️" + "You can't leave the boxes empty!";
                    return;
                }
                
                
                
                if (!qwe.Classes.Any(z => z.Class_Name == SelectedStudent.Class))
                {
                    SelectedStudent.ErrorMessage = "⚠️" + "The class you entered does not exist! Keep trying!";
                    SelectedStudent.Class = "";
                    return;
                }

                // Adauga Student nou

                    Students.Add(SelectedStudent);
                    SelectedStudent = new Student();
                                    
                    View = CollectionViewSource.GetDefaultView(Students);
                    View.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                }
            }

        private void Delete(Student student)
        {
            if (MessageBox.Show("Are you sure you want to do this operation?", "Security question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Student has been removed
                Students.Remove(student);
                SelectedStudent = new Student();
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

        private void SaveToFile(Student student)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var save_student in Students)
                    {
                        student = save_student;
                        sw.WriteLine( student.Name + ","
                            + student.Address + ","
                            + student.Class + ",");
                    }
                }
            }
            else
            {
                SelectedStudent.ErrorMessage = "⚠️" + " Nothing was saved!";
            }
        }


        private void LoadFile(Student student)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string address = parts[2];
                    string Class = parts[3];

                    if (Students.Any(s => s.Name == name && s.Address == address && s.Class == Class))
                    {
                    SelectedStudent.ErrorMessage = "⚠️" + " Duplicates has been found!";
                    } else {
                        Students.Add(new Student
                        {
                            Name = parts[0],
                            Address = parts[1],
                            Class = parts[2],
                        });
                    }
                }
            } else {
                SelectedStudent.ErrorMessage = "⚠️" + " Nothing was loaded.";
            }
        }
    }
}

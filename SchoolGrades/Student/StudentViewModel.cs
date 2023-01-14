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

            Students.Add(new Student() { Name = "Ex. Razvan", Address = "Geography", Class = "A", Username = "Razvan", Password = "123" });
            Students.Add(new Student() { Name = "Ex. Casian", Address = "Math", Class = "A", Username = "Casian", Password = "123" });
            Students.Add(new Student() { Name = "Ex. Stefi", Address = "History", Class = "A", Username = "Stefi", Password = "123" });

            // SelectedStudent.StudentsCount = Students.Count();
        }


        public ICollectionView View;
        private void Add()
        {
            Classes.ClassViewModel qwe = new Classes.ClassViewModel();
            //int i, k, l;
            foreach (Student student in Students)
            {
                if (string.IsNullOrEmpty(SelectedStudent.Name) || string.IsNullOrEmpty(SelectedStudent.Class) || string.IsNullOrEmpty(SelectedStudent.Address) || string.IsNullOrEmpty(SelectedStudent.Username) || string.IsNullOrEmpty(SelectedStudent.Password))
                {
                    SelectedStudent.ErrorMessage = "⚠️" + "You can't leave the boxes empty!";
                    break;
                }
                else
                {
                    SelectedStudent.ID += 1;
                    if (!Students.Any(p => p.ID == SelectedStudent.ID))
                    {
                        if (SelectedStudent.ID > 0 && SelectedStudent.ID < 34)
                        {
                            if (!qwe.Classes.Any(z => z.Class_Name == SelectedStudent.Class))
                            {
                                SelectedStudent.ErrorMessage = "⚠️" + "The class you entered does not exist! Keep trying!";
                                SelectedStudent.Class = "";
                                SelectedStudent.ID -= 1;
                            } else  {
                                // Adding new student
                                Students.Add(SelectedStudent);
                                SelectedStudent = new Student();

                                // Sort students by ID
                                View = CollectionViewSource.GetDefaultView(Students);
                                View.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
                                View.Refresh();
                            }
                        }
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
                        sw.WriteLine(student.ID + ","
                            + student.Name + ","
                            + student.Address + ","
                            + student.Class + ","
                            + student.Username + ","
                            + student.Password);
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
                    string username = parts[4];
                    string password = parts[5];

                    if (Students.Any(s => s.ID == id && s.Name == name && s.Address == address && s.Class == Class && s.Username == username && s.Password == password))
                    {
                        SelectedStudent.ErrorMessage = "⚠️" + " Duplicates has been found!";
                    } else {
                        Students.Add(new Student
                        {
                            ID = int.Parse(parts[0]),
                            Name = parts[1],
                            Address = parts[2],
                            Class = parts[3],
                            Username = parts[4],
                            Password = parts[5]
                        });
                    }
                }
            } else {
                SelectedStudent.ErrorMessage = "⚠️" + " Nothing was loaded.";
            }
        }
    }
}

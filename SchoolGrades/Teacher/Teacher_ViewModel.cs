using GenericUi.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SchoolGrades.MVVM;
using SchoolGrades.MyUserController;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using SchoolGrades.Teacher;
using SchoolGrades.Student;
using System;
using Microsoft.Win32;
using System.IO;

namespace SchoolGrades.Teacher
{
    public class Teacher_ViewModel : ViewModelBase
    {
        private ObservableCollection<Teacher> _teachers = new ObservableCollection<Teacher>();
        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set
            {
                _teachers = value;
                OnPropertyChanged();
            }
        }

        private Teacher _Selected_Teacher= new Teacher();
        public Teacher SelectedTeacher
        {
            get { return _Selected_Teacher; }
            set
            {
                _Selected_Teacher = value;
                OnPropertyChanged();
            }
        }


        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand UnSelectCommand { get; }
        public ICommand SaveCommand{ get; }
        public ICommand LoadCommand { get; }



        public Teacher_ViewModel()
        {
            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((Teacher)x));
            UnSelectCommand = new RelayCommand(y => UnSelect((Teacher)y));
            SaveCommand = new RelayCommand(z => SaveToFile((Teacher)z));
            LoadCommand = new RelayCommand(v => LoadFile((Teacher)v));


            Teachers.Add(new Teacher() { First_Name = "Ex. Razvan", Last_Name = "Zavalichi", ID = 0, Username = "Razvan", Password = "123" });
            Teachers.Add(new Teacher() { First_Name = "Ex. Casian", Last_Name = "Amihaiesei", ID = 0, Username = "Casian", Password = "123" });
            Teachers.Add(new Teacher() { First_Name = "Ex. Stefi", Last_Name = "Amihaiesei", ID = 0, Username = "Stefi", Password = "123" });
            Teachers.Add(new Teacher() { First_Name = "Vasile", Last_Name = "Bordura", ID = 0, Username = "Vasile", Password = "123" });


            SelectedTeacher.TeacherCount = Teachers.Count;
        }


        public ICollectionView View;
        int lastUsedId = 0;

        private void Add()
        {
            foreach(Teacher teacher in Teachers)
            {
                if (string.IsNullOrEmpty(SelectedTeacher.First_Name) || string.IsNullOrEmpty(SelectedTeacher.Last_Name) || string.IsNullOrEmpty(SelectedTeacher.Username) || string.IsNullOrEmpty(SelectedTeacher.Password))
                {
                    SelectedTeacher.ErrorMessage = "⚠️" + " You can't leave the boxes empty!" ;
                    break;

                } else
                {
                    SelectedTeacher.ID = ++lastUsedId;
                    Teachers.Add(SelectedTeacher);
                    SelectedTeacher = new Teacher();


                    // Sort teachers by ID
                    View = CollectionViewSource.GetDefaultView(Teachers);
                    View.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
                    View.Refresh();
                }
            }
        }

        private void Delete(Teacher teacher)
        {

            if (MessageBox.Show("Are you sure you want to do this operation?", "Security question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Teacher has been removed
                Teachers.Remove(teacher);
                SelectedTeacher = new Teacher();
            }
            else
            {
                MessageBox.Show("The operation was closed! Nothing has been changed!");
            }

        }

        
        private void UnSelect(Teacher teacher)
        {
            Teacher_UserControl qwe = new Teacher_UserControl();
            qwe.DataGrid_Teachers.UnselectAllCells();
            SelectedTeacher = new Teacher();
        }


        private void SaveToFile(Teacher teacher)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var save_teachers in Teachers)
                    {
                        teacher = save_teachers;
                        sw.WriteLine(teacher.ID + ","
                            + teacher.First_Name + ","
                            + teacher.Last_Name + ","
                            + teacher.Username + ","
                            + teacher.Password);
                    }
                }
            }
            else
            {
                SelectedTeacher.ErrorMessage = "⚠️" + " Nothing was saved!";
            }

        }



        private void LoadFile(Teacher teacher)
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
                    string first_name = parts[1];
                    string last_name = parts[2];
                    string username = parts[3];
                    string password = parts[4];

                    //                         0          1                              2                               3                          4                
                    if (Teachers.Any(s => s.ID == id && s.First_Name == first_name && s.Last_Name == last_name && s.Username == username && s.Password == password))
                    {
                        SelectedTeacher.ErrorMessage = "⚠️" + " Duplicates has been found!";
                    }
                    else
                    {
                        Teachers.Add(new Teacher
                        {
                            ID = int.Parse(parts[0]),
                            First_Name = parts[1],
                            Last_Name= parts[2],
                            Username = parts[3],
                            Password = parts[4]
                        });
                    }
                }
            }
            else
            {
                SelectedTeacher.ErrorMessage = "⚠️" + " Nothing was loaded.";
            }
        }

    }
}

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


            Teachers.Add(new Teacher() { First_Name = "Ex. Razvan", Last_Name = "Zavalichi"});
            Teachers.Add(new Teacher() { First_Name = "Ex. Casian", Last_Name = "Amihaiesei" });
            Teachers.Add(new Teacher() { First_Name = "Ex. Stefi", Last_Name = "Amihaiesei"});
            Teachers.Add(new Teacher() { First_Name = "Vasile", Last_Name = "Bordura"});


            SelectedTeacher.TeacherCount = Teachers.Count;
        }


        public ICollectionView View;
        private void Add()
        {
            foreach(Teacher teacher in Teachers)
            {
                if (string.IsNullOrEmpty(SelectedTeacher.First_Name) || string.IsNullOrEmpty(SelectedTeacher.Last_Name))
                {
                    SelectedTeacher.ErrorMessage = "⚠️" + " You can't leave the boxes empty!" ;
                    break;

                } else
                {
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
                        sw.WriteLine( teacher.First_Name + ","
                            + teacher.Last_Name + ",");
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
                    string first_name = parts[0];
                    string last_name = parts[1];

                    if (Teachers.Any(s => s.First_Name == first_name && s.Last_Name == last_name))
                    {
                        SelectedTeacher.ErrorMessage = "⚠️" + " Duplicates has been found!";
                    }
                    else
                    {
                        Teachers.Add(new Teacher
                        {
                            First_Name = parts[0],
                            Last_Name= parts[1],
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

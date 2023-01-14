using GenericUi.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SchoolGrades.MVVM;
using SchoolGrades.MyUserController;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System;
using System.IO;
using Microsoft.Win32;
using SchoolGrades.Student;

namespace SchoolGrades.Classes
{
    public class ClassViewModel : ViewModelBase
    {
        private ObservableCollection<ClassModel> _classes = new ObservableCollection<ClassModel>();
        public ObservableCollection<ClassModel> Classes
        {
            get { return _classes; }
            set
            {
                _classes = value;
                OnPropertyChanged();
            }
        }

        private ClassModel _selectedClass = new ClassModel();
        public ClassModel SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand UnSelectCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }


        public ClassViewModel()
        {
            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((ClassModel)x));
            UnSelectCommand = new RelayCommand(y => UnSelect((ClassModel)y));
            SaveCommand = new RelayCommand(z => SaveToFile((ClassModel)z));
            LoadCommand = new RelayCommand(v => LoadFile((ClassModel)v));


            Classes.Add(new ClassModel() { Class_Name = "Class A", Class_Owner = "Razvan", Class_Students_Limit = 30 });
            Classes.Add(new ClassModel() { Class_Name = "Class B", Class_Owner = "Casian", Class_Students_Limit = 30 });
            Classes.Add(new ClassModel() { Class_Name = "Class C", Class_Owner = "Stefy", Class_Students_Limit = 10 });
            Classes.Add(new ClassModel() { Class_Name = "Class D", Class_Owner = "Vasile", Class_Students_Limit = 20 });
            Classes.Add(new ClassModel() { Class_Name = "Class E", Class_Owner = "Pavela", Class_Students_Limit = 29 });

            SelectedClass.ClassesCount = Classes.Count();

        }

        public ICollectionView View;
        void Add()
        {
            int i, k;
            foreach (ClassModel __class in Classes)
            {
                if (string.IsNullOrEmpty(SelectedClass.Class_Name) || string.IsNullOrEmpty(SelectedClass.Class_Owner))
                {
                    SelectedClass.ErrorMessage = "⚠️" + "You can't leave the boxes empty!";
                    break;
                }
                else
                {
                    SelectedClass.Class_Id += 1;
                    if (!Classes.Any(p => p.Class_Id == SelectedClass.Class_Id))
                    {
                        if (int.TryParse(SelectedClass.Class_Name, out i) || int.TryParse(SelectedClass.Class_Owner, out k))
                        {
                            SelectedClass.ErrorMessage = "⚠️" + "You cannot add a number as a name, subject or class! Please try again!";
                            SelectedClass.Class_Name = "";
                            SelectedClass.Class_Owner = "";
                            SelectedClass.Class_Id -= 1;
                            break;
                        }
                        else
                        {
                            // Adding new student
                            Classes.Add(SelectedClass);
                            SelectedClass = new ClassModel();

                            // Sort students by ID
                            View = CollectionViewSource.GetDefaultView(Classes);
                            View.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
                            View.Refresh();
                        }
                    } else
                    {
                        SelectedClass.ErrorMessage = "⚠️" + "Ops..The entered class does not exist!";
                    }
                }
            }
        }

        private void Delete(ClassModel __class)
        {
            if (MessageBox.Show("Are you sure you want to do this operation?", "Security question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Class has been removed
                Classes.Remove(__class);
                SelectedClass = new ClassModel();
            }
            else
            {
                MessageBox.Show("The operation was closed! Nothing has been changed!");
            }
        }

        private void UnSelect(ClassModel __class)
        {
            SelectedClass= new ClassModel();
        }



        private void LoadFile(ClassModel _class)
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
                    string Name = parts[1];
                    string Owner = parts[2];
                    var Students_Limit = int.Parse(parts[3]);
                    
                    if (Classes.Any(s => s.Class_Id == id && s.Class_Name == Name && s.Class_Owner == Owner && s.Class_Students_Limit == Students_Limit))
                    {
                        SelectedClass.ErrorMessage = "⚠️" + " Duplicates has been found!";
                    }
                    else
                    {
                        Classes.Add(new ClassModel 
                        {
                            Class_Id = int.Parse(parts[0]),
                            Class_Name = parts[1],
                            Class_Owner = parts[2],
                            Class_Students_Limit = int.Parse(parts[3]),
                            
                        });
                    }
                }
            }
            else
            {
                SelectedClass.ErrorMessage = "⚠️" + " Nothing was loaded.";
            }
        }

        private void SaveToFile(ClassModel _class)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var save_class in Classes)
                    {
                        _class = save_class;
                        sw.WriteLine(_class.Class_Id + ","
                            + _class.Class_Name + ","
                            + _class.Class_Owner + ","
                            + _class.Class_Students_Limit + ",");
                    }
                }
            }
            else
            {
                SelectedClass.ErrorMessage = "⚠️" + " Nothing was saved!";
            }
        }
    }
}
      

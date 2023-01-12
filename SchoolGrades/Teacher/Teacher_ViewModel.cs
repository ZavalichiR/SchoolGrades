﻿using GenericUi.Commands;
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


        public Teacher_ViewModel()
        {
            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((Teacher)x));
            UnSelectCommand = new RelayCommand(y => UnSelect((Teacher)y));

            Teachers.Add(new Teacher() { First_Name = "Ex. Razvan", Last_Name = "Zavalichi", ID = 0, Username = "Razvan", Password = "123" });
            Teachers.Add(new Teacher() { First_Name = "Ex. Casian", Last_Name = "Amihaiesei", ID = 0, Username = "Casian", Password = "123" });
            Teachers.Add(new Teacher() { First_Name = "Ex. Stefi", Last_Name = "Amihaiesei", ID = 0, Username = "Stefi", Password = "123" });
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
    }
}
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

namespace SchoolGrades.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public Student _editingStudent = new Student();
        public Student EditingStudent
        {
            get { return _editingStudent; }
            set
            {
                _editingStudent = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public ICommand RemoveCommand { get; }
        public ICommand AddCommand { get; }

        public StudentViewModel()
        {
            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((Student)x));

            Students.Add(new Student() { Name = "Ex. Casian", Absent = 3, Class = "A", Grade = 10, ID = 0 });
            Students.Add(new Student() { Name = "Ex. Stefi", Absent = 1, Class = "A", Grade = 10, ID = 1 });
            Students.Add(new Student() { Name = "Ex. Razvan", Absent = 2, Class = "A", Grade = 10, ID = 2 });
        }

        private void Add()
        {

            // You'll want some validation here...
            Students.Add(EditingStudent);
            EditingStudent = new Student();
            // Probably clear EditingStudent after
        }

        private void Delete(Student student)
        {
            // Students.Remove(student);

            if (MessageBox.Show("Are you sure you want to do this operation?", "Security question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Students.Remove(student);
                MessageBox.Show("Student has been removed succesfully!");

            }
            else
            {
                MessageBox.Show("The operation was closed! Nothing has been changed!");
            }
        }

        private void Update(Student student)
        {
            throw new NotImplementedException();
        }
       



    }


}

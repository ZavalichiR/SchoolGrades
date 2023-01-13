using GenericUi.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SchoolGrades.MVVM;
using SchoolGrades.MyUserController;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;

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



        public StudentViewModel()
        {

            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((Student)x));
            UnSelectCommand = new RelayCommand(y => UnSelect((Student)y));

            Students.Add(new Student() { Name = "Ex. Razvan", Address = "Geography", Class = "A", Username = "Razvan", Password = "123"});
            Students.Add(new Student() { Name = "Ex. Casian", Address = "Math", Class = "A", Username = "Casian", Password = "123" });
            Students.Add(new Student() { Name = "Ex. Stefi", Address = "History", Class = "A", Username = "Stefi", Password = "123" });

            SelectedStudent.StudentsCount = Students.Count();
        }


        public ICollectionView View;
        private void Add()
        {
            Classes.ClassViewModel qwe = new Classes.ClassViewModel();
            //int i, k, l;
            foreach (Student student in Students)
            {
                if (string.IsNullOrEmpty(SelectedStudent.Name) || string.IsNullOrEmpty(SelectedStudent.Class) || string.IsNullOrEmpty(SelectedStudent.Address))
                {
                    SelectedStudent.ErrorMessage = "⚠️" + "You can't leave the boxes empty!";
                    break;
                }
                else
                {
                    SelectedStudent.ID += 1;
                    if (SelectedStudent.ID > 0 && SelectedStudent.ID < 34)
                    {
                        if (!qwe.Classes.Any(z => z.Class_Name == SelectedStudent.Class))
                        {
                            SelectedStudent.ErrorMessage = "⚠️" +"The class you entered does not exist! Keep trying!";
                            SelectedStudent.Class = "";
                            SelectedStudent.ID -= 1;
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

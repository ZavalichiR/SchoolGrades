using GenericUi.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SchoolGrades.MVVM;
using SchoolGrades.MyUserController;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;

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


        public ClassViewModel()
        {
            AddCommand = new RelayCommand(_ => Add());
            RemoveCommand = new RelayCommand(x => Delete((ClassModel)x));
            UnSelectCommand = new RelayCommand(y => UnSelect((ClassModel)y));


            Classes.Add(new ClassModel() { Class_Name = "Class A", Class_Owner = "Razvan", Class_Students_Limit = 30 });
            Classes.Add(new ClassModel() { Class_Name = "Class B", Class_Owner = "Casian", Class_Students_Limit = 30});
            Classes.Add(new ClassModel() { Class_Name = "Class C", Class_Owner = "Stefy", Class_Students_Limit = 10});
        }

        public ICollectionView View;
        void Add()
        {
            int i, k;
            foreach (ClassModel __class in Classes)
            {
                if (string.IsNullOrEmpty(SelectedClass.Class_Name) || string.IsNullOrEmpty(SelectedClass.Class_Owner))
                {
                    MessageBox.Show("You can't leave the boxes empty!", "Error!");
                    break;
                }
                else
                {
                    SelectedClass.Class_Id += 1;
                    if (!Classes.Any(p => p.Class_Id == SelectedClass.Class_Id))
                    {
                        if (int.TryParse(SelectedClass.Class_Name, out i) || int.TryParse(SelectedClass.Class_Owner, out k))
                        {
                            MessageBox.Show("You cannot add a number as a name, subject or class! Please try again!", "Error!");
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
    }
}
      

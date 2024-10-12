using GenericUi.Commands;
using SchoolGrades.Models.School;
using SchoolGrades.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolGrades.ViewModels.Schools_ViewModels
{
    public class SchoolsViewModel : ViewModelBase
    {
        private ObservableCollection<School_Model> _schools = new ObservableCollection<School_Model>();
        public ObservableCollection<School_Model> Schools
        {
            get { return _schools; }
            set
            {
                _schools = value;
                OnPropertyChanged();
            }
        }

        private School_Model _selected_school;
        public School_Model SelectedSchool
        {
            get { return _selected_school; }
            set { _selected_school = value;
                OnPropertyChanged();
            }
        }

        #region iCommands

        public ICommand CreateSchool_Command { get; }
        public ICommand RemoveSchool_Command { get; }

        #endregion

        public SchoolsViewModel()
        {
            Schools = new ObservableCollection<School_Model>();
            SelectedSchool = new School_Model();

            CreateSchool_Command = new RelayCommand(_ => AddSchool_Method());
            RemoveSchool_Command = new RelayCommand(_ => RemoveSchool_Method());
        }

        private void AddSchool_Method()
        {
            var newSchool = new School_Model
            {
                SchoolName = SelectedSchool.SchoolName,
                SecurityCode = SelectedSchool.SecurityCode,
            };
            Schools.Add(newSchool);
        }

        private void RemoveSchool_Method()
        {
            throw new NotImplementedException();
        }
    }
}

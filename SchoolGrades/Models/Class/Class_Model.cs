using SchoolGrades.MVVM;

namespace SchoolGrades.Models.Class
{
    public class Class_Model : ViewModelBase
    {

        private int _classescount;
        public int ClassesCount
        {
            get { return _classescount; }
            set
            {
                _classescount = value;
                OnPropertyChanged();
            }
        }


        private string _error_message;
        public string ErrorMessage
        {
            get { return _error_message; }
            set
            {
                _error_message = value;
                OnPropertyChanged();
            }
        }


        private string _name;
        public string Class_Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _class_owner;
        public string Class_Owner
        {
            get { return _class_owner; }
            set
            {
                _class_owner = value;
                OnPropertyChanged();
            }
        }

        private int? _class_students_limit;
        public int?  Class_Students_Limit
        {
            get { return _class_students_limit; }
            set
            {
                _class_students_limit = value;
                OnPropertyChanged();
            }
        }
    }
}

using SchoolGrades.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolGrades.Models.User
{
    public class User_Model : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        private string _user_type;
        public string User_Type
        {
            get { return _user_type; }
            set
            {
                _user_type = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string FullName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

    }
}

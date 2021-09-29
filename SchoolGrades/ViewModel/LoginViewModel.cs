using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using System.Security;


namespace SchoolGrades.MVVM
{
    public class LoginViewModel : ViewModelBase
    {
        // failed login attempt
        private bool _loginFailed;
        public bool LoginFailed
        {
            get { return _loginFailed; }
            set
            {
                _loginFailed = value;
                OnPropertyChanged("Login Failed");
            }
        }
        // constructor
        public LoginViewModel()
        { }
        // error message to be displayed
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged("Error Message");
                }
            }
        }

        // specified username and password

        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                {
                    if (!string.Equals(value.ToString(), _username, StringComparison.OrdinalIgnoreCase))
                    {
                        _username = value;
                        OnPropertyChanged("Username");
                    }
                }
            }
        }

        private SecureString _password;
        public SecureString PasswordSecureString
        {
            get { return _password; }
            set
            {
                if (value != null)
                {
                    _password = value;
                    OnPropertyChanged("Passowrd");
                }
            }
        }
    }

}

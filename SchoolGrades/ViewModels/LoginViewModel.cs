using GenericUi.Commands;
using SchoolGrades.MVVM;
using System;
using System.Security;
using System.Windows.Input;
using System.Windows;

namespace SchoolGrades.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // LoginPasswordViewModel
        #region Attributes

        private bool _loginFailed;
        public bool LoginFailed
        {
            get => _loginFailed;
            set
            {
                _loginFailed = value;
                OnPropertyChanged("Login Failed");
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged("Error Message");
                }
            }
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                if (!string.Equals(value.ToString(), _userName, StringComparison.OrdinalIgnoreCase))
                {
                    _userName = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        private SecureString _password;
        public SecureString PasswordSecureString
        {
            get => _password;
            set
            {
                if (value != null)
                {
                    _password = value;
                    OnPropertyChanged("Passowrd");
                }
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; }


        #endregion

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
        }

        #region Private Methods

        private void Login()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region PasswordViewModel
        public class ResetPasswordViewModel : ViewModelBase
        {
            #region Command
            public ICommand ResetPasswordCommand { get; }
            #endregion

            public ResetPasswordViewModel()
            {
                ResetPasswordCommand = new RelayCommand(_ => ResetPassword());
            }

            #region Private Methods
            private void ResetPassword()
            {
                throw new NotImplementedException();
            }
            #endregion
            #endregion
        }
    }
}
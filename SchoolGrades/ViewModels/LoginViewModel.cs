using GenericUi.Commands;
using SchoolGrades.MVVM;
using System;
using System.Windows;
using System.Windows.Input;
using SchoolGrades.Views;
using System.Collections.Generic;
using System.Windows.Media;

namespace SchoolGrades.ViewModels
{

    public class LoginViewModel : ViewModelBase
    {
        #region Login Credentials

        private Dictionary<string, string> _userPasswords;
        public Dictionary<string, string> UserPasswords
        {
            get { return _userPasswords; }
            set
            {
                _userPasswords = value;
                OnPropertyChanged();
            }
        }

        private string _userName;
        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _newPassword;
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }


        private string _Error_Message_login;
        public string ErrorMessage_Login
        {
            get { return _Error_Message_login; }
            set
            {
                _Error_Message_login = value;
                OnPropertyChanged();
            }
        }

        private string _Error_Message_reset;
        public string ErrorMessage_Reset
        {
            get { return _Error_Message_reset; }
            set
            {
                _Error_Message_reset = value;
                OnPropertyChanged();
            }
        }

        private string _succesMessage;
        public string SuccesMessage
        {
            get { return _succesMessage; }
            set
            {
                _succesMessage = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Commands

        public ICommand LoginCommand { get; }
        public ICommand ResetPasswordCommand { get; }

        #endregion

        public LoginViewModel()
        {
            UserPasswords = new Dictionary<string, string>()
            {
                {"student", "password" },
                {"student1", "password" },
                {"student2", "password" },
                {"teacher", "password" }
            };


            LoginCommand = new RelayCommand(_ => Login());
            ResetPasswordCommand = new RelayCommand(_ => Reset(), _ => !string.IsNullOrEmpty(NewPassword));
        }

        #region Private Methods


        private void Login()
        {
            ApplicationMainWindow nw = new ApplicationMainWindow();
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                ErrorMessage_Login = "⚠️" + "Complete the fields!";
            }
            else
            {
                if (UserPasswords.ContainsKey(Username) && UserPasswords[Username] == Password)
                {
                    nw.Show();
                    Application.Current.MainWindow.Hide();
                    Username = "";
                    Password = "";
                }
                else
                {
                    ErrorMessage_Login = "⚠️" + "Username or password is invalid";
                    Username = "";
                    Password = "";
                }
            }
        }


        private void Reset()
        {
            if (UserPasswords.ContainsKey(Username))
            {
                if (UserPasswords[Username] == Password)
                {
                    UserPasswords[Username] = NewPassword;

                    //Display success message
                    ErrorMessage_Reset = "";
                    SuccesMessage = "⚠️" + "Password has been changed!";
                    
                }
                else
                {
                    //Display error message
                    SuccesMessage = "";
                    ErrorMessage_Reset = "⚠️" + "Wrong old password";
                }
            }
            else
            {
                SuccesMessage = "";
                ErrorMessage_Reset = "⚠️ " + "This account does not exist.";
            }
        }
        #endregion
    }
}
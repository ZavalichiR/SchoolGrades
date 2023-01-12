    using GenericUi.Commands;
using SchoolGrades.MVVM;
using System;
using System.Windows;
using System.Windows.Input;
using SchoolGrades.Views;
using System.Collections.Generic;

namespace SchoolGrades.ViewModels
{

    public class LoginViewModel : ViewModelBase 
    {
        #region Login Credentials

        

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
            set { _password = value;
            OnPropertyChanged();}
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
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
            LoginCommand = new RelayCommand(_ => Login());
            ResetPasswordCommand = new RelayCommand(_ => Reset());
        }

        #region Private Methods
        

        private void Login()
        {
            ApplicationMainWindow nw = new ApplicationMainWindow();
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "⚠️" + "Username or password can't be null!";
            } else
            {
                if (Username == "student" && Password == "password")
                {
                    nw.Show();
                    Application.Current.MainWindow.Hide();
                    Username = "";
                    Password = "";
                }
                else
                {
                    ErrorMessage = "⚠️" + "Username or password is invalid";
                    Username = "";
                    Password = "";
                }
            }
        }
        private void Reset()
        {
            throw  new NotImplementedException();
        }
        #endregion
    }
}
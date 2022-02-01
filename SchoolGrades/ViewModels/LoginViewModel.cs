﻿using GenericUi.Commands;
using SchoolGrades.MVVM;
using System;
using System.Windows;
using System.Windows.Input;
using SchoolGrades.Views;

namespace SchoolGrades.ViewModels
{

    public class LoginViewModel : ViewModelBase 
    {
        #region Login Credentials

        public string Error { get { return null; } }



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
            
            if (Username == "student" && Password == "password")
            {
                AppMainWindow nw = new AppMainWindow();
                nw.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password! Retry!");
            }
        }
        private void Reset()
        {
            throw  new NotImplementedException();
        }
        #endregion
    }
}
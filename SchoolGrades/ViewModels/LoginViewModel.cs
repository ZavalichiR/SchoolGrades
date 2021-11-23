using GenericUi.Commands;
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
        public string Username { get; set; }
        public string Password { get; set; }

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
            
            if (Username == "student" && Password == "password") {
                AppMainWindow nw = new AppMainWindow();
                nw.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorect!");
            }
        }
        private void Reset()
        {
            throw  new NotImplementedException();
        }
        #endregion
    }
}
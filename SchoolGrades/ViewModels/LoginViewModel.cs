using GenericUi.Commands;
using SchoolGrades.MVVM;
using System;
using System.Windows.Input;
using static SchoolGrades.Views.SecondWindow;
namespace SchoolGrades.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region ErrorText Message
        public string ErrorText { get; set; }
        #endregion

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

        public void Login()
        {
            if(Username == "student" && Password == "password")
            {
                NewWindow();
                ErrorText = "Connection successful!";
            } else
            {
                ErrorText = "Username or password is incorrect!";
            }
        }
        private void Reset()
        {
            throw new NotImplementedException();
            /*...Some Code*/
        }

        #endregion
    }
}
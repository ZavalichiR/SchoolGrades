using GenericUi.Commands;
using SchoolGrades.MVVM;
using System;
using System.Windows.Input;

namespace SchoolGrades.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
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
            throw new NotImplementedException();
        }
        private void Reset()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
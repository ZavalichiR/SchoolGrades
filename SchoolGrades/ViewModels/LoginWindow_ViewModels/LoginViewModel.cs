    using GenericUi.Commands;
using SchoolGrades.Models.User;
using SchoolGrades.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolGrades.Views;
using System.Diagnostics;
using System.Windows;
using SchoolGrades.Models.Student;
using SchoolGrades.Models.School;

namespace SchoolGrades.ViewModels.LoginWindow_ViewModels
{

    public class LoginViewModel : ViewModelBase
    {
        public ObservableCollection <School_Model> Schools = new ObservableCollection<School_Model>();
        private ObservableCollection<User_Model> _user = new ObservableCollection<User_Model>();
        public ObservableCollection<User_Model> Users
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }


        private User_Model _selected_user;
        public User_Model User
        {
            get { return _selected_user; }
            set
            {
                _selected_user = value;
                OnPropertyChanged();
            }
        }

        #region iCommands
        // < content for iCommands >
        public ICommand Register_Command { get; }
        public ICommand Login_Command { get; }

        #endregion

        public LoginViewModel()
        {
            Users = new ObservableCollection<User_Model>();
            User = new User_Model();
            Register_Command = new RelayCommand(_ => DoRegister_Method());
            Login_Command = new RelayCommand(_ => DoLogin_Method());
        }

        private void DoLogin_Method()
        {
            AppMainWindow mainWindow = new AppMainWindow();
            if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password))
            {
                MessageBox.Show("Sorry, username or password is empty");
                return;
            }
            var found_user = Users.FirstOrDefault(u => u.Username == User.Username && u.Password == User.Password);
            if (found_user != null)
            {
                if (found_user.User_Type == "student")
                {
                    mainWindow.Show();
                    mainWindow.Load_DashboardUserController();
                }
                else if (found_user.User_Type == "teacher")
                {
                    // content for teacher
                }
                else if (found_user.User_Type == "admin")
                {
                    // content to open for admin
                }
            }
            else
            {
                MessageBox.Show("Username or password incorrect");
                return;
            }

        }

        private void DoRegister_Method()
        {
            if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password))
            {
                MessageBox.Show("Sorry, username or password is empty");
                return;
            }
            var foundUsername = Users.FirstOrDefault(u => u.Username == User.Username);
            if (foundUsername != null)
            {
                MessageBox.Show("This user already exist");
            }
            else
            {

                var new_user = new Student_Model()
                {
                    FullName = User.FullName,
                    Username = User.Username,
                    Password = User.Password,
                    User_Type = "student"
                };

                Users.Add(new_user);
                MessageBox.Show($"{User.Username} has been created");
            }

        }

    }

}

using SchoolGrades.Views;
using System.Windows;

namespace SchoolGrades
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private object DataContext;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            this.DataContext = this.Resources["loginViewModel"];
        }
    }
}

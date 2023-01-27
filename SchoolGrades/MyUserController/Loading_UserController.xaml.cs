using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolGrades.ViewModels;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Loading_UserController.xaml
    /// </summary>
    public partial class Loading_UserController : UserControl
    {
        public Loading_UserController()
        {
            InitializeComponent();
            BitmapImage gif = new BitmapImage();
            gif.BeginInit();
            gif.UriSource = new Uri("https://i.imgur.com/P4IQCuj.gif");
            gif.EndInit();
            loadingGif.Source = gif;
            this.Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadingGif.Visibility = Visibility.Visible;
            loadingGif.BeginAnimation(Image.OpacityProperty, new DoubleAnimation(1, TimeSpan.FromSeconds(1)) { RepeatBehavior = RepeatBehavior.Forever });
        }
    }
}

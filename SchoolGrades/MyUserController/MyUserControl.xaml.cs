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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        public static readonly DependencyProperty MyContentProperty =
        DependencyProperty.Register("MyContent", typeof(object), typeof(MyUserControl));

        public MyUserControl()
        {
            InitializeComponent();
        }
        public object MyContent
        {
            get { return GetValue(MyContentProperty); }
            set { SetValue(MyContentProperty, value); }
        }
    }
}

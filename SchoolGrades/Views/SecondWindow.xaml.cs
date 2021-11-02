using SchoolGrades.ViewModels;
using MaterialDesignThemes.Wpf;
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

namespace SchoolGrades.Views
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Class A1"));
            menuRegister.Add(new SubItem("Class A2"));
            menuRegister.Add(new SubItem("Class A3"));
            menuRegister.Add(new SubItem("Class A4"));
            var item6 = new ItemMenu("School name 1", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Class A1"));
            menuSchedule.Add(new SubItem("Class A2"));
            var item1 = new ItemMenu("School name 2", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Class A1"));
            menuReports.Add(new SubItem("Class A2"));
            menuReports.Add(new SubItem("Class D3"));
            var item2 = new ItemMenu("School name 3", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Class A1"));
            menuExpenses.Add(new SubItem("Class B2"));
            var item3 = new ItemMenu("School name 4", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Class A1"));
            menuFinancial.Add(new SubItem("Class C1"));
            var item4 = new ItemMenu("School name 5", menuFinancial, PackIconKind.ScaleBalance);

            var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlItem(item0));
            Menu.Children.Add(new UserControlItem(item6));
            Menu.Children.Add(new UserControlItem(item1));
            Menu.Children.Add(new UserControlItem(item2));
            Menu.Children.Add(new UserControlItem(item3));
            Menu.Children.Add(new UserControlItem(item4));

        }

        #region NewWindow Method
        public static void NewWindow()
        {
            SecondWindow nw = new SecondWindow();
            nw.Show();
        }
        #endregion
    }
}

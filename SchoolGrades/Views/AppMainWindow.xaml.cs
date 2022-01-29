using SchoolGrades.Models;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;

namespace SchoolGrades.Views
{
    public partial class AppMainWindow : Window
    {
        public AppMainWindow()
        {
            InitializeComponent();

            var DashBoard = new List<SubItem>();
            DashBoard.Add(new SubItem("Students list", new UserControlDashBoard()));
            var item0_1 = new ItemMenu("DashBoard", DashBoard, PackIconKind.ViewDashboard);

            var SchoolName1 = new List<SubItem>();
            SchoolName1.Add(new SubItem("Class A", new UserControlClass_A()));
            SchoolName1.Add(new SubItem("Class B", new UserControlClass_B()));
            var item0 = new ItemMenu("SchoolName 1", SchoolName1, PackIconKind.School);

            var SchoolName2 = new List<SubItem>();
            SchoolName2.Add(new SubItem("Class C", new UserControlClass_C()));
            SchoolName2.Add(new SubItem("Class D", new UserControlClass_D()));
            var item1 = new ItemMenu("SchoolName 2", SchoolName2, PackIconKind.School);

            var SchoolName3 = new List<SubItem>();
            SchoolName3.Add(new SubItem("Class E", new UserControlClass_E()));
            SchoolName3.Add(new SubItem("Class F", new UserControlClass_F()));
            var item2 = new ItemMenu("SchoolName 3", SchoolName3, PackIconKind.School);


            Menu.Children.Add(new UserControlMenuItem(item0_1, this));
            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if(screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            
           if(BtnMenu.IsChecked == true)
            {
                BtnMenu.Visibility = Visibility.Visible;
                ScrollViewerMenu.Visibility = Visibility.Collapsed;
                Avatar.Visibility = Visibility.Collapsed;
                Frame.Visibility = Visibility.Collapsed;
                text_Student_Name.Visibility = Visibility.Collapsed;
                ColumnMenu.Width = new GridLength(45);

            } else
            {
                BtnMenu.Visibility = Visibility.Visible;
                ScrollViewerMenu.Visibility = Visibility.Visible;
                Avatar.Visibility = Visibility.Visible;
                Frame.Visibility = Visibility.Visible;
                text_Student_Name.Visibility = Visibility.Visible;
                ColumnMenu.Width = new GridLength(250);
            }
        }

    }
}

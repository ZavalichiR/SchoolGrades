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
using System.Data;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            fillingDataGridUsingTable();
        }

        void fillingDataGridUsingTable()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("id", typeof(int));
            DataColumn name = new DataColumn("name", typeof(string));
            DataColumn phone = new DataColumn("phone", typeof(string));
            DataColumn email = new DataColumn("email", typeof(string));
            DataColumn address = new DataColumn("address", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(name);
            dt.Columns.Add(phone);
            dt.Columns.Add(email);
            dt.Columns.Add(address);

            DataRow firstRow = dt.NewRow();
            firstRow[0] = 1;
            firstRow[1] = "Vasile Bordura";
            firstRow[2] = "07532525414";
            firstRow[3] = "vasile_bordura@gmail.com";
            firstRow[4] = "Bulevardul Talpa Iute";

            DataRow secondRow = dt.NewRow();
            secondRow[0] = 2;
            secondRow[1] = "Ion Pavela";
            secondRow[2] = "073251541";
            secondRow[3] = "pavela@gmail.com";
            secondRow[4] = "Bulevardul 22 Decembrie";


            dt.Rows.Add(firstRow);
            dt.Rows.Add(secondRow);

            MyDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}

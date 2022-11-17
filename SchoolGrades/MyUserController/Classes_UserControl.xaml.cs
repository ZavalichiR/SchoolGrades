﻿using System;
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
using SchoolGrades.Views;
using SchoolGrades.Classes;

namespace SchoolGrades.MyUserController
{
    /// <summary>
    /// Interaction logic for Classes_UserControl.xaml
    /// </summary>
    public partial class Classes_UserControl : UserControl
    {
        public Classes_UserControl()
        {
            InitializeComponent();
            ClassViewModel abc = new ClassViewModel();
            DataContext = abc;
        }

    }
}

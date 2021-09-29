using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SchoolGrades.MVVM
{
    class PasswordBoxMVVM
    {
        public class CommonBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _247vietTool.Models
{
    public class FlashTest : INotifyPropertyChanged
    {
        private String url = "http://12diamondclub.mos555.com/intro.aspx";

        public String Url
        {
            get { return url; }
            set 
            {
                url = value;
                OnNotifyPropertyChanged("Url");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}

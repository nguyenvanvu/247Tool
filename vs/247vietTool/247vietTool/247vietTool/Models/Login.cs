using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _247vietTool.Models
{
    public class Login : INotifyPropertyChanged
    {
        private String _UserName = "";

        public String UserName
        {
            get { return _UserName; }
            set 
            {
                _UserName = value;
                OnNotifyPropertyChanged("UserName");
            }
        }

        private String _PassWord = "";

        public String PassWord
        {
            get { return _PassWord; }
            set 
            {    
                _PassWord = value;
                OnNotifyPropertyChanged("PassWord");
            }
        }

        private String _Code = "";

        public String Code
        {
            get { return _Code; }
            set 
            {
                _Code = value;
                OnNotifyPropertyChanged("Code");
            }
        }

        private Boolean _IsLogin = false;

        public Boolean IsLogin
        {
            get { return _IsLogin; }
            set 
            {
                _IsLogin = value;
                OnNotifyPropertyChanged("IsLogin");
            }
        }

        private Boolean _IsRoot = false;

        public Boolean IsRoot
        {
            get { return _IsRoot; }
            set 
            {
                _IsRoot = value;
                OnNotifyPropertyChanged("IsRoot");
            }
        }


        private String _Success = "";

        public String Success
        {
            get { return _Success; }
            set 
            {
                _Success = value;
                OnNotifyPropertyChanged("Success");
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

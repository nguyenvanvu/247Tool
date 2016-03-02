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


using Selenium;
using OpenQA.Selenium;

using FlashSelenium;
using OpenQA.Selenium.Remote;
using System.ComponentModel;
using System.Threading;

using AutoIt;
using System.IO;
using OpenQA.Selenium.Support.UI;
using _247vietTool.Models;
using System.Collections.ObjectModel;


namespace _247vietTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const String URL = "http://www.247viet.com/index.aspx";
        private const String URL_LOGIN = "http://www.247viet.com/head.aspx";
        private const String URL_CHECKLOGIN = "http://www.247viet.com/head_logon.aspx";
        private const String URL_CASINO = "http://www.247viet.com/GL_index.aspx?htmlpage=diamond.html";

        private const String CAPTCHA_ID = "ValidationPic";
        private const String USERNAME_ID = "txtID";
        private const String PASSWORD_ID = "txtPW";
        private const String CODE_ID = "txtCode";
        private const String WELCOME_ID = "welcome";

        private ObservableCollection<Login> _LoginCollection = new ObservableCollection<Login>();

        public ObservableCollection<Login> LoginCollection
        {
            get 
            {
                return _LoginCollection; 
            }
            set 
            { 
                _LoginCollection = value;
                OnNotifyPropertyChanged("LoginCollection");
            }
        } 

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            LoginCollection.Add(new Login { UserName = "mr.vunguyen.it",PassWord = "vunguyen"});
            LoginCollection.Add(new Login { UserName = "niceguymissyou", PassWord = "vunguyen" });
            

            //AutoItX.Run("notepad",null);
        }


      
      

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

       

      

       
    };


}



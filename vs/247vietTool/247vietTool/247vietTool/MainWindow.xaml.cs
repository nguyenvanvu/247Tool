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
using System.Diagnostics;


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

        private Process process;

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
            this.Closed += MainWindow_Closed;
           
           

        }
        Boolean isClose = false;

        void MainWindow_Closed(object sender, EventArgs e)
        {
            isClose = true;
            process.Kill();
            
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            this.lstBoxLogin.MouseMove += lstBoxLogin_MouseMove;

            LoginCollection.Add(new Login { UserName = "mr.vunguyen.it",PassWord = "vunguyen", IsRoot = true});

            process = new Process();
            process.StartInfo.FileName = "test.exe";
            // process.StartInfo.Arguments = "[arguments here]";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_Exited);
            process.Start();
        }

        void process_Exited(object sender, EventArgs e)
        {
            if (!isClose)           
                process.Start();

        }



        void lstBoxLogin_MouseMove(object sender, MouseEventArgs e)
        {
            this.lstBoxLogin.SelectedItem = sender;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void btnAddAcount_Click(object sender, RoutedEventArgs e)
        {
            LoginCollection.Add(new Login());
        }

       

      

       
    };


}



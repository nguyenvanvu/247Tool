using _247vietTool.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _247vietTool
{
    /// <summary>
    /// Interaction logic for AccountItem.xaml
    /// </summary>
    public partial class AccountItem : UserControl, INotifyPropertyChanged
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

        private OpenQA.Selenium.Chrome.ChromeDriver driver;
        private IJavaScriptExecutor js;

        private Login _Login = new Login();
        public Login Login
        {
            get { return _Login; }
            set
            {
                _Login = value;
                OnNotifyPropertyChanged("Login");
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

        public AccountItem()
        {
            InitializeComponent();
            
            this.Loaded += AccountItem_Loaded;
        }

        void AccountItem_Loaded(object sender, RoutedEventArgs e)
        {
            //this.DataContext = this.Login;
            this.Login = this.DataContext as Login;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            driver = new ChromeDriver(driverService, new ChromeOptions());
            driver.Navigate().GoToUrl(URL);
            SyncUILogin();


        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!Login.IsLogin)
                {
                    //vao game
                    driver.FindElement(By.Id(USERNAME_ID)).SendKeys(Login.UserName);
                    driver.FindElement(By.Id(PASSWORD_ID)).SendKeys(Login.PassWord);
                    driver.FindElement(By.Id(CODE_ID)).SendKeys(Login.Code);

                    string title = (string)js.ExecuteScript("callSubmit();");

                    if (!CheckLogin())
                    {
                        Login.IsLogin = false;
                        driver.SwitchTo().Alert().Accept();
                        SyncUILogin();

                    }
                    else
                    {
                        Login.IsLogin = true;
                        RunBaccarat();
                    }
                }
                else
                {
                    
                    if (driver.WindowHandles.Count > 1)
                    {
                        driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
                    }

                    //thoat game
                    driver.SwitchTo().Window(driver.WindowHandles.First());
                    driver.Navigate().GoToUrl(URL_LOGIN);
                    string title = (string)js.ExecuteScript("DoLogout();");
                    Login.IsLogin = false;
                    Login.Success = "";

                    driver.Navigate().GoToUrl(URL);         
                    SyncUILogin();                   
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login.IsLogin = false;
                driver.Navigate().GoToUrl(URL_LOGIN);
                string title = (string)js.ExecuteScript("DoLogout();");
                Login.Success = "";
                SyncUILogin();

            }
            catch (Exception ex)
            {

            }

        }

        private bool CheckLogin()
        {
            driver.Navigate().GoToUrl(URL_CHECKLOGIN);

            try
            {
                Login.Success = driver.FindElement(By.Id(WELCOME_ID)).Text;
                if (!Login.Success.Equals(""))
                {
                    Login.IsLogin = true;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;

            }
            return false;

        }

        private void SyncUILogin()
        {
            driver.Navigate().GoToUrl(URL_LOGIN);
            js = driver as IJavaScriptExecutor;
            
            var arrScreen = driver.GetScreenshot().AsByteArray;
            using (var msScreen = new MemoryStream(arrScreen))
            {
                var bmpScreen = new System.Drawing.Bitmap(msScreen);
                var cap = driver.FindElement(By.Id(CAPTCHA_ID));
                var rcCrop = new System.Drawing.Rectangle(cap.Location, cap.Size);
                System.Drawing.Image imgCap = bmpScreen.Clone(rcCrop, bmpScreen.PixelFormat);

                using (var msCaptcha = new MemoryStream())
                {
                    MemoryStream memory = new MemoryStream();
                    imgCap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    imgCaptcha.Source = bitmapImage;
                }



            }
        }

        private void btnRefreshCaptcha_Click(object sender, RoutedEventArgs e)
        {
            SyncUILogin();
        }

        private void btnRunGame_Click(object sender, RoutedEventArgs e)
        {
            RunBaccarat();
        }

        private void RunBaccarat()
        {
            try
            {
                driver.Navigate().GoToUrl(URL_CASINO);
                js = driver as IJavaScriptExecutor;
                string title = (string)js.ExecuteScript("DiamondINSTANTPLAY();");
            }
            catch (Exception ex)
            {


            }

         
            var windowIds = driver.WindowHandles;

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(driver.Url + "?gc=2d");
            js = driver as IJavaScriptExecutor;
            if (this.Login.IsRoot)
                js.ExecuteScript("document.title = '12BET - Tai Khoan Chinh';");

            driver.SwitchTo().Window(driver.WindowHandles.First());

        }
    }
}

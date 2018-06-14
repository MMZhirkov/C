using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Threading;
using System.IO;
using System.Xml;

namespace InstaBot
{
    public partial class Form1 : Form
    {
        List<string> Tags = new List<string>(){};
        int likes = 0;
        string lastUrl;
        IWebDriver Browser;
        public Form1()
        {
            InitializeComponent();
            FindTags();
            Login();
            //revision
            //1 work for tag
            //2 like menee 200
            //3 video prosmotr
            //не убирать like
        }
        public void FindTags()
        {
            string pathConfig =Path.Combine(Environment.CurrentDirectory, "Tags.config");

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(pathConfig);
                XmlElement Root = xDoc.DocumentElement;
                foreach (XmlNode xnode in Root)
                {
                    string[] tags = xnode.InnerText.Split(',');
                    foreach (string tag in tags)
                    {
                        Tags.Add(tag.Replace("\"","").Replace(" ",""));
                    }
                }
            }
            catch (Exception Error)
            {

                throw;
            }
            
        }
        public void Login() {
            string currentUrl;
            string username = null;
            string password = null;

            string pathConfig = Path.Combine(Environment.CurrentDirectory, "Login.config");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pathConfig);
            XmlElement Root = xDoc.DocumentElement;
            foreach (XmlNode xnode in Root)
            {
                if (xnode.Name == "login")
                {
                    username = xnode.InnerText.Replace(" ","").Replace("\"", "");
                }
                if (xnode.Name == "password")
                {
                    password = xnode.InnerText.Replace(" ", "").Replace("\"", "");
                }
            }




            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            Delay(2000, 4000);
            IWebElement SearchLogin = Browser.FindElement(By.Name("username"));
            SearchLogin.SendKeys(username);
            IWebElement SearchPassword = Browser.FindElement(By.Name("password"));
        
            SearchPassword.SendKeys(password);
            Delay(1000, 2000);
            SearchPassword.SendKeys(OpenQA.Selenium.Keys.Enter);
            Delay(5000, 9000);

            currentUrl = Browser.Url;
            if (currentUrl == "https://www.instagram.com/#reactivated")
            {
                IWebElement seachDontNow = Browser.FindElement(By.LinkText("Не сейчас"));
                seachDontNow.Click();
                Delay(3000, 9000);
            }
            //Enter Tag in finder
            foreach (string tag in Tags)
            {
                try
                {
                IWebElement SearchFinder = Browser.FindElement(By.XPath("//section/nav/div[2]/div/div/div[2]/input"));
                    if (SearchFinder.Text=="")
                    {
                        SearchFinder.SendKeys(tag);
                    }
                    else
                    {
                        SearchFinder.Clear();
                    }
                    Delay(2000, 3000);
                    IWebElement SearchFirstTag = Browser.FindElement(By.XPath("//section/nav/div[2]/div/div/div[2]/div[2]/div[2]/div/a[1]"));
                    SearchFirstTag.Click();
                    Delay(3000, 5000);
                    //Search,choose first images rand of 10-12
                    IWebElement SearchImages = Browser.FindElement(By.XPath("//section/main/article/div[2]/div/div[1]/div[1]/a"));
                    Random imgChange = new Random();
                    int iC = imgChange.Next(9, 12);
                    SearchImages.Click();
                    
                    Delay(5000, 9000);
                    Liker();
                    Browser.Navigate().GoToUrl("https://www.instagram.com/");
                    likes = 0;
                    Delay(600000, 700000);


                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "log.txt");
                    string logMessage= tag + "Success";
                    FileStream sslns = new FileStream(path, FileMode.OpenOrCreate);
                    StreamWriter ss = new StreamWriter(sslns);
                    ss.Write(logMessage);
                    ss.Close();
                    sslns.Close();
                }
                catch (Exception exc)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "log.txt");
                    FileStream sslns = new FileStream(path, FileMode.OpenOrCreate);
                    StreamWriter ss = new StreamWriter(sslns);
                    ss.Write(exc.Message + DateTime.Now);
                    ss.Close();
                    sslns.Close();
                }
            }
            
           
        }
        public void Liker()
        {

            if (likes < 100)
            {
                IWebElement countLike = null;
                try
                {
                     countLike = Browser.FindElement(By.XPath("//section[2]/div/a/span"));
                }
                catch (Exception exc)
                {

                }

                if (countLike==null)
                    {
                    IWebElement SearchNextImg1 ;
                    try
                    {
                        SearchNextImg1 = Browser.FindElement(By.LinkText("Далее"));
                        SearchNextImg1.Click();
                        Delay(2000, 5000);
                        Liker();
                    }
                    catch (Exception)
                    {
                        if (lastUrl!= Browser.Url)
                        {
                            Browser.Navigate().GoToUrl(lastUrl);
                            Delay(2000, 5000);
                        }
                    }
                }
                else
                    {
                        if (int.Parse(countLike.Text.Replace(" ","")) > 199)
                            {
                                IWebElement SearchNextImg1 = Browser.FindElement(By.LinkText("Далее"));
                                SearchNextImg1.Click();
                                Liker();
                            }
                        else if (int.Parse(countLike.Text) < 200)
                            {
                                //probability = 40 %
                                Random r = new Random();
                                var p = r.Next(1, 10);
                                if (p < 5)
                                {
                                    //Seach button "like",click
                                    IWebElement SearchLike = Browser.FindElement(By.XPath("//article//div/section/a"));
                                    SearchLike.Click();
                                    lastUrl = Browser.Url;
                                    likes++;
                                    Delay(2000, 5000);
                                    Liker();
                                }
                                else
                                {

                            //если нету далее пропиши
                                    IWebElement SearchNextImg1 = Browser.FindElement(By.LinkText("Далее"));
                                    SearchNextImg1.Click();
                                    Delay(2000, 5000);
                                    Liker();
                                }
                            }
                        else
                            {
                                var urlError = Browser.Url;
                            }
                }
            }
            else
            {
                Application.Exit();
            }
        }
        public void Delay(int Time1, int Time2)
        {
            Random timeRandom = new Random();
            int tR = timeRandom.Next(Time1, Time2);
            System.Threading.Thread.Sleep(tR);
        }                                                       //Delay vs filter insta bots

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
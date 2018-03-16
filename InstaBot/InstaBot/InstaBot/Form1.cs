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
using NLog; 
using NLog.Config;
using System.Threading;

namespace InstaBot
{
    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        List<string> Tags = new List<string>();
        


        IWebDriver Browser;
        public Form1()
        {
            InitializeComponent();
            Login();


            Tags.Add("2");
            //revision
            //1 work for tag
            //2 like menee 200
            //3 video prosmotr
        }
        public void Login() {
            string currentUrl;
            //pass authorization
            logger.Info("login");
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            IWebElement SearchLogin = Browser.FindElement(By.Name("username"));
            SearchLogin.SendKeys("mmzhirkov@yandex.ru");
            IWebElement SearchPassword = Browser.FindElement(By.Name("password"));
            SearchPassword.SendKeys("7394Piter" + OpenQA.Selenium.Keys.Enter);
            Delay(5000, 9000);

            currentUrl = Browser.Url;
            if (currentUrl == "https://www.instagram.com/#reactivated")
            {
                IWebElement seachDontNow = Browser.FindElement(By.LinkText("Не сейчас"));
                seachDontNow.Click();
                Delay(3000, 9000);
            }
            //go tag element explore,click 
            Browser.Navigate().GoToUrl("https://www.instagram.com/explore/tags/триатлон/");
           
            //IWebElement SearchExplore = Browser.FindElement(By.LinkText("Найти людей"));
            //SearchExplore.Click();
            //Random delay 5-9 sec
            Random time2 = new Random();
            int t2 = time2.Next(3000, 9000);
            System.Threading.Thread.Sleep(t2);
            //Search,choose images rand of 6
            List<IWebElement> SearchImages = Browser.FindElements(By.XPath("//div[@class='_havey']/div/div/a")).ToList();
            Random imgChange = new Random();
            int iC = imgChange.Next(0, 5);
            SearchImages[iC].Click();
            logger.Info("first like");
            Delay(5000, 35000);
            Liker();
        }
        public void Liker()
        {
            logger.Info("start Liker");
            int summLikes = 0;
            Random likeRandom = new Random();
            int lR = likeRandom.Next(20, 30);
            try
            {

                for (int i = 0; i < 160; i++)//159 review max
                {
                    if (summLikes < 30)
                    {
                        //probability = 40 %
                        Random r = new Random();
                        var p = r.Next(1, 10);
                        if (p < 5)
                        {
                            //Seach button "like",click
                            List<IWebElement> SearchLike = Browser.FindElements(By.XPath("//article//div/section/a")).ToList();
                            SearchLike[0].Click();
                            Delay(2000, 5000);
                            summLikes++;
                            logger.Info("summLikes = {0}", summLikes);
                        }
                        else
                        {
                            logger.Info("not like = ", summLikes);
                        }
                        IWebElement SearchNextImg = Browser.FindElement(By.LinkText("Далее"));
                        SearchNextImg.Click();
                        Delay(7000, 22000);
                    }
                    else
                    {
                        i = 160;
                        logger.Info("Liker finish");
                    }
                }
                
            }
            catch (Exception exc)
            {
                logger.Error(exc.Message);
                throw;
            }
        }
        public void Delay(int Time1, int Time2)
        {
            Random timeRandom = new Random();
            int tR = timeRandom.Next(Time1, Time2);
            System.Threading.Thread.Sleep(tR);
        }                                                       //Delay vs filter insta bots
    }
}
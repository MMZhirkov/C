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

namespace InstaBot
{
    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IWebDriver Browser;
        public Form1()
        {
            InitializeComponent();
            logger.Trace("log {0}", this.Text);
            //pass authorization
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            IWebElement SearchLogin = Browser.FindElement(By.Name("username"));
            SearchLogin.SendKeys("wowbow@inbox.ru");
            IWebElement SearchPassword = Browser.FindElement(By.Name("password"));
            SearchPassword.SendKeys("Michael2013" + OpenQA.Selenium.Keys.Enter);
            //Random delay 5-9 sec
            Random time1 = new Random();
            int t1 = time1.Next(5000, 9000);
            System.Threading.Thread.Sleep(t1);

            var  te = Browser.Url;
            if (true)
            {
                IWebElement seachDontNow = Browser.FindElement(By.LinkText("Не сейчас"));
                seachDontNow.Click();
                Random time3 = new Random();
                int t3 = time3.Next(3000, 9000);
                System.Threading.Thread.Sleep(t3);
            }
            //find element explore,click 
            IWebElement SearchExplore = Browser.FindElement(By.LinkText("Найти людей"));
            SearchExplore.Click();
            //Random delay 5-9 sec
            Random time2 = new Random();
            int t2 = time2.Next(3000, 9000);
            System.Threading.Thread.Sleep(t2);
            //Search,choose images rand of 6
            List<IWebElement> SearchImages = Browser.FindElements(By.XPath("//div[@class='_havey']/div/div/a")).ToList();
            Random imgChange = new Random();
            int iC = imgChange.Next(0,5);
            SearchImages[iC].Click();
            //Random delay 5-35 sec
            Random delayLike = new Random();
            int dL = delayLike.Next(5000,35000);
            System.Threading.Thread.Sleep(dL);

            Like();
            
            
            //restriction likes 10-15
            Random restrictionLikeHour = new Random();
            int rLH = restrictionLikeHour.Next(10, 15);
            for (int i = 0; i < rLH; i++)
            {
                //Click next image
                //amount likes
                //Random 1-10 for decision
                Random decision = new Random();
                int d = decision.Next(1, 10);
                if (d < 3)
                {
                    //like
                }
                else
                {
                    //nextimg
                }
            }
        }
        public void Like()
        {
            //like<100 and probability =30%
            if (true)
            {
                //Seach button "like",click
                List<IWebElement> SearchLike = Browser.FindElements(By.XPath("//article//div/section/a")).ToList();
                SearchLike[0].Click();
                //Random 2-5 sec
                Random timeNext = new Random();
                int tN = timeNext.Next(2000, 5000);
                System.Threading.Thread.Sleep(tN);
                Next();
            }
        }
        //
        public void Next()
        {
            IWebElement SearchNextImg = Browser.FindElement(By.LinkText("Далее"));
            SearchNextImg.Click();
            //Random 7-22 sec
            Random timeNext = new Random();
            int tN = timeNext.Next(7000, 22000);
            System.Threading.Thread.Sleep(tN);
        }
    }
}
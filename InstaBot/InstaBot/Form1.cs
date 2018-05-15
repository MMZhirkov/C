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

        List<string> Tags = new List<string>(){ "#meat",  "#football", "#шашлыки", "#кроссфит", "#triathlon", "#говядина", "#run", "#футбол", "#стейк", "#триатлон", "#вино" };//"#wine","#running","#steak", "#crossfit", "#мясо", "#мясомясо",
        int likes = 0;
        string lastUrl;
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
            //не убирать like
        }
        public void Login() {
            string currentUrl;
            //pass authorization
            logger.Info("login");
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            Delay(2000, 4000);
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
            //Enter Tag in finder
            foreach (string tag in Tags)
            {
                IWebElement SearchFinder = Browser.FindElement(By.XPath("//section/nav/div[2]/div/div/div[2]/input"));

                SearchFinder.SendKeys(tag); 
                Delay(2000, 3000);
                IWebElement SearchFirstTag = Browser.FindElement(By.XPath("//section/nav/div[2]/div/div/div[2]/div[2]/div[2]/div/a[1]"));
                SearchFirstTag.Click();
                Delay(3000, 5000);
                //Search,choose first images rand of 10-12
                IWebElement SearchImages = Browser.FindElement(By.XPath("//section/main/article/div[2]/div/div[1]/div[1]/a"));
                Random imgChange = new Random();
                int iC = imgChange.Next(9, 12);
                SearchImages.Click();
                logger.Info("first img opened");
                Delay(5000, 9000);
                Liker();
                Browser.Navigate().GoToUrl("https://www.instagram.com/");
                likes = 0;
                Delay(600000,700000);
            }
        }
        public void Liker()
        {
            logger.Info("start Liker");

            if (likes < 100)
            {
                IWebElement countLike = null;
                try
                {
                     countLike = Browser.FindElement(By.XPath("//section[2]/div/a/span"));
                }
                catch (Exception exc)
                {

                    logger.Error("Error -", exc);
                }

                if (countLike==null)
                    {
                    logger.Info("not like = ", likes);
                    IWebElement SearchNextImg1 ;
                    try
                    {
                        SearchNextImg1 = Browser.FindElement(By.LinkText("Далее"));
                        SearchNextImg1.Click();
                    }
                    catch (Exception)
                    {

                        Browser.Navigate().GoToUrl(lastUrl);
                        Delay(2000, 5000);
                        Liker();
                    }
                   
                    Delay(2000, 5000);
                    Liker();
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
                                    logger.Info("summLikes = {0}", likes);
                                    Delay(2000, 5000);
                                    Liker();
                                }
                                else
                                {

                            //если нету далее пропиши
                                    logger.Info("not like = ", likes);
                                    IWebElement SearchNextImg1 = Browser.FindElement(By.LinkText("Далее"));
                                    SearchNextImg1.Click();
                                    Delay(2000, 5000);
                                    Liker();
                                }
                            }
                        else
                            {
                                var urlError = Browser.Url;
                                logger.Error("start Liker", urlError);
                            }
                }
            }
            else
            {
                logger.Info("Exit app");
                Application.Exit();
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
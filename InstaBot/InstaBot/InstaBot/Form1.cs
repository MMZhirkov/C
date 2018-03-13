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
 
namespace InstaBot
{
    public partial class Form1 : Form
    {
        IWebDriver Browser;
        public Form1()
        {
            InitializeComponent();
            //pass authorization
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            IWebElement SearchLogin = Browser.FindElement(By.Name("username"));
            SearchLogin.SendKeys("wowbow@inbox.ru");
            IWebElement SearchPassword = Browser.FindElement(By.Name("password"));
            SearchPassword.SendKeys("" + OpenQA.Selenium.Keys.Enter);
            //Random delay 5-9 sec
            Random time1 = new Random();
            int t1 = time1.Next(5000, 9000);
            System.Threading.Thread.Sleep(t1);
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
            //Seach button "like",click
            List<IWebElement> SearchLike = Browser.FindElements(By.XPath("//article//div/section/a")).ToList();
            SearchLike[0].Click();
            //Random 2-5 sec
            Random timeNext = new Random();
            int tN = timeNext.Next(2000, 5000);
            System.Threading.Thread.Sleep(tN);
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
        private void button1_Click(object sender, EventArgs e)
        {

           

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace GovZak
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IWebDriver Browser;
            string currentUrl;
            string parRegion;
            string parOkpd2Ids;
            string parOkpd2IdsCodes;
            string okpoStr = File.ReadAllText("okpdDict.txt", Encoding.Default);
            string regions = File.ReadAllText("regions.txt", Encoding.Default);
            List<Href> hrefs = new List<Href>();
            string[] listRegions = regions.Split(',');
            string[] listOkpo = okpoStr.Split(',');
            #region Record ListOkpo2
            //List<okpo> okpo2List = new List<okpo>();
            //foreach (var item in listIndex)
            //{
            //    var f = item.Substring(0, 40);

            //    if (f.Contains(':') && f.Contains('>') && f.Contains('.'))
            //    {
            //        string okpo2 = f.Substring(f.IndexOf('>') + 1, f.IndexOf(':') - f.IndexOf('>') - 1);
            //        string id = f.Substring(1, 7);
            //        okpo2List.Add(new okpo(okpo2, id));
            //    }
            //}

            //FileStream fileStream = new FileStream("okpdDict.txt", FileMode.Open);
            //StreamWriter streamWriter = new StreamWriter(fileStream);
            //streamWriter.BaseStream.Seek(fileStream.Length, SeekOrigin.End);//запись в конец файла
            //foreach (okpo okpo in okpo2List)
            //{
            //    streamWriter.Write(okpo.ID + "-" + okpo.Okpo2 + ",");
            //}

            //streamWriter.Close();
            //fileStream.Close();
            #endregion
            List<Filter> hrefVar = new List<Filter>();
            List <Okpo> okpo2List =new List<Okpo>();
            Timer Delay= new Timer();
            foreach (var Okpo2 in listOkpo)
            {
                var okpo2 = Okpo2.Split('-');
                //foreach (string regionId in listRegions)
                //{
                //    hrefVar.Add(new Filter(okpo2[1], okpo2[0], regionId));
                //}
                hrefVar.Add(new Filter(okpo2[1], okpo2[0], "\"5277335\""));
            }
            foreach (Filter hVar in hrefVar)
            {
                string url1 = "http://zakupki.gov.ru/epz/order/extendedsearch/results.html?morphology=on&openMode=DEFAULT_SAVED_SETTING&pageNumber=";
                string url2 = "&&sortDirection=false&recordsPerPage=_50&showLotsInfoHidden=false&fz44=on&placingWaysList=EF&pc=on&priceTo=1000000&currencyId=-1&region_deliveryRegionIds_";
                string url3 = "=region_deliveryRegionIds_";
                string url4 = "&deliveryRegionIds=";
                string url5 = "&regionDeleted=false&applSubmissionCloseDateFrom=31.12.2016&applSubmissionCloseDateTo=31.12.2017&okpd2IdsWithNested=on&okpd2Ids=";
                string url6 = "&okpd2IdsCodes=";
                string url7 = "&sortBy=UPDATE_DATE";
                string url = url1 + "1"+ url2 +  hVar.RegionID.Replace("\"","") + url3+ hVar.RegionID.Replace("\"", "") + url4+ hVar.RegionID.Replace("\"", "") + url5+ hVar.Okpo2ID.Replace("\"", "") + url6+ hVar.Okpo2.Replace("\"", "") + url7;
               
                Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
                Browser.Navigate().GoToUrl(url);
                Delay.Delay(2000, 4000);
                IWebElement LastPage = Browser.FindElement(By.XPath("//li[contains(@class,'rightArrow')]/a"));
                int summ = int.Parse(LastPage.GetAttribute("data-pagenumber"));

                for (int i = 1; i <= summ; i++)
                {
                    url = url1 + i.ToString() + url2 + hVar.RegionID.Replace("\"", "") + url3 + hVar.RegionID.Replace("\"", "") + url4 + hVar.RegionID.Replace("\"", "") + url5 + hVar.Okpo2ID.Replace("\"", "") + url6 + hVar.Okpo2.Replace("\"", "") + url7;
                    Browser.Navigate().GoToUrl(url);
                    Delay.Delay(2000, 4000);
                    ReadOnlyCollection<IWebElement> SearchFinder = Browser.FindElements(By.XPath("//body/div/div/div[3]/div/div/table/tbody/tr/td[2]/dl/dt/a"));
                    ReadOnlyCollection<IWebElement> SeachMoney = Browser.FindElements(By.XPath("//body/div/div[1]/div[3]/div/div/table/tbody/tr/td[1]/dl/dd[2]/strong"));
                
                    for (int k = 0; k < SearchFinder.Count; k++)
                    {
                        hrefs.Add(new Href(SearchFinder[k].GetAttribute("href").Replace("common-info", "supplier-results"), SearchFinder[k].Text, SeachMoney[k].Text.Replace(" ","")));
                    }
                }
                foreach (Href hr in hrefs)
                {
                    Browser.Navigate().GoToUrl(hr.Url);
                }
            }
        }
    }
    public class Href {
        public Href(string url, string name, string money) {
            Url = url;
            Name = name;
            Money = money;
        }
        public string Money { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
    public class Timer {
        public void Delay(int Time1, int Time2)
        {
            Random timeRandom = new Random();
            int tR = timeRandom.Next(Time1, Time2);
            System.Threading.Thread.Sleep(tR);
        }
    }
    public class Okpo
    {
        public Okpo(string okpo2, string id)
        {
            Okpo2 = okpo2;
            ID = id;
        }
        public string Okpo2 { get; set; }
        public string ID { get; set; }
    }
    public class Filter
    { 
        public Filter(string okpo2, string okpo2ID, string regionID)
        {
            Okpo2 = okpo2;
            Okpo2ID = okpo2ID;
            RegionID = regionID;
        }
        public string Okpo2 { get; set; }
        public string Okpo2ID { get; set; }
        public string RegionID { get; set; }
    }
    
}

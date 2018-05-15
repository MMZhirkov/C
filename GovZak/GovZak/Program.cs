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

namespace GovZak
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentUrl;
            string parRegion;
            string parOkpd2Ids;
            string parOkpd2IdsCodes;
            string okpoStr = File.ReadAllText("okpdDict.txt", Encoding.Default);
            string regions = File.ReadAllText("regions.txt", Encoding.Default);

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
            foreach (var Okpo2 in listOkpo)
            {
                var okpo2 = Okpo2.Split('-');
                foreach (string regionId in listRegions)
                {
                    hrefVar.Add(new Filter(okpo2[1], okpo2[0], regionId));
                }
            }


            
           
            IWebDriver Browser;

            //foreach (var item in collection)
            //{

            //}

            string urlStr = "http://zakupki.gov.ru/epz/order/extendedsearch/results.html?morphology=on&openMode=DEFAULT_SAVED_SETTING&pageNumber=1&sortDirection=false&recordsPerPage=_10&showLotsInfoHidden=false&fz44=on&placingWaysList=EF&pc=on&priceTo=1000000&currencyId=-1&regionDeleted=false&region_deliveryRegionIds_5277349=region_deliveryRegionIds_5277349&deliveryRegionIds=5277349&regionDeleted=false&applSubmissionCloseDateFrom=31.12.2016&applSubmissionCloseDateTo=31.12.2017&okpd2IdsWithNested=on&okpd2Ids=8873971&okpd2IdsCodes=01.1&regionDeleted=false&sortBy=UPDATE_DATE";

            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl(urlStr);
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

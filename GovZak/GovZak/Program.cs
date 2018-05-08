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
            string urlStr = "http://zakupki.gov.ru/epz/order/extendedsearch/results.html?morphology=on&openMode=DEFAULT_SAVED_SETTING&pageNumber=1&sortDirection=false&recordsPerPage=_10&showLotsInfoHidden=false&fz44=on&placingWaysList=EF&pc=on&priceTo=1000000&currencyId=-1&publishDateFrom=31.12.2016&publishDateTo=01.01.2018&region_deliveryRegionIds_5277352=region_deliveryRegionIds_5277352&deliveryRegionIds=5277352&regionDeleted=false&okpdIds=3291&okpdIdsCodes=01.11.1&sortBy=UPDATE_DATE";

           


            string jsonData = System.IO.File.ReadAllText(@"Content\DictForGovZakup.json");
            GovZakup jsonP = JsonConvert.DeserializeObject<GovZakup>(jsonData);
            IWebDriver Browser;
            
            

            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl(urlStr);
        }
    }
    public class GovZakup {
        [JsonProperty("OKPO2")]
        public string okpo2 { get; set; }
        [JsonProperty("Region")]
        public string Region { get; set; }
    }
    public class Href
    {
        [JsonProperty("OKPO2")]
        public string Okpo2 { get; set; }
        [JsonProperty("Region")]
        public string Region { get; set; }
        [JsonProperty("Path")]
        public string Path { get; set; }
    }
}

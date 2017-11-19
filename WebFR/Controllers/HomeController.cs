using FastReport.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.IO;
using WebFR.Models;

namespace WebFR.Controllers
{
    public class HomeController : Controller
    {
        private WebReport webReport = new WebReport(); // создаем объект отчета
        
        public ActionResult Index()
        {
            
           // ViewBag.Directories = rootInfo.GetDirectories();
           
            LoadReport();//загружаем отчет
            
            return View(CreateTree());
        }
        private IEnumerable<CategoryContainer> CreateTree()
        {
            DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath("~/Bin/"));//указываем дирректорию для дерева
           
            List<CategoryContainer> Folders = new List<CategoryContainer>();
            List<CategoryContainer> Folders2 = new List<CategoryContainer>();
            List<CategoryContainer> Folders3 = new List<CategoryContainer>();

            foreach (DirectoryInfo item in rootInfo.GetDirectories())
            {
                Folders.Add(new CategoryContainer() { Title = item.ToString() });
                foreach (DirectoryInfo folder2 in item.GetDirectories())
                {
                    Folders2.Add(new CategoryContainer() { Title = folder2.ToString() });
                    Folders.Add(new CategoryContainer() { Title = item.ToString() });
                    foreach (DirectoryInfo folder3 in item.GetDirectories())
                    {
                        Folders2.Add(new CategoryContainer() { Title = folder3.ToString() });

                    }
                    foreach (FileInfo file3 in item.GetFiles())
                    {
                        Folders2.Add(new CategoryContainer() { Title = file3.ToString() });
                    }
                }
                foreach (FileInfo file2 in item.GetFiles())
                {
                    Folders2.Add(new CategoryContainer() { Title = file2.ToString()});
                }
            }
            foreach (FileInfo file in rootInfo.GetFiles())
            {
                Folders.Add(new CategoryContainer() { Title = file.Name, FullPath= file.FullName,Extension = file.Extension});
            }
            return Folders;
        }
        private void MergeReport()
        {
            LoadReport();

        }
        private void LoadReport()
        {
            var PathReport = GetReportPath(); // получаем путь
            webReport.Report.LoadPrepared(PathReport); //загружаем отчет
            webReport.ReportDone = true; // свойство FastReport для загрузки
            webReport.Height = Unit.Percentage(100);
            webReport.Width = Unit.Percentage(100);
            ViewBag.WebReport = webReport; // передаем отчет в представление
        }
        private string GetReportPath()
        {
            var PathReport1 = "C:\\Users\\MMZhirkov\\Documents\\WebFR\\WebFR\\bin\\1012.fpx";
            return PathReport1;
        }
       
    }
}
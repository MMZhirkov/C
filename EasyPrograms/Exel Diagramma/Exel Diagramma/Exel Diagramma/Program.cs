using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Exel_Diagramma
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём экземпляр нашего приложения
            Excel.Application excelApp = new Excel.Application();
            // Создаём экземпляр рабочий книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;

            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            // Заполняем первую строку числами от 1 до 10
            for (int j = 1; j <= 10; j++)
            {
                workSheet.Cells[1, j] = j;
            }
            // Вычисляем сумму этих чисел
            Excel.Range rng = workSheet.Range["A2"];
            rng.Formula = "=SUM(A1:L1)";
            rng.FormulaHidden = false;

            // Выделяем границы у этой ячейки
            Excel.Borders border = rng.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;

            // Строим круговую диаграмму
            Excel.ChartObjects chartObjs = (Excel.ChartObjects)workSheet.ChartObjects();
            Excel.ChartObject chartObj = chartObjs.Add(5, 50, 300, 300);
            Excel.Chart xlChart = chartObj.Chart;
            Excel.Range rng2 = workSheet.Range["A1:L1"];
            // Устанавливаем тип диаграммы
            xlChart.ChartType = Excel.XlChartType.xlPie;
            // Устанавливаем источник данных (значения от 1 до 10)
            xlChart.SetSourceData(rng2);

            // Открываем созданный excel-файл
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
    }
}

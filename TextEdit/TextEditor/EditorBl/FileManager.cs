
using System.Text;
using System.IO;//Работа с файлами

namespace EditorBl
{
    public class FileManager
    {
        //Получаем файл
            private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);//Кодировка по умолчанию
            //проверка существования файла
            public bool isExist(string filePath)
            {
            bool isExist = File.Exists(filePath);
            return isExist;
            }
            //перегруженный метод
            public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
            public string GetContent(string filePach, Encoding encoding)
            {
            string content = File.ReadAllText(filePach, encoding);
            return content;
            }
        //Сохраняем
            public void SaveContent(string content,string filePath,Encoding encoding)
            {
            File.WriteAllText(filePath, content, encoding);
            }
            //Считаем кол-во символов
            public int GetSymbolCount(string content)
            {
            int count = content.Length;
            return count;
            }
    }
}

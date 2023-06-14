
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Задание___7
{
    interface ITextSearch
    {
        void Search(string filename, string regexPattern);
    }

    class TextSearch : ITextSearch
    {
        public void Search(string filename, string regexPattern)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    MatchCollection matches = Regex.Matches(line, regexPattern);
                    foreach (Match match in matches)
                    {
                        Console.WriteLine("Совпадение: " + match.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITextSearch textSearch = new TextSearch();

            Console.WriteLine("Введите имя текстового файла:");
            string filename = Console.ReadLine();

            Console.WriteLine("Введите регулярное выражение для поиска:");
            string regexPattern = Console.ReadLine();

            textSearch.Search(filename, regexPattern);
        }
    }
}


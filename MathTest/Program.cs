using System;
using System.IO;

namespace MathTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string text = "";
                using (StreamReader file = new StreamReader(@"Test.txt"))
                {
                    string line;

                    file.Close();

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл с тестами не найден");
            }


        }
        public static void Help()
        {
            Console.WriteLine("Для учителя: \n " +
            "Напишите в файл Test.txt примеры для теста. \n" +
            "Для ученика: \n" +
            "Введите свою фамилию, решите примеры. " +
            "Проверьте результат теста. \n ");
        }
    }
}

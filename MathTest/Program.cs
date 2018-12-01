using System;
using System.IO;

namespace MathTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text;
            string line;
            int exampleCount = 0;
            int rightAns = 0;

            Console.WriteLine("Введите свою фамилию");
            string lastName = Console.ReadLine();

            StreamWriter textFile = new StreamWriter($@"{lastName}.txt");

            try
            {
                using (StreamReader file = new StreamReader(@"Test.txt"))
                {
                    while ((line = file.ReadLine()) != null) {
                        string[] example = line.Split(" ");
                        try
                        {
                            exampleCount += 1;
                            double res = ResolvingExample(example[0], 
                            example[2], example[1]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{exampleCount}) {line}");

                            double midAns = double.Parse(Console.ReadLine());
                            if(midAns == res)
                            {
                                rightAns++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Верно");
                                textFile.WriteLine(line + " " + res + "-> ВЕРНО!");
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Не верно");
                                textFile.WriteLine(line + " " + res + "-> НЕ ВЕРНО!");
                            }
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Исправьте примеры в тесте.");
                        }
                    }
                    file.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Файл с тестами не найден");
            }
            textFile.WriteLine($"Правильных ответов: {rightAns} из {exampleCount}");
            textFile.Close();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Правильных ответов: {rightAns} из {exampleCount}");
            Console.ReadLine()
        }
        public static void Help()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Для учителя: \n " +
            "Напишите в файл Test.txt примеры для теста. \n" +
            "Для ученика: \n" +
            "Введите свою фамилию, решите примеры. " +
            "Проверьте результат теста. \n ");
        }

        public static double ResolvingExample(string a, string b, string sign)
        {
            double resolveNumber = 0;
            double aa = double.Parse(a);
            double bb = double.Parse(b);
            switch (sign)
            {
                case "+":
                    resolveNumber = aa + bb;
                    break;
                case "-":
                    resolveNumber = aa - bb;
                    break;
                case "*":
                    resolveNumber = aa * bb;
                    break;
                case ":":
                    resolveNumber = aa / bb;
                    break;
                default:
                    return resolveNumber = 0;
            }
            return resolveNumber;
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ValidPassword
{
    internal class Program
    {
        // Метод для перевірки валідності пароля за вимогою
        private bool CheckValidPassword(string ValidityCondition, string Password)
        {
            // Розбиваємо вимоги до паролю на символ і діапазон входження його в пароль
            var parts = ValidityCondition.Split(' ');
            var SymbolInPassword = parts[0][0];
            var Range = parts[1].Split('-').Select(int.Parse).ToArray();
            var MinCount = Range[0];
            var MaxCount = Range[1];

            // Обчислюємо кількість входжень символу в паролі
            var CharCount = Password.Count(c => c == SymbolInPassword);

            // Перевіряємо, чи кількість входжень в допустимому діапазоні
            return CharCount >= MinCount && CharCount <= MaxCount;
        }

        // Метод для підрахунку кількості валідних паролів у файлі
        private int CountValidPassword(string FilePath)
        {
            int ValidPasswordCount = 0;

            // Зчитуємо всі рядки з файлу
            string[] lines = File.ReadAllLines(FilePath);

            // Проходимось по кожному рядку та перевіряємо валідність пароля
            foreach (var line in lines)
            {
                // Розбиваємо рядок на вимогу та пароль
                var parts = line.Split(':');
                var ValidityCondition = parts[0].Trim();
                var Password = parts[1].Trim();

                // Перевіряємо валідність пароля за допомогою методу CheckValidPassword
                if (new Program().CheckValidPassword(ValidityCondition, Password))
                {
                    ValidPasswordCount++;
                }
            }

            // Повертаємо кількість валідних паролів
            return ValidPasswordCount;
        }

        private 
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter file path:");
                string FilePath = Console.ReadLine();

                // Перевіряємо, чи користувач ввів "exit" для виходу
                if (FilePath == "exit")
                {
                    Environment.Exit(0);
                }
                // Перевіряємо, чи існує файл за вказаним шляхом
                if (File.Exists(FilePath))
                {
                    // Викликаємо метод CountValidPassword для підрахунку валідних паролів
                    int ValidPasswordCount = new Program().CountValidPassword(FilePath);
                    Console.WriteLine("Number of valid passwords: {0}", ValidPasswordCount);
                }
                else
                {
                    Console.WriteLine("The file path is incorrect, please enter the correct path.");
                }
            }
        }
    }
}

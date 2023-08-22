using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidPasswordWinForm
{
    internal class CountValidPassword
    {
        // Метод для підрахунку кількості валідних паролів у файлі
        private int CountPassword(string FilePath)
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

                // Перевіряємо валідність пароля за допомогою методу ValidPassword
                if (new CheckValidPassword().validPassword(ValidityCondition, Password))
                {
                    ValidPasswordCount++;
                }
            }

            // Повертаємо кількість валідних паролів
            return ValidPasswordCount;
        }

        public int countPassword(string FilePath)
        {
            return CountPassword(FilePath);
        }
    }
}

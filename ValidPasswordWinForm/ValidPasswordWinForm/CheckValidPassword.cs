using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidPasswordWinForm
{
    internal class CheckValidPassword
    {
        // Метод для перевірки валідності пароля за вимогою
        private bool ValidPassword(string ValidityCondition, string Password)
        {
            // Розбиваємо вимогу на символ та діапазон входження
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

        public bool validPassword(string ValidityCondition, string Password)
        {
            return ValidPassword(ValidityCondition, Password);
        }
    }
}

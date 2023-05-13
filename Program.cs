using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Class5
{
    internal class Program
    {
        /// <summary>
        /// Перечисление - выбор строки для вывода в таблицу.
        /// </summary>
        public enum TypeStringTab
        {
            /// <summary>
            /// Этот элемент перечисления выводит в таблицу строку с пользовательским текстом
            /// </summary>
            firstString,
            /// <summary>
            /// Этот элемент перечисления выводит в таблицу строку с символами '+' в шахматном порядке
            /// </summary>
            secondString,
            /// <summary>
            /// Этот элемент перечисления выводит в таблицу строку с символами '+' по диагонали
            /// </summary>
            thirdString,
        }

        /// <summary>
        /// Метод вывода таблицы.
        /// </summary>
        /// <param name="typeString">определяет какой тип строки надо вывести</param>
        /// <param name="countTab">получает размерность таблицы</param>
        /// <param name="inputString">получает текст для вывода в таблицу</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OutputStringTab(TypeStringTab typeString, int countTab, string inputString)
        {
            //длинна строки таблицы
            int _countString = 2 * countTab + inputString.Length;

            //строка символов '+'
            string? _strplus = new string('+', _countString - 2);

            //циклический вывод элементов в строки таблицы
            for (int i = 0; i <= _countString - 1; i++)
            {
                switch (typeString)
                {
                    case TypeStringTab.firstString:

                        // проверка на выход из диапазона данной строки переменной цикла
                        if (i > 2 * countTab) break;
                        if (i == 0 | i == 2 * countTab)
                            // вывод границ первой строки таблицы
                            Console.WriteLine(new String('+', _countString));
                        else if (i == countTab)
                            // вывод пользовательского текста первой строки таблицы
                            Console.WriteLine("+" + new string(' ', countTab - 1) +
                                inputString + new string(' ', countTab - 1) + "+");
                        else
                            // вывод пустого пространства первой строки таблицы
                            Console.WriteLine("+" + new string(' ', _countString - 2) + "+");
                        break;

                    case TypeStringTab.secondString:

                        // проверка на выход из диапазона данной строки переменной цикла
                        if (i > 2 * countTab) break;

                        // формируем строки для расстановки символа '+' в шахматном порядке
                        var _blackChess = _strplus.ToList().
                            Select((m, n) => (n % 2 == 0) ? m = ' ' : m = '+').ToArray();

                        // формируем строки для расстановки символа '+' в шахматном порядке
                        var _whiteChess = _strplus.ToList().
                            Select((m, n) => (n % 2 == 0) ? m = '+' : m = ' ').ToArray();
                        if (i % 2 == 0)
                            // расставляем символы '+' в шахматном порядке
                            Console.WriteLine("+" + new string(_blackChess) + "+");
                        else
                            // расставляем символы '+' в шахматном порядке
                            Console.WriteLine("+" + new string(_whiteChess) + "+");
                        break;

                    case TypeStringTab.thirdString:

                        if (i == 0 | i == _countString - 1)
                            // вывод границ третьей строки таблицы
                            Console.WriteLine(new String('+', _countString));
                        else
                        {
                            // формируем строки для расстановки символа '+' по диагонали
                            var _diagonalplus = _strplus.ToList().Select((m, n) => (n == i - 1) |
                            (n == _countString - 2 - i) ? m = '+' : m = ' ').ToArray();

                            // расставляем символы '+' в диагональном порядке
                            Console.WriteLine("+" + new String(_diagonalplus) + "+");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Точка входа. Получает от пользователя размерность таблицы и текст, далее вызывает метод вывода таблицы.
        /// </summary>
        static void Main()
        {
            //переменная name="n" содержит размерность таблицы согласно заданию
            int n;

            // "бесконечный" цикл для получения от пользователя значения размерности в пределах диапазона
            while (true) 
            {
                Console.WriteLine("Введите размерность таблицы:");
                var inputTabCount = Console.ReadLine();
                var isTabCount = int.TryParse(inputTabCount, out var countTab);
                if (isTabCount && countTab >= 1 && countTab <= 6)
                {
                    n = countTab;
                    break;
                }
                else Console.WriteLine("Значение размерности должно быть целочисленным в диапазоне от 1 до 6");
            }
            //переменная name="inputText" содержит текст, введенный пользователем
            string? inputText;

            var checkEmpty = true;
            // цикл с пост проверкой условия, что пользователь ввел текст
            do
            {
                Console.WriteLine("Введите произвольный текст:");
                inputText = Console.ReadLine();
                checkEmpty = string.IsNullOrEmpty(inputText);
                //длинна строки таблицы
                int _countString = 2 * n + inputText.Length;
                //проверка на соответствие размерности таблицы
                if (_countString > 40)
                {
                    Console.WriteLine("Размер строки превышает 40 символов");
                    checkEmpty = true;
                }
            }
            while (checkEmpty);

            if (inputText != null)
            {
                foreach (var value in Enum.GetValues(typeof(TypeStringTab)))
                {
                    OutputStringTab((TypeStringTab)value, n, inputText);
                }
            }
            Console.ReadLine();
        }
    }
}
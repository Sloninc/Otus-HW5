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
            try
            {
                int _countString = 2 * countTab + inputString.Length; //длинна строки таблицы
                if (_countString > 40) //проверка на соответствии размерности таблицы
                    throw new ArgumentOutOfRangeException("размерноть таблицы и текст", "строки в таблице не должны превышать 40 символов");
                string? _strplus = new string('+', _countString - 2); //строка символов '+'
                for (int i = 0; i <= _countString - 1; i++) //циклический вывод элементов в строки таблицы
                {
                    switch (typeString)
                    {
                        case TypeStringTab.firstString:
                            if (i > 2 * countTab) break;  // проверка на выход из диапазона данной строки переменной цикла
                            if (i == 0 | i == 2 * countTab)  
                                Console.WriteLine(new String('+', _countString));// вывод границ первой строки таблицы
                            else if (i == countTab)
                                Console.WriteLine("+" + new string(' ', countTab - 1) + 
                                    inputString + new string(' ', countTab - 1) + "+"); // вывод пользовательского текста первой строки таблицы
                            else Console.WriteLine("+" + new string(' ', _countString - 2) + "+"); // вывод пустого пространства первой строки таблицы
                            break;
                        case TypeStringTab.secondString:
                            if (i > 2 * countTab) break; // проверка на выход из диапазона данной строки переменной цикла
                            var _blackChess = _strplus.ToList().Select((m, n) => (n % 2 == 0) ? m = ' ' : m = '+').ToArray(); // формируем строки для расстановки символа '+' в шахматном порядке
                            var _whiteChess = _strplus.ToList().Select((m, n) => (n % 2 == 0) ? m = '+' : m = ' ').ToArray(); // формируем строки для расстановки символа '+' в шахматном порядке
                            if (i % 2 == 0) Console.WriteLine("+" + new string(_blackChess) + "+");// расставляем символы '+' в шахматном порядке
                            else Console.WriteLine("+" + new string(_whiteChess) + "+");// расставляем символы '+' в шахматном порядке
                            break;
                        case TypeStringTab.thirdString:
                            if (i == 0 | i == _countString - 1)
                                Console.WriteLine(new String('+', _countString));// вывод границ третьей строки таблицы
                            else
                            {
                                var _diagonalplus = _strplus.ToList().Select((m, n) => (n == i - 1) | 
                                (n == _countString - 2 - i) ? m = '+' : m = ' ').ToArray(); // формируем строки для расстановки символа '+' по диагонали
                                Console.WriteLine("+" + new String(_diagonalplus) + "+"); // расставляем символы '+' в диагональном порядке
                            }
                            break;
                    }
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Main();
            }
        }
        /// <summary>
        /// Точка входа. Получает от пользователя размерность таблицы и текст, далее вызывает метод вывода таблицы.
        /// </summary>
        static void Main()
        {
            int n;  //переменная name="n" содержит размерность таблицы согласно заданию
            while (true) // "бесконечный" цикл для получения от пользователя значения размерности в пределах диапазона.
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
        
            var checkEmpty = false;
            string? inputText; //переменная name="inputText" содержит текст, введенный пользователем
            do // цикл с пост проверкой условия, что пользователь ввел текст
            {
                Console.WriteLine("Введите произвольный текст:");
                inputText = Console.ReadLine();
                checkEmpty = string.IsNullOrEmpty(inputText);
            }
            while (checkEmpty);

            if (inputText != null)
            {
                OutputStringTab(TypeStringTab.firstString, n, inputText);
                OutputStringTab(TypeStringTab.secondString, n, inputText);
                OutputStringTab(TypeStringTab.thirdString, n, inputText);
            }
            Console.ReadLine();
        }
    }
}
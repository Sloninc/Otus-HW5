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
            firstString,
            secondString,
            thirdString,
        }

        public static void OutputStringTab(TypeStringTab typeString, int countTab, string inputString)
        {
            int _countString = 2 * countTab + inputString.Length;
            string? s = new string('+', _countString - 2);
            for (int i = 0; i <= _countString-1; i++)
            {
                switch (typeString)
                {
                    case TypeStringTab.firstString:
                        if (i > 2 * countTab) break;
                        if (i == 0 | i == 2 * countTab)
                            Console.WriteLine(new String('+', _countString));
                        else if (i == countTab)
                            Console.WriteLine("+" + new string(' ', countTab - 1) + inputString + new string(' ', countTab - 1) + "+");
                        else Console.WriteLine("+" + new string(' ', _countString - 2) + "+");
                        break;
                    case TypeStringTab.secondString:
                        if (i > 2 * countTab) break;
                        var z = s.ToList().Select((m, n) => (n % 2 == 0) ? m = ' ' : m = '+').ToArray();
                        var w = s.ToList().Select((m, n) => (n % 2 == 0) ? m = '+' : m = ' ').ToArray();
                        if (i % 2 == 0) Console.WriteLine("+" + new string(z) + "+");
                        else Console.WriteLine("+" + new string(w) + "+");
                        break;
                    case TypeStringTab.thirdString:
                        if (i == 0 | i == _countString-1)
                            Console.WriteLine(new String('+', _countString));
                        else
                        {
                            var u = s.ToList().Select((m, n) => (n == i-1)|(n== _countString - 2-i) ? m = '+' : m = ' ').ToArray();
                            Console.WriteLine("+" + new String(u) + "+");
                        }
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            int n;
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
        
            var checkEmpty = false;
            string? inputText;
            do
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
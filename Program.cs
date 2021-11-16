using System;
using System.Linq;

namespace _2ndBiggestInArray
{
    internal class Program
    {
        static int[] numbers;

        static void Main(string[] args)
        {
            Greetings();

            CreateArray();

            FillArray();

            SearchAndShow2ndBiggest();
        }

        static void Greetings()
        {
            Console.WriteLine("Здравствуй, Валерий! Я хочу сыграть с тобой в игру!");
            Console.WriteLine("Давай найдем второе наибольшее число в заданном тобой массиве!");
            Console.WriteLine("Для начала, давай определим количество элементов в массиве.");
            Console.WriteLine("Без фанатизма, не более 10.");

        }
        static void CreateArray()
        {
            Console.WriteLine("Введи целое число от 1 до 10!");
            int l = 0;
            object x = Console.ReadLine();

            try
            {
                l = Convert.ToInt32(x);
                if (l > 1 && l <= 10) Console.WriteLine($"Заданная длина массива l: {l} элементов!");
                else if (l > 10)
                {
                    Console.WriteLine("Длина массива слишком велика, не осилю! Не более 10 элементов!");
                    CreateArray();
                }
                else if (l < 1)
                {
                    Console.WriteLine("В массиве не может быть менее 1 элемента! Введи нормальное число!");
                    CreateArray();
                }
                numbers = new int[l];
            }
            catch
            {
                Console.WriteLine("Ты ввел какую-то ерунду. Введи число от 1 до 10!");
                CreateArray();
            }
        }

        static void FillArray()
        {
            Console.WriteLine("Давай определим элементы массива!");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Введи {i + 1} элемент массива - любое целое число!");
                numbers[i] = DefineElement();
                Console.WriteLine($"Элемент {i + 1} массива равен {numbers[i]}!");
            }
            Console.WriteLine("Элементы массива успешно определены!");
            Console.WriteLine("{0}", string.Join("\n", numbers));
        }
        static int DefineElement()
        {
            int el;
            try
            {
                el = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ты ввел какую-то ерунду. Введи целое число!");
                el = DefineElement();
            }
            return el;
        }

        static void SearchAndShow2ndBiggest()
        {
            Console.WriteLine("А сейчас - магия: определим второе наибольшее число в этом массиве!");
            /*int secondBig = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    if (numbers.OrderByDescending(x => x).ElementAt(i + 1) < numbers.OrderByDescending(x => x).ElementAt(i))
                    {
                        secondBig = numbers.OrderByDescending(x => x).ElementAt(i + 1);
                        Console.WriteLine($"Второй наибольший элемент массива равен {secondBig}!");
                        break;
                    }
                }
                catch
                {
                    secondBig = numbers.OrderByDescending(x => x).ElementAt(numbers.Length - 1);
                    Console.WriteLine($"А ты шутник! Все элементы одинаковы! Сам ищи тут второе наибольшее!");
                }                     
            }*/
            int maxEl = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxEl) maxEl = numbers[i];
            }
            int secondBig = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < maxEl && numbers[i] > secondBig) secondBig = numbers[i];
            }
            if (secondBig == int.MinValue) Console.WriteLine($"А ты шутник! Все элементы одинаковы! Сам ищи тут второе наибольшее!");
            else Console.WriteLine($"Второй наибольший элемент массива равен {secondBig}!");

        }
    }
}

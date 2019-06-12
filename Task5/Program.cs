using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дана действительная квадратная матрица порядка n.Найти наибольшее из значений элементов, расположенных в заштрихованной части матрицы

namespace Task5
{
    class Program
    {
        static Random rnd = new Random();
        static double[,] arr = null;
        static bool found = false;
        static double maxVal;
        static int maxLength;
        static int n;
        static void Main(string[] args)
        {
            bool end = false;
            do
            {
                Console.WriteLine("Введите порядок квадратной матрицы:");
                n = CheckInt(0, 0);
                arr = new double[n, n];
                Vvod();
                double max = GetMax(n);
                Console.WriteLine("Матрица: ");
                PrintArr(n);
                Console.WriteLine("Наибольшее значение элемента в заданной области: " + max);
                end = CheckKey();
            } while (!end);
        }
        public static void Vvod()
        {
            Console.WriteLine("Выберите способ ввода массива:\n1)Ввод с клавиатуры\n2)Заполнение рандомными числами");
            int menuPoint = CheckInt(0, 3);
            switch (menuPoint)
            {
                case 1:
                    CreateKey(n);
                    break;
                case 2:
                    CreateRnd(n);
                    break;
            }

        }
        public static int CheckInt(int a, int b)
        {
            int num;
            bool okay = false;
            do
            {
                if (a != b) okay = Int32.TryParse(Console.ReadLine(), out num) && (num > a) && (num < b);
                else okay = Int32.TryParse(Console.ReadLine(), out num) && (num > a);
                if (!okay) Console.WriteLine("Ошибка ввода. Повторите ввод целого числа");
            } while (!okay);
            return num;
        }
        public static double CheckDouble()
        {
            double num;
            bool okay = false;
            do
            {
                okay = Double.TryParse(Console.ReadLine(), out num);
                if (!okay) Console.WriteLine("Ошибка ввода. Повторите ввод действительного числа числа");
            } while (!okay);
            return num;
        }
        public static void CreateRnd(int size)
        {
            maxLength = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = rnd.Next(-100, 100);
                    if (arr[i, j].ToString().Length > maxLength) maxLength = arr[i, j].ToString().Length;
                }
            found = false;
        }
        public static void CreateKey(int size)
        {
            maxLength = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Console.WriteLine("Введите элемент для позиции ({0}, {1}):", i+1, j+1);
                    arr[i, j] = CheckDouble();
                    if (arr[i, j].ToString().Length > maxLength) maxLength = arr[i, j].ToString().Length;
                }
            found = false;
        }
        public static void PrintArr(int size)
        {
            int limI;
            if (size % 2 == 0) limI = size / 2;
            else limI = size / 2 + 1;
            for (int i = 0; i < limI; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.CursorLeft = (maxLength + 2) * j;                    
                    if (j >= i && j <= size - 1 - i)
                    {
                        if (found && arr[i, j] == maxVal)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(arr[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(arr[i, j] + "  ");
                            Console.ResetColor();
                        }
                        
                    }
                    else Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }
            for (int i = limI; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.CursorLeft = (maxLength + 2) * j;
                    if (found && arr[i, j] == maxVal)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(arr[i, j] + "  ");
                        Console.ResetColor();
                    }
                    else if (j <= i && j >= size - 1 - i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(arr[i, j] + "  ");
                        Console.ResetColor();
                    }
                    else Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        public static double GetMax(int size)
        {
            int limI;
            if (size % 2 == 0) limI = size / 2;
            else limI = size / 2 + 1;
            maxVal = arr[0, 0];
            if (size % 2 == 0) limI = size / 2;
            else limI = size / 2 + 1;
            for (int i = 0; i < limI; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j >= i && j <= size - 1 - i)
                    {
                        if (arr[i, j] > maxVal) maxVal = arr[i, j];
                    }
                }
            }
            for (int i = limI; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j <= i && j >= size - 1 - i)
                    {
                        if (arr[i, j] > maxVal) maxVal = arr[i, j];
                    }
                }
            }
            found = true;
            return maxVal;
        }
        public static bool CheckKey()
        {
            bool next, end = false;
            int keyNum;
            Console.WriteLine("Для выхода из программы нажмите Esc, для ввода другого массива нажмите Enter.");
            do
            {
                keyNum = Console.ReadKey().KeyChar;
                next = (keyNum == 27) || (keyNum == 13);
            } while (!next);
            if (keyNum == 27) end = true;
            Console.Clear();
            return end;
        }
    }
}


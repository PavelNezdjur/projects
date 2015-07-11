using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void fastSorting(int[] arr, int left, int right)
        {
            int temp;
            int middle = arr[(left + right) / 2]; // разбиение массива относительно опорного элемента
            int i = left;
            int j = right;
            
            while (i <= j) // сортировка: меньше середины - слева, больше - справа
            {
                while (arr[i] < middle) i++;
                while (arr[j] > middle) j--;
                if (i <= j) // меняем местами элементы
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            // рекурсивная сортировка каждой части массива
            if (i < right) 
                fastSorting(arr, i, right);

            if (j > left) 
                fastSorting(arr, left, j);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива N ");
            int N = Int32.Parse(Console.ReadLine());
            int[] arr = new int[N];
            Console.WriteLine(); //пробел между строками для более удобного восприятия результатов
            
            Random Rand = new Random(); // для наглядности результата - заполняем массив случайными числами
            Console.WriteLine("До сортировки: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Rand.Next(1, N + 1);
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine(); //пробел
                
            fastSorting(arr, 0, N - 1); //сортируем массив

            // Итого
            Console.WriteLine("После сортировки: ");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
        }
    }
}


        
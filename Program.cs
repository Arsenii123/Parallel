using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Please enter the beginning of diapason:");
            int begin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the end of diapason:");
            int end = Convert.ToInt32(Console.ReadLine());
            var numbers = Enumerable.Range(begin, end).ToList();
             Console.Clear();
            ParallelInvoke(numbers);
            Console.WriteLine($"The maximum:{GetMaxPLinq(numbers)}");
            Console.WriteLine($"The minimum:{GetMinPLinq(numbers)}");
            Console.WriteLine($"The average:{GetAveragePLinq(numbers)}");
            Console.WriteLine($"The summ:{GetSumPLinq(numbers)}");
        }
        static int GetSumPLinq(List<int> numbers)
        {
            return numbers.AsParallel()
               .Sum();


        }
        //static int GetProductPLinq(List<int> numbers)
        //{

        //    return numbers.AsParallel();

        //}
        static int GetMaxPLinq(List<int> numbers)
        {
            return numbers.AsParallel()
               .Max();


        }
        static int GetMinPLinq(List<int> numbers)
        {
            return numbers.AsParallel()
               .Min();


        }
        static double GetAveragePLinq(List<int> numbers)
        {
            return numbers.AsParallel()
                .Average();
        }
        static int Product(List<int> numbers)
        {
            int a = 1;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                a *= numbers[i];
            }
            return a;
        }
        static int P(List<int> n)
        {
            return n.Count;
        }
        static void Map(List<int> numbers)
        {
            int number = 0;
            for (int y = 0; y < numbers.Count * 2 + 1; y++)
            {
                for (int x = 0; x < numbers.Count * 4 + 1; x++)
                {

                    if (x == 0 && y == 0)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("0");
                        number = 1;

                    }

                    else if (y == 0 && x % 4 == 0)
                    {


                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.WriteLine(number);
                        number++;
                    }
                    else if (x == 0 && y % 2 == 0)
                    {
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        if (number > numbers.Count)
                        {
                            number = 1;
                        }

                        Console.WriteLine(number);
                        number++;

                    }
                }


            }
        }
        static void Table(List<int> numbers)
        {
            Thread.Sleep(1);
            BigInteger a = 1;
            int[,] map = new int[numbers.Count*4+1, numbers.Count*2+1];
            int b = 0;
            for (int y = 0; y < numbers.Count * 2 + 1; y++)
            {
                for (int x = 0; x < numbers.Count * 4 + 1; x++)
                {

                    if (x % 4 == 0 && y % 2 == 0 && map[x, y] == 0 && x != 0 && y != 0)
                    {
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        b = numbers[y / 2 -1];
                        Console.WriteLine(a*b);
                        a++;
                        map[x, y] = 1;

                    }
                    else if (a > numbers.Count)
                    {
                        a = 1;
                    }
                
                }
            
            }
             
            
        }
        static void ParallelInvoke(List <int> numbers)
        {
            Parallel.Invoke(
                // обгортаємо синхронні методи в делегати
                ()=>Map(numbers),
                () => Table(numbers)
            );
        }
    }
}

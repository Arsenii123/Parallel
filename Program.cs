using System.Threading.Channels;

namespace Homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Please enter the beginning of diapason:");
           int begin=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the end of diapason:");
            int end = Convert.ToInt32(Console.ReadLine());
           var numbers = Enumerable.Range(begin, end).ToList();
        }
        static int GetSumPLinq(List<int> numbers)
        {
            return numbers.AsParallel()
               .Sum();  
               
               
        }
        static int GetProductPLinq(List<int> numbers)
        {
            return numbers.AsParallel()
                .Select( ()=>Product(numbers)  );


        }
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
        static int GetAveragePLinq(List<int> numbers)
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

    }
}

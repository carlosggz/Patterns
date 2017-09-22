using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            
            p.Test(new FibonacciLoop());
            p.Test(new FibonacciMemoization());
            p.Test(new FibonacciRecursive());

            Console.WriteLine("Press ENTER to end...");
            Console.ReadLine();
        }

        private void Test(FibonacciStrategy strategy)
        {
            Console.Write($"Calculating fibonacci using strategy: {strategy.GetType().Name}...");

            var watch = new Stopwatch();
            watch.Start();
            var result = strategy.Calculate(40);
            watch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Result = {result}, time = {watch.Elapsed.ToString()}  seconds");
            Console.WriteLine();
        }
    }
}

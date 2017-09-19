using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Test(new GoogleFactory());
            p.Test(new YahooFactory());

            Console.WriteLine("Press ENTER to end...");
            Console.ReadLine();
        }

        void Test(Factory factory)
        {
            Console.WriteLine($"Testing factory { factory.GetType().Name }");
            Console.WriteLine($"Searcher: {factory.GetSearcher().Url}");
            Console.WriteLine($"Mail: {factory.GetMail().Url}");
            Console.WriteLine();
        }
    }
}

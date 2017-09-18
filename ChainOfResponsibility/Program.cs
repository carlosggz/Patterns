using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            app.Use(new UsersMiddleware());
            app.Use(new ProductsMiddleware());
            app.Use(new ReportsMiddleware());

            app.ProcessRequest(new Request() { Action = "user", Value = "12" });
            app.ProcessRequest(new Request() { Action = "other", Value = "34" });
            app.ProcessRequest(new Request() { Action = "report", Value = "56" });
            app.ProcessRequest(new Request() { Action = "product", Value = "78" });

            Console.WriteLine("Press ENTER to end...");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var site1 = new WebSiteObserver("FlightObserver.com");
            var site2 = new WebSiteObserver("BetterPrices.com");
            var person1 = new PersonObserver("John Doe");
            var person2 = new PersonObserver("Jane Doe");

            var subject = new LastArrivalFlightSubject();
            subject.Attach(site1);
            subject.Attach(site2);
            subject.Attach(person1);
            subject.Attach(person2);

            subject.LastFlightOffer = new LasMinuteFlight() { FlightName = "ABC 12", NewPrice = 550 };
            Console.WriteLine();

            subject.Detach(site2);
            subject.Detach(person2);

            subject.LastFlightOffer = new LasMinuteFlight() { FlightName = "ABC 12", NewPrice = 450 };
            Console.WriteLine();

            Console.WriteLine("Press ENTER to end...");
            Console.ReadLine();
        }
    }
}

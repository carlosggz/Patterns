using System;

namespace Singleton
{
    [Activity(Value = ActivityType.Swin)]
    public class Swimming : IActivity
    {
        public void DoIt()
        {
            Console.WriteLine("Swimming");
        }
    }
}

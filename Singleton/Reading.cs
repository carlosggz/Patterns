using System;

namespace Singleton
{
    [Activity(Value = ActivityType.Read)]
    public class Reading : IActivity
    {
        public void DoIt()
        {
            Console.WriteLine("Reading");
        }
    }
}

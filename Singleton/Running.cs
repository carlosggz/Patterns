using System;

namespace Singleton
{
    [Activity(Value = ActivityType.Run)]
    public class Running : IActivity
    {
        public void DoIt()
        {
            Console.WriteLine("Running");
        }
    }
}

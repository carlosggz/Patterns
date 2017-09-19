using System;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();

            foreach (ActivityType activityType in Enum.GetValues(typeof(ActivityType)))
                p.Test(activityType);

            Console.WriteLine("Press ENTER to end...");
            Console.ReadLine();
        }

        private void Test(ActivityType activityType)
        {
            var singletonInstance = ActivitiesSingleton.Instance;
            Console.WriteLine($"Singleton instance id = {singletonInstance.Id}");

            var activity = singletonInstance.GetActivity(activityType);

            Console.Write($"Checking activity {activityType}: ");

            if (activity == null)
            {
                Console.WriteLine("Not found implementation");
                return;
            }

            activity.DoIt();
        }
    }
}

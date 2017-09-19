using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Singleton
{
    public sealed class ActivitiesSingleton
    {
        private Dictionary<ActivityType, Type> _activities = null;

        private ActivitiesSingleton()
        {
            _activities = new Dictionary<ActivityType, Type>();

            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(x => x == typeof(IActivity)));

            foreach (var type in types)
            {
                var attrs = System.Attribute.GetCustomAttributes(type, typeof(ActivityAttribute), true);

                if (attrs.Length == 0)
                    return;

                var attr = attrs[0] as ActivityAttribute;

                _activities.Add(attr.Value, type);
            }

            Id = DateTime.Now.Ticks;
        }

        public IActivity GetActivity(ActivityType activityType)
        {
            return !_activities.Keys.Contains(activityType) 
                ? null 
                : System.Activator.CreateInstance(_activities[activityType]) as IActivity;
        }

        public long Id { get; private set; } 

        public static ActivitiesSingleton Instance { get; } = new ActivitiesSingleton();

    }
}

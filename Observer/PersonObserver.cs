using System;

namespace Observer
{
    public class PersonObserver : Observer
    {
        public string FullName { get; private set; }

        public PersonObserver(string name)
        {
            FullName = name;
        }

        #region Observer

        public override void Update(object sender, ObserverEventArgs evt)
        {
            Console.WriteLine($"{FullName} notified of {evt.PropertyName} changed to {evt.NewValue.ToString()}");
        }

        #endregion

    }
}

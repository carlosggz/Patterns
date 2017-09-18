using System;

namespace Observer
{
    public class WebSiteObserver : Observer
    {
        public string SiteName { get; private set; }

        public WebSiteObserver(string name)
        {
            SiteName = name;
        }

        #region Observer

        public override void Update(object sender, ObserverEventArgs evt)
        {
            Console.WriteLine($"{SiteName} notified of {evt.PropertyName} changed to {evt.NewValue.ToString()}");
        }

        #endregion
    }
}

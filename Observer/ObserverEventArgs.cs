using System;

namespace Observer
{
    public class ObserverEventArgs: EventArgs
    {
        public string PropertyName { get; set; }
        public object NewValue { get; set; }
    }
}

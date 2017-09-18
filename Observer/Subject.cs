using System;

namespace Observer
{
    public abstract class Subject
    {
        private EventHandler<ObserverEventArgs> OnValueChanged;

        public void Attach(Observer observer)
        {
            OnValueChanged += observer.Update;
        }

        public void Detach(Observer observer)
        {
            OnValueChanged -= observer.Update;
        }

        protected void Notify(ObserverEventArgs evt)
        {
            OnValueChanged?.Invoke(this, evt);
        }
    }
}

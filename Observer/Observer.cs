namespace Observer
{
    public abstract class Observer
    {
        public abstract void Update(object sender, ObserverEventArgs evt);
    }
}

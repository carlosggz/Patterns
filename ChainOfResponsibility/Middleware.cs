namespace ChainOfResponsability
{
    public abstract class Middleware
    {
        public Middleware Next { get; set; }
        public abstract Response ProcessRequest(Request request);
    }
}

namespace Factory
{
    public abstract class Factory
    {
        public abstract Searcher GetSearcher();
        public abstract Mail GetMail();
    }
}

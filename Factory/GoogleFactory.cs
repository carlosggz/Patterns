namespace Factory
{
    public class GoogleSearcher : Searcher
    {
        public override string Url => "www.google.com";
    }

    public class GoogleMail : Mail
    {
        public override string Url => "mail.google.com";
    }

    public class GoogleFactory : Factory
    {
        public override Searcher GetSearcher() => new GoogleSearcher();
        public override Mail GetMail() => new GoogleMail();
    }
}

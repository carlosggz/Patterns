namespace Factory
{
    public class YahooSearcher : Searcher
    {
        public override string Url => "www.yahoo.com";
    }

    public class YahooMail : Mail
    {
        public override string Url => "mail.yahoo.com";
    }

    public class YahooFactory : Factory
    {
        public override Searcher GetSearcher() => new YahooSearcher();
        public override Mail GetMail() => new YahooMail();
    }
}

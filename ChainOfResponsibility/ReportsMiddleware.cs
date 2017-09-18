namespace ChainOfResponsability
{
    public class ReportsMiddleware : Middleware
    {
        public override Response ProcessRequest(Request request)
        {
            if (request.Action == "report")
            {
                //Do some processing
                return new Response() { Value = $"Processed report with filter {request.Value}" };
            }

            return Next?.ProcessRequest(request);
        }
    }
}

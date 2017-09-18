namespace ChainOfResponsability
{
    public class ProductsMiddleware : Middleware
    {
        public override Response ProcessRequest(Request request)
        {
            if (request.Action == "product")
            {
                //Do some processing
                return new Response() { Value = $"Processed product with id {request.Value}" };
            }

            return Next?.ProcessRequest(request);
        }
    }
}

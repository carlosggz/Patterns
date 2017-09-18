namespace ChainOfResponsability
{
    public class UsersMiddleware : Middleware
    {
        public override Response ProcessRequest(Request request)
        {
            if (request.Action == "user")
            {
                //Do some processing
                return new Response() { Value = $"Processed user with id {request.Value}" };
            }

            return Next?.ProcessRequest(request);
        }
    }
}

using System;
using System.Collections.Generic;

namespace ChainOfResponsability
{
    public class Application
    {
        private List<Middleware> _middlewares = new List<Middleware>();

        public void Use(Middleware middleware)
        {
            if (_middlewares.Count > 0)
                _middlewares[_middlewares.Count-1].Next = middleware;

            _middlewares.Add(middleware);
        }

        public void ProcessRequest(Request request)
        {
            var response = _middlewares.Count == 0 ? null : _middlewares[0].ProcessRequest(request);

            if (response == null)
                Console.WriteLine($"Unknow operation {request.Action}");
            else
                Console.WriteLine(response.Value);
        }
    }
}

using BusinessObjects.Models;

namespace Presentation
{
    public class HttpHandler
    {
        public static HttpHandler Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new HttpHandler();
                }

                return _singleton;
            }
        }

        private static HttpHandler _singleton = null;

        public string HandleRequest(HttpRequest httpRequest)
        {
            Console.WriteLine("######################");
            Console.WriteLine(httpRequest.Method);
            Console.WriteLine(httpRequest.Target);
            Console.WriteLine(httpRequest.Version);
            Console.WriteLine(httpRequest.ContentLength);
            Console.WriteLine(httpRequest.ContentType);
            Console.WriteLine(httpRequest.Body);
            Console.WriteLine("######################");

            string result = "{\"Username\":\"Admin\", \"Password\":\"Admin\"}";

            string response = "HTTP/1.1 200 OK" + Environment.NewLine +
                              "Content-Length: " + result.Length + Environment.NewLine +
                              "Content-Type: " + "application/json" + Environment.NewLine +
                              Environment.NewLine +
                              result + Environment.NewLine + Environment.NewLine;

            return response;
        }
    }
}

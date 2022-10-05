using BusinessObjects.Models;

namespace Presentation
{

    public class HttpParser
    {

        public static HttpParser Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new HttpParser();
                }

                return _singleton;
            }
        }

        private static HttpParser _singleton = null;

        public HttpRequest Parse(string request)
        {
            string[] tokens = request.Split("\r\n");

            string[] line1 = tokens[0].Split(" ");

            string method = line1[0];
            string target = line1[1];
            string version = line1[2];

            int contentLength = 0;
            string contentType = null;
            foreach (string token in tokens)
            {
                if (token.StartsWith("Content-Length:"))
                {
                    contentLength = Convert.ToInt32(token.Split(" ")[1]);
                }

                if (token.StartsWith("Content-Type:"))
                {
                    contentType = token.Split(" ")[1];
                }
            }

            int index = Array.FindIndex(tokens, row => row.Equals("")) + 1;
            string body = null;
            for (; index < tokens.Length; index++)
            {
                body += tokens[index];
            }

            return new HttpRequest(method, target, version, contentLength, contentType, body);

        }

    }

}

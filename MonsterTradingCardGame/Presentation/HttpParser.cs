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

        public HttpRequest HttpRequest { get; private set; }
        public bool HasFinishedParsing { get; set; } = false;

        private string _httpHeader;
        private string _httpMethod;
        private string _httpTarget;
        private string _httpVersion;
        private int _httpContentLength;
        private string _httpContentType;
        private string _httpBody;
        private bool _hasBody = false;

        public void Parse(string request)
        {
            if (!_hasBody)
            {
                ParseHeader(request);
            }
            else
            {
                HttpRequest = new HttpRequest(
                    _httpMethod,
                    _httpTarget,
                    _httpVersion,
                    _httpContentLength,
                    _httpContentType,
                    request
                );
                HasFinishedParsing = true;
                _hasBody = false;
            }
        }

        private void ParseHeader(string request)
        {
            _httpHeader = request.Replace("\r\n", " "); ;
            string[] tokens = _httpHeader.Split(" ");

            _httpMethod = tokens[0];
            _httpTarget = tokens[1];
            _httpVersion = tokens[2];

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "Content-Length:" && i < tokens.Length - 1)
                {
                    _httpContentLength = tokens[i + 1] != "" ? Convert.ToInt32(tokens[i + 1]) : 0;
                }
            }

            if (_httpContentLength > 0)
            {
                _hasBody = true;

                for (int i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i] == "Content-Type:" && i < tokens.Length - 1)
                    {
                        _httpContentType = tokens[i + 1];
                    }
                }
            }
            else
            {
                HttpRequest = new HttpRequest(
                    _httpMethod, 
                    _httpTarget, 
                    _httpVersion, 
                    _httpContentLength, 
                    null, 
                    null
                    );
                HasFinishedParsing = true;
            }
        }
    }
}

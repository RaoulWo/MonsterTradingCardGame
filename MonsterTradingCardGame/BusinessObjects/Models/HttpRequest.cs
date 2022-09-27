
namespace BusinessObjects.Models
{
    public class HttpRequest
    {
        public string Method { get; set; }
        public string Target { get; set; }
        public string Version { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }

        public HttpRequest(
            string method, 
            string target, 
            string version, 
            int contentLength,
            string contentType,
            string body
            )
        {
            Method = method;
            Target = target;
            Version = version;
            ContentLength = contentLength;
            ContentType = contentType;
            Body = body;
        }
    }
}

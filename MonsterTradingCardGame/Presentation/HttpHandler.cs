using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
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

        public HttpRequest HttpRequest { get; private set; }

        private delegate Task<string> CallBack(HttpRequest httpRequest);

        public async Task<string> HandleRequest(HttpRequest httpRequest)
        {
            HttpRequest = httpRequest;

            string response;

            try
            {
                response = await TryHandleRequest();
            }
            catch (ArgumentNullException e)
            {
                response = HttpRequest.Version + " 400 Bad Request" + Environment.NewLine +
                           "Content-Length: " + 0 + Environment.NewLine +
                           "Content-Type: " + "application/json" + Environment.NewLine +
                           Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            catch (NotImplementedException e)
            {
                response = HttpRequest.Version + " 501 Not Implemented" + Environment.NewLine +
                           "Content-Length: " + 0 + Environment.NewLine +
                           "Content-Type: " + "application/json" + Environment.NewLine +
                           Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            catch (KeyNotFoundException e)
            {
                response = HttpRequest.Version + " 404 Not Found" + Environment.NewLine +
                           "Content-Length: " + 0 + Environment.NewLine +
                           "Content-Type: " + "application/json" + Environment.NewLine +
                           Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            catch (Exception e)
            {
                response = HttpRequest.Version + " 500 Internal Server Error" + Environment.NewLine +
                           "Content-Length: " + 0 + Environment.NewLine +
                           "Content-Type: " + "application/json" + Environment.NewLine +
                           Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }

            return response;
        }

        private async Task<string> TryHandleRequest()
        {
            if (HttpRequest == null)
            {
                throw new ArgumentNullException();
            }

            if (HttpRequest.Method == null)
            {
                throw new ArgumentNullException();
            }

            if (HttpRequest.Target == null)
            {
                throw new ArgumentNullException();
            }

            if (HttpRequest.Version == null)
            {
                throw new ArgumentNullException();
            }

            if (HttpRequest.ContentLength > 0 && HttpRequest.ContentType == null)
            {
                throw new ArgumentNullException();
            }

            if (HttpRequest.ContentLength > 0 && HttpRequest.Body == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                return await DelegateRequest();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<string> DelegateRequest()
        {
            string response = null;

            try
            {
                if (HttpRequest.Target.StartsWith("/users"))
                {
                    response = await DelegateUserRequest();
                }
                else if (HttpRequest.Target.StartsWith("/sessions"))
                {
                    response = await DelegateSessionRequest();
                }
                else if (HttpRequest.Target.StartsWith("/packages"))
                {
                    response = await DelegatePackageRequest();
                }
                else if (HttpRequest.Target.StartsWith("/transactions/packages"))
                {
                    response = await DelegateTransactionPackageRequest();
                }
                else if (HttpRequest.Target.StartsWith("/cards"))
                {
                    response = await DelegateCardRequest();
                }
                else if (HttpRequest.Target.StartsWith("/deck"))
                {
                    response = await DelegateDeckRequest();
                }
                else if (HttpRequest.Target.StartsWith("/stats"))
                {
                    response = await DelegateStatRequest();
                }
                else if (HttpRequest.Target.StartsWith("/score"))
                {
                    response = await DelegateScoreRequest();
                }
                else if (HttpRequest.Target.StartsWith("/tradings"))
                {
                    response = await DelegateTradingRequest();
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        private async Task<string> DelegateUserRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    if (HttpRequest.Target == "/users")
                        response = await CreateResponse(Controllers.UserController.Singleton.GetAll);
                    else if (Regex.IsMatch(HttpRequest.Target, "/users/.+"))
                        response = await CreateResponse(Controllers.UserController.Singleton.GetById);
                    else
                        throw new KeyNotFoundException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegateSessionRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegatePackageRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegateTransactionPackageRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegateCardRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegateDeckRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegateStatRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegateScoreRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> DelegateTradingRequest()
        {
            string response = null;

            switch (HttpRequest.Method)
            {
                case "GET":
                    throw new NotImplementedException();
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                case "PATCH":
                    throw new NotImplementedException();
                    break;
                case "PUT":
                    throw new NotImplementedException();
                    break;
                case "DELETE":
                    throw new NotImplementedException();
                    break;
            }

            return response;
        }

        private async Task<string> CreateResponse(CallBack callBack)
        {
            string result = await callBack(HttpRequest);

            string response = HttpRequest.Version + " 200 OK" + Environment.NewLine +
                              "Content-Length: " + result.Length + Environment.NewLine +
                              "Content-Type: " + "application/json" + Environment.NewLine +
                              Environment.NewLine +
                              result + Environment.NewLine + Environment.NewLine;

            return response;
        }
    }
}

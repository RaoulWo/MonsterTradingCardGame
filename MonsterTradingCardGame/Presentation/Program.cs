using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            TcpListener server = null;
            HttpParser httpParser = HttpParser.Singleton;
            HttpHandler httpHandler = HttpHandler.Singleton;

            try
            {
                // Set the TcpListener on port 10001.
                Int32 port = 10001;
                IPAddress localAddress = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddress, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data.
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection ...");

                    // Perform a blocking call to accept requests.
                    TcpClient client = await server.AcceptTcpClientAsync();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing.
                    NetworkStream stream = client.GetStream();

                    int size = 0;

                    // Loop to receive all the data sent by the client
                    while ((size = await stream.ReadAsync(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to an ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, size);
                        Console.WriteLine("RECEIVED: {0}", data);

                        // Process the data sent by the client.
                        httpParser.Parse(data);

                        if (httpParser.HasFinishedParsing)
                        {
                            httpParser.HasFinishedParsing = false;

                            string response = httpHandler.HandleRequest(httpParser.HttpRequest);

                            // Send back a response.
                            stream.Write(Encoding.ASCII.GetBytes(response));
                            Console.WriteLine("SENT: {0}", response);
                        }
                    }

                    // Shutdown and end connection
                    client.Close();
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }
    }
}
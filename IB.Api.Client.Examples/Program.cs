using IB.Api.Client.Model;

namespace IB.Api.Client.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //decimal check your connection details within your TWS/Gateway settings
            var connectionDetails = new ConnectionDetails
            {
                Host = "127.0.0.1",
                Port = 4002,
                ClientId = 0
            };
            RequestNews.RunGetNewsProviders(connectionDetails);
            Common.KeepConsoleAlive();
        }
    }
}

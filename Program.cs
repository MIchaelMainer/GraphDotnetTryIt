using Microsoft.Graph.Auth;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace GraphDotNetInTheBrowser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var clientId = System.Environment.GetEnvironmentVariable("test_client_id");
            var userName = System.Environment.GetEnvironmentVariable("test_user_name");
            var password = System.Environment.GetEnvironmentVariable("test_password");


            IPublicClientApplication clientApplication = UsernamePasswordProvider.CreateClientApplication(clientId);

            string[] scopes = { "User.Read" };
            UsernamePasswordProvider authenticationProvider = new UsernamePasswordProvider(clientApplication, scopes);

            GraphServiceClient graphClient = new GraphServiceClient(authenticationProvider);

            #region say_hello
            User me = await graphClient.Me.Request().WithUsernamePassword(userName, password).GetAsync();

            Console.WriteLine($"My givenname: {me.GivenName}");
            Console.WriteLine($"My email: {me.Mail}");
            //Console.WriteLine($"My title: {me.JobTitle}");
            #endregion
        }
    }
}

using Microsoft.SharePoint.Client.NetCore;
using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Set url and account
            string url = "https://pnprocks.sharepoint.com";
            var userName = "admin@pnprocks.onmicrosoft.com";
            SecureString securePassword = new SecureString();
            var password = "pass@word1";
            foreach (char item in password)
            {
                securePassword.AppendChar(item);
            }

            //Setup
            var context = new ClientContext(url);
            context.Credentials = new SharePointOnlineCredentials(userName, securePassword, password);

            //CSOM for .NET Core
            var site = context.Site;
            var web = context.Web;
            context.Load(site);
            context.Load(
                web, 
                w => w.Title, 
                w => w.ServerRelativeUrl,
                w => w.PreviewFeaturesEnabled, 
                w => w.QuickLaunchEnabled);

            //Execute...
            System.Console.WriteLine("Getting data for: " + url);
            context.ExecuteQuery();
            System.Console.WriteLine();

            //Output
            System.Console.WriteLine("Site object loaded...");
            System.Console.WriteLine("Site title: " + site.Id);
            System.Console.WriteLine("Site url: " + site.ServerRelativeUrl);
            System.Console.WriteLine("Site CompatibilityLevel: " + site.CompatibilityLevel);
            System.Console.WriteLine();

            System.Console.WriteLine("Web object loaded...");
            System.Console.WriteLine("Web Title: " + web.Title);
            System.Console.WriteLine("Web ServerRelativeUrl: " + web.ServerRelativeUrl);
            System.Console.WriteLine("Web PreviewFeaturesEnabled: " + web.PreviewFeaturesEnabled);
            System.Console.WriteLine("Web QuickLaunchEnabled: " + web.QuickLaunchEnabled);
            System.Console.WriteLine();

            System.Console.WriteLine("Ready.");
            System.Console.ReadKey();
        }
    }
}

using Microsoft.SharePoint.Client.NetCore;
using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Operating system info: " + RuntimeInformation.OSDescription);
            System.Console.WriteLine();

            // Set url and account
            #region Get Password
            string url = "https://pnprocks.sharepoint.com";
            var userName = "admin@pnprocks.onmicrosoft.com";
            SecureString securePassword = new SecureString();
            var password = "pass@word1";
            foreach (char item in password)
            {
                securePassword.AppendChar(item);
            } 
            #endregion

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
                w => w.CurrentUser,
                w => w.ServerRelativeUrl,
                w => w.PreviewFeaturesEnabled, 
                w => w.QuickLaunchEnabled,
                w => w.SiteUsers,
                w => w.Lists);

            //Execute...
            System.Console.WriteLine();
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
            System.Console.WriteLine("Web Current User: " + web.CurrentUser.Title + " " + web.CurrentUser.Email);
            System.Console.WriteLine("Web ServerRelativeUrl: " + web.ServerRelativeUrl);
            System.Console.WriteLine("Web PreviewFeaturesEnabled: " + web.PreviewFeaturesEnabled);
            System.Console.WriteLine("Web QuickLaunchEnabled: " + web.QuickLaunchEnabled);

            foreach (var user  in web.SiteUsers)
            {
                System.Console.WriteLine("\t Web SiteUser:" + user.Title + " " + user.Email);
            }
            System.Console.WriteLine();

            foreach (var list in web.Lists)
            {
                System.Console.WriteLine("\t Web List:" + list.Title + " item count: " + list.ItemCount);
            }


            System.Console.WriteLine();

            System.Console.WriteLine("CSOM calls in .NET Core completed. THIS JUST HAPPENED!.");
            if (RuntimeInformation.OSDescription.StartsWith("Microsoft"))
                { System.Console.ReadKey(); }
        }
    }
}

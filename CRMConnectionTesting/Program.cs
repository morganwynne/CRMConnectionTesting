using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Tooling.CrmConnectControl;

namespace CRMConnectionTesting
{
    // Library Reference https://docs.microsoft.com/en-us/dotnet/api/?view=dynamics-xrmtooling-ce-9
    // Build Windows client applications using the XRM tools https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/build-windows-client-applications-xrm-tools
    // Sample https://github.com/microsoft/PowerApps-Samples/tree/master/cds/Xrm%20Tooling/Quick%20start%20for%20XRM%20Tooling%20API

    // Instance Web API: https://mediabardsandbox.api.crm3.dynamics.com/api/data/v9.2/
    // Instance Reference ID: 312d3ad4-e79e-49f9-8719-3b98188d3460
    // Instance Reference Unique Name: 312d3ad4e79e49f987193b98188d3460
    // Discovery Web API: https://disco.crm3.dynamics.com/api/discovery/v9.2/
    // Organization Service: https://mediabardsandbox.api.crm3.dynamics.com/XRMServices/2011/Organization.svc
    // Discovery Service: https://disco.crm3.dynamics.com/XRMServices/2011/Discovery.svc

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello, World!");

            do // https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            {
                while (!Console.KeyAvailable)
                { }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

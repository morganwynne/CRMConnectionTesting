using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Tooling.CrmConnectControl;

namespace CRMConnectionTesting
{
    // Library Reference https://docs.microsoft.com/en-us/dotnet/api/?view=dynamics-xrmtooling-ce-9
    // Build Windows client applications using the XRM tools https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/build-windows-client-applications-xrm-tools
    // Sample https://github.com/microsoft/PowerApps-Samples/tree/master/cds/Xrm%20Tooling/Quick%20start%20for%20XRM%20Tooling%20API

    // CRMServiceProxy Connection Method https://arunpotti.com/2014/12/09/connect-to-crm-online-or-on-premise-using-c/

    public class Program
    {
        private const string DynamicsCRM_DiscoveryWebAPI = "https://disco.crm3.dynamics.com/api/discovery/v9.2/";
        private const string DynamicsCRM_OrganizationService = "https://mediabardsandbox.api.crm3.dynamics.com/XRMServices/2011/Organization.svc";
        private const string DynamicsCRM_DiscoveryService = "https://disco.crm3.dynamics.com/XRMServices/2011/Discovery.svc";

        private const string DynamicsCRM_Mediabard_URL = "https://mediabardsandbox.crm3.dynamics.com";
        private const string DynamicsCRM_Mediabard_InstanceWebAPI = "https://mediabardsandbox.api.crm3.dynamics.com/api/data/v9.2/";
        private const string DynamicsCRM_Mediabard_InstanceReferenceID = "312d3ad4-e79e-49f9-8719-3b98188d3460";
        private const string DynamicsCRM_Mediabard_InstanceReferenceUniqueName = "312d3ad4e79e49f987193b98188d3460";

        private const string DynamicsCRM_Mediabard_TestUserUsername = "testuser@mediabard.onmicrosoft.com";
        private const string DynamicsCRM_Mediabard_TestUserPassword = "Thisis1userfortesting";

        public static void Main( string[] args )
        {
            // TODO: Most of these could be replaced by unit testing, I'm sure of it.

            OrganizationServiceConnection MediabardCRMOrganizationService = new OrganizationServiceConnection()
            {
                UserName = DynamicsCRM_Mediabard_TestUserUsername,
                Password = DynamicsCRM_Mediabard_TestUserPassword,
                SoapOrgServiceUri = DynamicsCRM_OrganizationService
            };
            CRMConnectionTests.TestOrganizationServiceConnection( MediabardCRMOrganizationService );

            CRMServiceClientConnection MediabardCRMServiceClient = new CRMServiceClientConnection()
            {
                UserName = DynamicsCRM_Mediabard_TestUserUsername,
                Url = DynamicsCRM_Mediabard_URL
            };
            CRMConnectionTests.TestCRMServiceClientConnection( MediabardCRMServiceClient );

            do // https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            {
                while( !Console.KeyAvailable )
                { }
            }
            while( Console.ReadKey( true ).Key != ConsoleKey.Escape );
        }

    }
}

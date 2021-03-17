using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
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
        private static IOrganizationService _service;

        private const string DynamicsCRM_DiscoveryWebAPI = "https://disco.crm3.dynamics.com/api/discovery/v9.2/";
        private const string DynamicsCRM_OrganizationService = "https://mediabardsandbox.api.crm3.dynamics.com/XRMServices/2011/Organization.svc";
        private const string DynamicsCRM_DiscoveryService = "https://disco.crm3.dynamics.com/XRMServices/2011/Discovery.svc";

        private const string DynamicsCRM_Mediabard_InstanceWebAPI = "https://mediabardsandbox.api.crm3.dynamics.com/api/data/v9.2/";
        private const string DynamicsCRM_Mediabard_InstanceReferenceID = "312d3ad4-e79e-49f9-8719-3b98188d3460";
        private const string DynamicsCRM_Mediabard_InstanceReferenceUniqueName = "312d3ad4e79e49f987193b98188d3460";

        private const string DynamicsCRM_Mediabard_TestUserUsername = "testuser@mediabard.onmicrosoft.com";
        private const string DynamicsCRM_Mediabard_TestUserPassword = "Thisis1userfortesting";

        public static void Main( string[] args )
        {
            ConnectToMSCRM( DynamicsCRM_Mediabard_TestUserUsername, DynamicsCRM_Mediabard_TestUserPassword, DynamicsCRM_OrganizationService );

            Guid userid = ( (WhoAmIResponse)_service.Execute( new WhoAmIRequest() ) ).UserId;
            if( userid != Guid.Empty )
            {
                Console.WriteLine( "Connection Established Successfully\n" );

                var accountsQuery = new QueryExpression( "account" )
                {
                    ColumnSet = new ColumnSet( true )
                };

                // Run the query against the CRM
                var accounts = _service.RetrieveMultiple( accountsQuery ).Entities;

                foreach( var account in accounts )
                {
                    Console.WriteLine( account.Attributes["name"] + " " + account.Attributes["emailaddress1"] );
                }
            }

            do // https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            {
                while( !Console.KeyAvailable )
                { }
            }
            while( Console.ReadKey( true ).Key != ConsoleKey.Escape );
        }

        /// <summary>
        /// Connect the Organization Service to the corresponding organization using the given username and password.
        /// </summary>
        private static void ConnectToMSCRM( string UserName, string Password, string SoapOrgServiceUri )
        {
            try
            {
                ClientCredentials credentials = new ClientCredentials();

                credentials.UserName.UserName = UserName;
                credentials.UserName.Password = Password;

                Uri serviceUri = new Uri( SoapOrgServiceUri );

                OrganizationServiceProxy proxy = new OrganizationServiceProxy( serviceUri, null, credentials, null );
                proxy.EnableProxyTypes();

                _service = (IOrganizationService)proxy;
            }
            catch( Exception ex )
            {
                Console.WriteLine( "Error while connecting to CRM " + ex.Message );
                Console.ReadKey();
            }
        }
    }
}

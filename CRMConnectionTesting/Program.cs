using Microsoft.Crm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CRMConnectionTesting
{
    // XRM Tooling Library Reference https://docs.microsoft.com/en-us/dotnet/api/?view=dynamics-xrmtooling-ce-9

    public class Program
    {
        private static ResourceManager properties = new ResourceManager( "CRMConnectionTesting.Properties.Resources", Assembly.GetExecutingAssembly() );

        public static void Main( string[] args )
        {
            var Connection = new OrganizationServiceProxyConnection()
            {
                UserName = properties.GetString( "Dynamics_Instance_TestUserUsername" ),
                Password = properties.GetString( "Dynamics_Instance_TestUserPassword" ),
                SoapOrgServiceUri = properties.GetString( "Dynamics_OrganizationService" )
            };

            Connection.ConnectToMSCRM();

            if( Connection.Connected )
            {
                Connection.UpdateRecordState( "opportunity", new Guid( "6634f32e-4be5-e511-80fe-00155d09ab01" ), 1, 3 );
            }
            else
            {
                Console.WriteLine( "Connection failed" );
            }

            do // https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            {
                while( !Console.KeyAvailable )
                { }
            }
            while( Console.ReadKey( true ).Key != ConsoleKey.Escape );
        }

        public static void ConnectionTesting()
        {
            Console.WriteLine( "Connection Test 1: Connecting Using Service Proxy and Office365 Authentication" );
            OrganizationServiceProxyConnection MediabardCRMOrganizationServiceProxy = new OrganizationServiceProxyConnection()
            {
                UserName = properties.GetString( "Dynamics_Instance_TestUserUsername" ),
                Password = properties.GetString( "Dynamics_Instance_TestUserPassword" ),
                SoapOrgServiceUri = properties.GetString( "Dynamics_OrganizationService" )
            };
            CRMConnectionTests.TestOrganizationServiceProxyConnection( MediabardCRMOrganizationServiceProxy );
            CRMConnectionTests.TestOrganizationServiceRetrieve( MediabardCRMOrganizationServiceProxy.Service );
            Console.WriteLine( "Connection Test 1: Finished" + Environment.NewLine );

            Console.WriteLine( "Connection Test 2: Connecting using CRM Service Client and OAuth Authentication" );
            CRMServiceClientConnection MediabardCRMServiceClient = new CRMServiceClientConnection()
            {
                UserName = properties.GetString( "Dynamics_Instance_TestUserUsername" ),
                Url = properties.GetString( "Dynamics_Instance_URL" )
            };
            CRMConnectionTests.TestCRMServiceClientConnection( MediabardCRMServiceClient );
            CRMConnectionTests.TestOrganizationServiceRetrieve( MediabardCRMServiceClient.Service );
            Console.WriteLine( "Connection Test 2: Finished" + Environment.NewLine );
        }
    }
}

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMConnectionTesting
{
    public static class CRMConnectionTests
    {
        /// <summary>
        /// Tests connecting to the CRM using the OrganizationServiceProxy class and Office365 authentication
        /// </summary>
        public static void TestOrganizationServiceProxyConnection( OrganizationServiceProxyConnection organizationServiceConnection )
        {
            Console.WriteLine( "Creating Organization Service Connection" );
            organizationServiceConnection.ConnectToMSCRM();

            if( organizationServiceConnection.Connected )
                Console.WriteLine( "Creation Organization Service Successful" );
            else
                Console.WriteLine( "Creating Organization Service Failure" );
        }
        
        /// <summary>
        /// Tests connecting to the CRM using the CRMServiceClient class and OAuth authentication
        /// </summary>
        public static void TestCRMServiceClientConnection( CRMServiceClientConnection cRMServiceClientConnection )
        {
            Console.WriteLine( "Creating Service Client Connection" );
            cRMServiceClientConnection.ConnectToMSCRM();

            if( cRMServiceClientConnection.Connected )
                Console.WriteLine( "Creating Service Client Connection Successful" );
            else
                Console.WriteLine( "Creating Service Client Connection Failure" );
        }

        /// <summary>
        /// Tests retrieving data from a connected IOrganizationService object
        /// </summary>
        public static void TestOrganizationServiceRetrieve( IOrganizationService organizationService )
        {
            try
            {
                Console.WriteLine( "Testing Service Client Retrieve" );
                var accountsQuery = new QueryExpression( "account" )
                {
                    ColumnSet = new ColumnSet( true )
                };

                // Run the query against the CRM
                var accounts = organizationService.RetrieveMultiple( accountsQuery ).Entities;

                foreach( var account in accounts )
                {
                    Console.WriteLine( account.Attributes["name"] + " " + account.Attributes["emailaddress1"] );
                }

                Console.WriteLine( "Testing Service Client Retrieve Successful" );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.Message );
                Console.WriteLine( "Creating Service Client Connection Failure" );
            }
        }
    }
}

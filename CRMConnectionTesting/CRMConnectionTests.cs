using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace CRMConnectionTesting
{
    // TODO: Switch this to unit testing, seriously
    public static class CRMConnectionTests
    {
        /// <summary>
        /// Tests connecting to the CRM using the OrganizationServiceProxy class and Office365 authentication
        /// </summary>
        public static void TestOrganizationServiceProxyConnection( OrganizationServiceProxyConnection organizationServiceConnection )
        {
            Console.WriteLine( "Creating Organization Service Proxy Connection" );

            try
            {
                organizationServiceConnection.ConnectToMSCRM();

                if( organizationServiceConnection.Connected )
                    Console.WriteLine( "Creation Organization Service Proxy Successful" );
                else
                    Console.WriteLine( "Creating Organization Service Proxy Failure" );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.Message );
                Console.WriteLine( "Creating Organization Service Proxy Failure" );
            }
        }
        
        /// <summary>
        /// Tests connecting to the CRM using the CRMServiceClient class and OAuth authentication
        /// </summary>
        public static void TestCRMServiceClientConnection( CRMServiceClientConnection cRMServiceClientConnection )
        {
            Console.WriteLine( "Creating CRM Service Client Connection" );

            try
            {
                cRMServiceClientConnection.ConnectToMSCRM();

                if( cRMServiceClientConnection.Connected )
                    Console.WriteLine( "Creating CRM Service Client Connection Successful" );
                else
                    Console.WriteLine( "Creating CRM Service Client Connection Failure" );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.Message );
                Console.WriteLine( "Creating CRM Service Client Connection Failure" );
            }
        }

        /// <summary>
        /// Tests retrieving data from a connected IOrganizationService object
        /// </summary>
        public static void TestOrganizationServiceRetrieve( IOrganizationService organizationService )
        {
            Console.WriteLine( "Testing Organization Service Retrieve" );

            // NullReferenceExceptions will stop debugging by default so I threw this one in here as extra
            if( organizationService == null )
            {
                Console.WriteLine( "Testing Organization Service Retrieve Failure" );
                return;
            }

            try
            {
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

                Console.WriteLine( "Testing Organization Service Retrieve Successful" );
            }
            catch( NullReferenceException ex )
            {
                Console.WriteLine( ex.Message );
                Console.WriteLine( "Testing Organization Service Retrieve Failure" );
            }
        }
    }
}

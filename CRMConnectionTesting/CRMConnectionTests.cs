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
        public static bool TestOrganizationServiceConnection( OrganizationServiceConnection organizationServiceConnection )
        {
            try
            {
                var accountsQuery = new QueryExpression( "account" )
                {
                    ColumnSet = new ColumnSet( true )
                };

                // Run the query against the CRM
                var accounts = organizationServiceConnection.Service.RetrieveMultiple( accountsQuery ).Entities;

                foreach( var account in accounts )
                {
                    Console.WriteLine( account.Attributes["name"] + " " + account.Attributes["emailaddress1"] );
                }
            }
            catch( Exception ex )
            {
                Console.Write( ex.Message );
                return false;
            }

            return true;
        }
    }
}

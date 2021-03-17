using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;

using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace CRMConnectionTesting
{
    public class OrganizationServiceProxyConnection
    {
        public IOrganizationService Service { get; private set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string SoapOrgServiceUri { get; set; }

        public bool Connected
        {
            get
            {
                // TODO: Seems like a weird way to test the connection. Research alternatives later.

                bool connected = ( (WhoAmIResponse)Service.Execute( new WhoAmIRequest() ) ).UserId != null;
                return connected;
            }
        }

        public OrganizationServiceProxyConnection()
        {

        }

        /// <summary>
        /// Connect the Organization Service to the corresponding organization using the given username and password.
        /// </summary>
        public void ConnectToMSCRM()
        {
            try
            {
                ClientCredentials credentials = new ClientCredentials();

                credentials.UserName.UserName = UserName;
                credentials.UserName.Password = Password;

                Uri serviceUri = new Uri( SoapOrgServiceUri );

                OrganizationServiceProxy proxy = new OrganizationServiceProxy( serviceUri, null, credentials, null );
                proxy.EnableProxyTypes();

                Service = (IOrganizationService)proxy;
            }
            catch( Exception ex )
            {
                Console.WriteLine( "Error while connecting to CRM " + ex.Message );
                Console.ReadKey();
            }
        }
    }
}

using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;

namespace CRMConnectionTesting
{
    public class CRMServiceClientConnection
    {
        public IOrganizationService Service { get; private set; }

        public string UserName { get; set; }
        public string Url { get; set; }
        public string AuthType { get; set; } = "OAuth";
        public string AppId { get; set; } = "51f81489-12ee-4a9e-aaae-a2591f45987d";
        public string RedirectUri { get; set; } = "app://58145B91-0C36-4500-8554-080854F2AC97";
        public string LoginPrompt { get; set; } = "Auto";

        public bool Connected {
            get
            {
                bool connected = ( (WhoAmIResponse)Service.Execute( new WhoAmIRequest() ) ).UserId != null;
                return connected;
            }
        }

        public CRMServiceClientConnection()
        {

        }

        public void ConnectToMSCRM()
        {
            // Could not get it to grab the connection string in the app.config file
            string connectionString = "AuthType=" + AuthType + ";Username=" + UserName + ";Url=" + Url + ";AppId=" + AppId + ";RedirectUri=" + RedirectUri + ";LoginPrompt=" + LoginPrompt;

            Service = (IOrganizationService)new CrmServiceClient( connectionString );
        }
    }
}

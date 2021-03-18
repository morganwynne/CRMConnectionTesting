
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace CRMConnectionTesting
{
    /// <summary>
    /// Connects to a Microsoft Dynamics 365 CRM using the CrmServiceClient object and OAuth authentication
    /// </summary>
    public class CRMServiceClientConnection
    {
        public IOrganizationService Service { get; private set; }

        public CrmServiceClient ServiceClient { get; private set; }

        public string UserName { get; set; }
        public string Url { get; set; }
        public string AuthType { get; set; } = "OAuth";
        public string AppId { get; set; } = "51f81489-12ee-4a9e-aaae-a2591f45987d";
        public string RedirectUri { get; set; } = "app://58145B91-0C36-4500-8554-080854F2AC97";
        public string LoginPrompt { get; set; } = "Auto";

        public string ConnectionString
        {
            get
            {
                return
                    "AuthType=" + AuthType + ";" +
                    "Username=" + UserName + ";" +
                    "Url=" + Url + ";" +
                    "AppId=" + AppId + ";" +
                    "RedirectUri=" + RedirectUri + ";" +
                    "LoginPrompt=" + LoginPrompt + ";";
            }
        }

        public bool Connected {
            get
            {
                bool connected = ( Service != null ) && ( ( (WhoAmIResponse)Service.Execute( new WhoAmIRequest() ) ).UserId != null );
                return connected;
            }
        }

        public CRMServiceClientConnection()
        {

        }

        public void ConnectToMSCRM()
        {
            // Could not get it to grab the connection string in the app.config file
            ServiceClient = new CrmServiceClient( this.ConnectionString );
            Service = (IOrganizationService)ServiceClient;
        }
    }
}

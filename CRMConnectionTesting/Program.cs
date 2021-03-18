﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMConnectionTesting
{
    // XRM Tooling Library Reference https://docs.microsoft.com/en-us/dotnet/api/?view=dynamics-xrmtooling-ce-9

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
            Console.WriteLine( "Test 1: Connecting Using Service Proxy and Office365 Authentication" );
            OrganizationServiceProxyConnection MediabardCRMOrganizationServiceProxy = new OrganizationServiceProxyConnection()
            {
                UserName = DynamicsCRM_Mediabard_TestUserUsername,
                Password = DynamicsCRM_Mediabard_TestUserPassword,
                SoapOrgServiceUri = DynamicsCRM_OrganizationService
            };
            CRMConnectionTests.TestOrganizationServiceProxyConnection( MediabardCRMOrganizationServiceProxy );
            CRMConnectionTests.TestOrganizationServiceRetrieve( MediabardCRMOrganizationServiceProxy.Service );
            Console.WriteLine( "Test 1: Finished" + Environment.NewLine );

            Console.WriteLine( "Test 2: Connecting using CRM Service Client and OAuth Authentication" );
            CRMServiceClientConnection MediabardCRMServiceClient = new CRMServiceClientConnection()
            {
                UserName = DynamicsCRM_Mediabard_TestUserUsername,
                Url = DynamicsCRM_Mediabard_URL
            };
            CRMConnectionTests.TestCRMServiceClientConnection( MediabardCRMServiceClient );
            CRMConnectionTests.TestOrganizationServiceRetrieve( MediabardCRMServiceClient.Service );
            Console.WriteLine( "Test 2: Finished" + Environment.NewLine );

            do // https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            {
                while( !Console.KeyAvailable )
                { }
            }
            while( Console.ReadKey( true ).Key != ConsoleKey.Escape );
        }

    }
}

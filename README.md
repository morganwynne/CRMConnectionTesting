# CRM Connection Testing

Console app created with C# and the .NET framework

## General info
This project connects to a Microsoft Dynamics 365 CRM instance using the CRMServiceClient/OAuth and OrganizationServiceProxy/Office365 methods. To test these connections, it runs a query that captures and prints the name (name) and email (emailaddress1) of all account rows in the CRM to the command line.

No filtering is done on the account query and it may take a while on larger instances.

## Technologies
Project is created with:
* .NET Framework 4.7.2
* Dynamics 365 Customer Engagement Version 9

## Setup
Cloning and running this repo will require (to my knowledge) an installation of Visual Studio with the .NET desktop development.
Clone this repo to your desktop and open in Visual Studio. Required references should be included automatically via NuGet.



## Usage
If running against the default CRM, the password for testuser@mediabard.onmicrosoft.com is Thisis1userfortesting.
To run against your own CRM, change the const values in the Program.cs file to match the values found in your Microsoft Dynamics 365 CRM's Developer Resources.

## Status
The default testing CRM will only be active until April 15th, 2021 (or earlier).
The Organization Service Proxy connection method will fail if Security Defaults is enabled against the targeted Azure account.

# StraliSolutions.CSOMSAML.Auth
The purporse of this library is to create an Authenticated ClientContext in an Claim-based SharePoint environment using Active Directoy Federation Services authentication via SAML. 

The approach works in the following way:
  1. on calling ClaimClientContext.GetAuthenticatedContext the target teamsite will be opened in a web-browser component
  2. the security token will be cached getting the authentication information from the auth cookies
  3. the ClientContext returned from ClaimClientContext will ensure that the security token is added on each http request
   
Note: The library works by using the current user context. So, the user has to be logged on to a domain where ADFS SSO is configured. In case you need to switch the user's context or you don't have an ADFS SSO configuration in place, I recommend to use https://github.com/SharePoint/PnP-Sites-Core/blob/master/Core/SAML%20authentication.md.

# Testing the component
<pre>
using Microsoft.SharePoint.Client;
using StraliSolutions.CSOMSAML.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ClientContext cxt = 
                ClaimClientContext.GetAuthenticatedContext("https://mywebapp.onmydomain.com/sites/teamsite"))
                
                { 

                    Web web = cxt.Web;
                    cxt.Load(web);

                    cxt.ExecuteQuery();//here the exception is thrown, when team site does not exist
                    Console.WriteLine("Teamsite accessible");
                 }
            }
            catch 
            {
                Console.WriteLine("Teamsite not accessible");
            }

        }
    }
}
</pre>

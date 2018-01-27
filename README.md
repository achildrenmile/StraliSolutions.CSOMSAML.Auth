# StraliSolutions.CSOMSAML.Auth
The purporse of this library is to create an Authenticated ClientContext in an Claim-based SharePoint environment using Active Directoy Federation Services authentication via SAML. 

The approach works in the following way:
  1. on calling ClaimClientContext.GetAuthenticatedContext the target teamsite will be opened in a web-browser component
  2. the security token will be cached getting the authentication information from the auth cookies
  3. the ClientContext returned from ClaimClientContext will ensure that the security token is added on each http request
   
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

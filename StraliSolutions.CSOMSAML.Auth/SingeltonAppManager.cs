using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StraliSolutions.CSOMSAML.Auth
{
    public sealed class SingeltonAppManager
    {
        private static volatile SingeltonAppManager instance;
        private static object syncRoot = new Object();
        public Dictionary<string, object> store = new Dictionary<string, object>();

        private SingeltonAppManager()
        {

        }

        public static SingeltonAppManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SingeltonAppManager();
                    }
                }

                return instance;
            }
        }

        public CookieCollection cookiesObj { get; set; }
        public string CurrentSiteURL { get; set; }
        public string CurrentUserAccount { get; set; }

        public bool UseCustomAccount { get; set; }
        public ICredentials SharepointCredentials { get; set; }
    }
}

using System;
using Microsoft.VisualBasic;

namespace JWTTokenAuthentication.Common
{
    public sealed class Settings
    {
        private static Settings _instance = null;
        private Settings()
        {
        }

        public static Settings Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Settings();
                    _instance.Appsetings = new Appsetings();
                }
                return _instance;
            }
            
        }

        public Appsetings Appsetings { get; set; }
    }

    public class Appsetings
    {
        public string JWTSecretKey { get; set; }

        public string JWTIssuer { get; set; }

        public string JWTAudience { get; set; }
    }
}

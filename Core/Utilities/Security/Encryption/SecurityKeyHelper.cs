using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption {
    public class SecurityKeyHelper {
    
        //appsettings.json a yazdığımız secretkeyi byte arrayi yapıp onu bir simetrik security key yapıyor
        public static SecurityKey CreateSecurityKey(string securityKey) {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    
    }
}

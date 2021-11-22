using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT {

    //kullanıcıya giriş için verdiğimiz token ya adı üstünde accesstoken amınakoyim
    public class AccessToken {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

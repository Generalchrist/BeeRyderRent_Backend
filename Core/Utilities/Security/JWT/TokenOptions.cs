﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT {
    public class TokenOptions {

        //appsetting.json da yazdığımız bilgileri taşıyan bir nesne
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}

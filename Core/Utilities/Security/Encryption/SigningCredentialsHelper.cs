using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption {
    public class SigningCredentialsHelper {

        //tokendeki kullanılacak algoritma ve securitykeyin verildiği yer
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}

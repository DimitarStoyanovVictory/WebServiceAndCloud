using System.Security;

namespace ConsumingWebServicesClientGrpfic
{
    public class RegistrationInfo
    {
        public RegistrationInfo()
        {
            Passwod = new SecureString();
        }

        public string Email { get; set; }

        public SecureString Passwod { get; set; }
    }
}

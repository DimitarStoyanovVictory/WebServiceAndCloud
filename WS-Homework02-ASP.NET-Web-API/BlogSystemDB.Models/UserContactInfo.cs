using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    [ComplexType]
    public class UserContactInfo
    {
        public string Facebook { get; set; }

        public string Skype { get; set; }

        public string Tweeter { get; set; }

        public string PhoneNumber { get; set; }
    }
}

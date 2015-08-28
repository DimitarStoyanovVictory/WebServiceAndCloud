using System.ComponentModel.DataAnnotations;

namespace Problem01.BlogSystemApplicationWeb.Models
{
    public class UpdateBindingModel
    {
        [Required]
        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string RegistrationDate { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string Facebook { get; set; }

        public string Skype { get; set; }

        public string Tweeter { get; set; }

        public string PhoneNumber { get; set; }
    }
}
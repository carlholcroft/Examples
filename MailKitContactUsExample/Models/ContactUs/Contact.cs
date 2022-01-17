using System.ComponentModel.DataAnnotations;

namespace MailKitContactUsExample.Models.ContactUs
{
    public class Contact
    {
        [Required]

        public string Name { get; set; }

        [Required]
        [EmailAddress]
        //[RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}


using MailKitContactUsExample.Models.ContactUs;
using MailKitContactUsExample.Services.ContactUs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MailKitContactUsExample.Pages.ContactUs
{
    public class ContactFormModel : PageModel
    {
        private readonly IFormEmailSender _emailSender;

        public ContactFormModel(IFormEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var name = Contact.Name;

            var email = Contact.Email;

            var subject = Contact.Subject;

            var message = Contact.Message;

            await _emailSender.SendEmailAsync(name, email, subject, message);



            return RedirectToPage("ThankYou");

        }
    }
}

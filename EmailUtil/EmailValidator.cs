using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmailUtil
{
    public class EmailValidator
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new EmailNotProviderException();
            }

            Regex regex = new Regex(@"^[\w0-9._%+-]+@[\w0-9.-]+\.[\w]{2,6}$");

            return regex.IsMatch(email);
        }

        public string IsSpam(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new EmailNotProviderException();
            }

            List<string> spammyDomains = new List<string>
            {
                "spam.com",
                "doggy.com",
                "es-seguro.com"
            };

            return spammyDomains.Any(d => email.Contains(d)) ? "SPAM" : "INBOX";
        }
    }
}

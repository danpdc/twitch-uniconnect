using System;
using System.Collections.Generic;
using System.Text;

namespace Twtich.Uniconnect.SharedKernel.Types
{
    public class EmailAddress : ValueObject
    {
        private EmailAddress()
        {
        }

        public string EmailName { get; private set; }
        public string Domain { get; private set; }

        public static EmailAddress Create(string emailName, string domain)
        {
            //TO DO: Add validation
            return new EmailAddress
            {
                EmailName = emailName,
                Domain = domain
            };
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EmailName;
            yield return Domain;
        }

        public override string ToString()
        {
            return string.Concat(EmailName, "@", Domain);
        }
    }
}

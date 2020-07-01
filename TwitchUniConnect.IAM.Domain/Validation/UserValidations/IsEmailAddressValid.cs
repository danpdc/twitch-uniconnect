using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.IAM.Domain.Aggregates.UserAggregate;
using Twtich.Uniconnect.SharedKernel.Interfaces;

namespace TwitchUniConnect.IAM.Domain.Validation.UserValidations
{
    public class IsEmailAddressValid : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {

            var splittedEmail = user.EmailAddress.Split('@');
            return splittedEmail.Length == 2;
        }
    }
}

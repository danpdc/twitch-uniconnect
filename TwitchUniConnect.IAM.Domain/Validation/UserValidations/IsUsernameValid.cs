using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.IAM.Domain.Aggregates.UserAggregate;
using Twtich.Uniconnect.SharedKernel.Interfaces;

namespace TwitchUniConnect.IAM.Domain.Validation.UserValidations
{
    internal class IsUsernameValid : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            var minLength = user.Username.Length > 5;
            var maxLength = user.Username.Length < 16;

            return minLength && maxLength;
        }
    }
}

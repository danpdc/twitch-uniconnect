using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.IAM.Domain.Aggregates.UserAggregate;
using Twtich.Uniconnect.SharedKernel.Interfaces;

namespace TwitchUniConnect.IAM.Domain.Validation.UserValidations
{
    internal class IsPasswordValid : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            var minLength = user.Password.Length > 5;
            var maxLength = user.Password.Length < 15;

            return minLength && maxLength;
        }
    }
}

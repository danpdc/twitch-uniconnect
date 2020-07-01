using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.IAM.Domain.Aggregates.UserAggregate;
using Twtich.Uniconnect.SharedKernel.Interfaces;

namespace TwitchUniConnect.IAM.Domain.Validation.UserValidations
{
    internal class IsUserIdValid : ISpecification<User>
    {

        public bool IsSatisfiedBy(User user)
        {
            return !(user.Id == Guid.Empty);
        }
    }
}

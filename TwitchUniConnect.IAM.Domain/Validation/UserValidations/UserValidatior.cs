using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.IAM.Domain.Aggregates.UserAggregate;

namespace TwitchUniConnect.IAM.Domain.Validation.UserValidations
{
    internal class UserValidatior
    {
        private User _user;
        public UserValidatior(User user)
        {
            _user = user;
        }

        public bool IsUserValid()
        {
            var isUserIdValid = new IsUserIdValid().IsSatisfiedBy(_user);
            var isUsernameValid = new IsUsernameValid().IsSatisfiedBy(_user);
            var isPasswordValid = new IsPasswordValid().IsSatisfiedBy(_user);
            var isEmailValid = new IsEmailAddressValid().IsSatisfiedBy(_user);

            return isUserIdValid && isUsernameValid && isPasswordValid && isEmailValid;
        }
    }
}

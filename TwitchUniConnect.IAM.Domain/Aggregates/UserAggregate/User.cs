using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml;
using TwitchUniConnect.IAM.Domain.Validation.UserValidations;
using Twtich.Uniconnect.SharedKernel.Interfaces;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUniConnect.IAM.Domain.Aggregates.UserAggregate
{
    public class User : Entity<Guid>, IAggregateRoot
    {
        #region Fields, constructors and properties
        private User(Guid id) : base(id)
        {
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        #endregion

        #region Factories
        public static User Create(Guid id, string username, string password, string emailAddres,
            string phone)
        {
            var user = new User(id);
            user.Username = username;
            user.Password = password;
            user.EmailAddress = emailAddres;
            user.PhoneNumber = phone;

            var isUserValid = new UserValidatior(user).IsUserValid();

            if (isUserValid)
                return user;
            else
            {
                user = null;
                return user;
            }
        }
        #endregion

        #region Public methods
        public void UpdateUsername(string updatedUsername)
        {
            // TO DO: Implement validation
            Username = updatedUsername;

            // TO DO: Fire event
        }

        public void ChangePassword(string newPassword)
        {
            // TO DO: Implement validation
            Password = newPassword;

            // TO DO: Fire password changed event
        }
        
        public void UpdatePhoneNumber(string newPhone)
        {
            // TO DO: Implement validation
            PhoneNumber = newPhone;

            // TO DO: Fire phone changed event
        }

        public void UpdateEmailAddress(string newEmail)
        {
            // TO DO: Implement validation
            EmailAddress = newEmail;

            // TO DO: Fire Email changed event
        }
        #endregion
    }
}

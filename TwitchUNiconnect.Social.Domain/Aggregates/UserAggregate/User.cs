using System;
using System.Collections.Generic;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Interfaces;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class User : Entity<Guid>, IAggregateRoot
    {
        #region Constructos and properties
        private User() : base(Guid.NewGuid()) { }
        private User(Guid id) : base(id)
        {

        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public UserType Type { get; private set; }
        public Name Name { get; private set; }

        #endregion
    }
}

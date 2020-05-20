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
        private List<User> _colleagues;
        private List<User> _friends;
        private List<FriendRequest> _pendingFriendRequests;
        private User() : base(Guid.NewGuid()) { }
        private User(Guid id) : base(id)
        {

        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public UserType Type { get; private set; }
        public Name Name { get; private set; }
        public Faculty Faculty { get; private set; }
        public Class Class { get; private set; }
        public string PhoneNumer { get; private set; }
        public EmailAddress Email { get; private set; }
        public IEnumerable<User> Colleagues
        {
            get { return _colleagues; }
        }

        public IEnumerable<User> Friends
        {
            get { return _friends; }
        }

        public IEnumerable<FriendRequest> PendingFriendRequests
        {
            get { return _pendingFriendRequests; }
        }

        #endregion
    }
}

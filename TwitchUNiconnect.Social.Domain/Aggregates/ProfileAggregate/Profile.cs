using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Interfaces;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class Profile : Entity<Guid>, IAggregateRoot
    {
        #region Constructos and properties
        private List<Guid> _friends;
        private List<FriendRequest> _pendingFriendRequests;
        private Profile() : base(Guid.NewGuid()) { }
        private Profile(Guid id) : base(id)
        {

        }

        public Guid UserId { get; private set; }
        public Name Name { get; private set; }
        public string PhoneNumer { get; private set; }
        public EmailAddress Email { get; private set; }

        public IEnumerable<Guid> Friends
        {
            get { return _friends; }
        }

        public IEnumerable<FriendRequest> PendingFriendRequests
        {
            get { return _pendingFriendRequests; }
        }

        #endregion

        #region Factories
        public static Profile Create(Guid id, Guid userId, Name name, EmailAddress email, string phone = null,
            IEnumerable<Guid> friends = null, IEnumerable<FriendRequest> friendRequests = null)
        {
            if (id == default)
                throw new ArgumentException("ID can't be of default value");

            var user = new Profile(id);
            user.UserId = userId;
            user.Name = name;
            user.Email = email;
            user.PhoneNumer = phone;

            user._friends = friends != null ? friends.ToList() : new List<Guid>();
            user._pendingFriendRequests = friendRequests != null ? friendRequests.ToList() : new List<FriendRequest>();


            return user;
        }
        #endregion

        #region Public methods
        public void SendFriendRequest(Profile targetUser)
        {
            var friendRequest = FriendRequest.Create(Id, targetUser.Id);
            targetUser._pendingFriendRequests.Add(friendRequest);
        }

        public void AcceptFriendRequest(Guid from)
        {
            var friendRequest = _pendingFriendRequests.FirstOrDefault(fr => fr.From == from);
            if (friendRequest == null)
                throw new ArgumentException("Friend request was not found");

            _friends.Add(from);
            _pendingFriendRequests.Remove(friendRequest);

        }

        public void RejectFriendRequest(Guid from)
        {
            var friendRequest = _pendingFriendRequests.FirstOrDefault(fr => fr.From == from);
            if (friendRequest == null)
                throw new ArgumentException("Friend request was not found");

            _pendingFriendRequests.Remove(friendRequest);
        }

        public void Unfriend(Guid profilToUnfriend)
        {
            var exFriend = _friends.FirstOrDefault(f => f == profilToUnfriend);
            if (exFriend == null)
                throw new ArgumentException("Friend not found");

            _friends.Remove(exFriend);
        }
        #endregion
    }
}

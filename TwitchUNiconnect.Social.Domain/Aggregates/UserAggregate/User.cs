using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Factories
        public static User Create(Guid id, string username, UserType type, Name name, EmailAddress email,
            string phone, string password = null, Faculty faculty = null, Class studentClass = null,
            IEnumerable<User> colleagues = null, IEnumerable<User> friends = null,
            IEnumerable<FriendRequest> friendRequests = null)
        {
            if (id == default)
                throw new ArgumentException("ID can't be of default value");

            var user = new User(id);
            user.Name = name;
            user.Username = username;
            user.Type = type;
            user.Email = email;
            user.PhoneNumer = phone;
            user.Password = password;
            user.Faculty = faculty;

            if (studentClass != null && type != UserType.Student)
                throw new ArgumentException("Only students can belong to class");

            user.Class = studentClass;
            user._colleagues = colleagues != null ? colleagues.ToList() : new List<User>();
            user._friends = friends != null ? friends.ToList() : new List<User>();
            user._pendingFriendRequests = friendRequests != null ? friendRequests.ToList() : new List<FriendRequest>();


            return user;
        }
        #endregion

        #region Public methods
        public void SendFriendRequest(User targetUser)
        {
            var friendRequest = FriendRequest.Create(Id, targetUser.Id);
            targetUser._pendingFriendRequests.Add(friendRequest);
        }

        public void AcceptFriendRequest(User from)
        {
            var friendRequest = _pendingFriendRequests.FirstOrDefault(fr => fr.From == from.Id);
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

        public void Unfriend(User user)
        {
            var exFriend = _friends.FirstOrDefault(f => f.Id == user.Id);
            if (exFriend == null)
                throw new ArgumentException("Friend not found");

            _friends.Remove(exFriend);
        }

        public void AddColleague(User user)
        {
            _colleagues.Add(user);
        }

        public void RemoveColleague(User user)
        {
            var exColleague = _colleagues.FirstOrDefault(c => c.Id == user.Id);

            if (exColleague == null)
                throw new ArgumentException("User not found");

            _colleagues.Remove(user);
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void AddFaculty(Faculty faculty)
        {
            if (Faculty != null)
                throw new ArgumentException("The specified Faculty is already assigned to the user");
            Faculty = faculty;
        }

        public void UpdateFaculty(Faculty faculty)
        {
            Faculty = faculty;
        }

        public void RemoveUserFromFaculty()
        {
            Faculty = null;
        }

        public void AssignStudentToClass(Class studentClass)
        {
            if (Type != UserType.Student)
                throw new ArgumentException("Only students can be added to a class");

            Class = studentClass;
        }

        public void RemoveStudentFromClass()
        {
            if (Class == null)
                throw new ArgumentException("The student doesn't belong to a class");

            Class = null;
        }
        #endregion
    }
}

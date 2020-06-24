using System;
using System.Collections.Generic;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class FriendRequest : ValueObject
    {
        private FriendRequest()
        {
        }

        public Guid From { get; private set; }
        public Guid To { get; private set; }
        public DateTime DateSent { get; private set; }

        public static FriendRequest Create(Guid from, Guid to)
        {
            return new FriendRequest
            {
                From = from,
                To = to,
                DateSent = DateTime.UtcNow
            };
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return From;
            yield return To;
            yield return DateSent;
        }
    }
}

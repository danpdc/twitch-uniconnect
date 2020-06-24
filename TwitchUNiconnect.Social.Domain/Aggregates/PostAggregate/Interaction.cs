using System;
using System.Collections.Generic;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.PostAggregate
{
    public class Interaction : ValueObject
    {
        public Interaction()
        {
        }

        public InteractionType Type { get; private set; }
        public Guid AuthorProfileId { get; private set; }

        public static Interaction Create(InteractionType type, Guid authorId)
        {
            return new Interaction
            {
                Type = type,
                AuthorProfileId = authorId
            };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Type;
            yield return AuthorProfileId;
        }
    }
}

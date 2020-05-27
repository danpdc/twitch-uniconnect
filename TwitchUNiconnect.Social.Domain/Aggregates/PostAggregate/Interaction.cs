using System;
using System.Collections.Generic;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.PostAggregate
{
    public class Interaction : ValueObject
    {
        public Interaction()
        {

        }

        public InteractionType Type { get; private set; }
        public Guid AuthorId { get; private set; }

        public static Interaction Create(InteractionType type, Guid authorId)
        {
            return new Interaction
            {
                Type = type,
                AuthorId = authorId
            };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Type;
            yield return AuthorId;
        }
    }
}

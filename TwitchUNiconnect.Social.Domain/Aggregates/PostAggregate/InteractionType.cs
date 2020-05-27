using System;
using System.Collections.Generic;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.PostAggregate
{
    public class InteractionType : Enumeration
    {
        public readonly InteractionType Like = new InteractionType(0, "Like");
        public readonly InteractionType Noted = new InteractionType(1, "Noted");
        
        public InteractionType(int value, string description) : base(value, description)
        {

        }
    }
}

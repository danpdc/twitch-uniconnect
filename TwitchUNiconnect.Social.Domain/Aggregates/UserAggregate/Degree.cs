using System;
using System.Collections.Generic;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class Degree : Enumeration
    {
        public static readonly Degree Bachelor = new Degree(0, "Bachaelor's");
        public static readonly Degree Master = new Degree(1, "Master's");
        public static readonly Degree Doctorate = new Degree(2, "Doctorate");
        public static readonly Degree PostDoctorate = new Degree(3, "Post-doctorate research");
        
        private Degree(int value, string description) : base(value, description)
        {
        }
    }
}

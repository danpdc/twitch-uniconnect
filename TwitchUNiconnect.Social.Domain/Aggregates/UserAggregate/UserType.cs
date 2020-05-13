using System;
using System.Collections.Generic;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class UserType : Enumeration
    {
        public static readonly UserType Student = new UserType(0, "Student");
        public static readonly UserType Teacher = new UserType(1, "Teacher");
        public static readonly UserType Staff = new UserType(2, "Staff");
        private UserType(int value, string description) : base(value, description) { }
    }
}

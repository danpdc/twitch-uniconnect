using System;
using System.Collections.Generic;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class Department : ValueObject
    {
        #region Constructors and properties
        private Department(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        #endregion

        #region Factories
        public static Department Create(string name, string description)
        {
            // var deaprtment = Department.Create();
            return new Department(name, description);
        }
        #endregion

        #region Public methods
        public Department ChangeDepartmentName(string newName)
        {
            //after validation
            return Create(newName, Description);
        }

        public Department ChangeDepartmentDescription(string newDescription)
        {
            //after validtion
            return Create(Name, newDescription);
        }

        public Department EditDepartment(string newName, string newDescription)
        {
            //after validation
            return Create(newName, newDescription);
        }
        #endregion

        #region Base class overrides
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Description;
        }
        #endregion
    }
}

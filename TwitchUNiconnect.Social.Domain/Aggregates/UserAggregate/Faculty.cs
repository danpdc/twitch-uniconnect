using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class Faculty : Entity<Guid>
    {
        #region Constructors and properites

        private List<Department> _departments;
        private Faculty(Guid id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<Department> Departments
        {
            get { return _departments; }
        }
        #endregion

        #region Factories
        public static Faculty Create(Guid id, string name, string description,
            IEnumerable<Department> departments = null)
        {
            var faculty = new Faculty(id, name, description);
            faculty._departments = departments.ToList() ?? new List<Department>();
            return faculty;
        }
        #endregion

        #region Public methods
        public void AddDepartment(Department department)
        {
            //after validation
            _departments.Add(department);
        }

        public void RemoveDepartment(Department department)
        {
            //after validatioon
            _departments.Remove(department);
        }

        public void ClearDepartments()
        {
            _departments.Clear();
        }

        public void ChangeName(string newName)
        {
            //after validation
            Name = newName;
        }

        public void ChangeDescription(string newDescription)
        {
            //after validation
            Description = newDescription;
        }

        public void EditFaculty(string newName, string newDescription)
        {
            Name = newName;
            Description = newDescription;
        }

        public bool BelongsToFaculty(Department department)
        {
            var findDepartment = _departments.FirstOrDefault(d => d == department);
            if (findDepartment == null)
                return false;

            return true;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate
{
    public class Class : Entity<Guid>
    {
        #region Constructors and properties
        private List<User> _students;
        public Class(Guid id, DateTime startingYear, DateTime endingYear) : base(id)
        {
            StartingYear = startingYear;
            EndingYear = endingYear;
        }

        public DateTime StartingYear { get; private set; }
        public DateTime EndingYear { get; private set; }
        
        public Faculty Faculty { get; private set; }
        public Department Department { get; private set; }
        public Degree Degree { get; private set; }
        public IEnumerable<User> Students
        {
            get { return _students; }
        }

        #endregion

        #region Factories
        public static Class Create(Guid id, DateTime startingYear, DateTime endingYear,
            Faculty faculty, Department department, Degree degree, IEnumerable<User> students = null)
        {
            if (startingYear < endingYear)
                throw new ArgumentException("Starting year can't be less than the ending year");

            var newClass = new Class(id, startingYear, endingYear);
            newClass.Faculty = faculty;

            var belongsToFaculty = newClass.Faculty.BelongsToFaculty(department);

            if (!belongsToFaculty)
                throw new ArgumentException("Provided department doesn't belong to the specified faculty");

            newClass.Department = department;
            newClass.Degree = degree;

            var isStudentListValid = EnsureUsersAreStudents(students);

            newClass._students = isStudentListValid ? students.ToList() : new List<User>();

            return newClass;

        }
        #endregion

        #region Public methods
        public void AddStudentToClass(User student)
        {
            if (student.Type == UserType.Student)
                _students.Add(student);
        }
        #endregion

        #region Private methods
        private static bool EnsureUsersAreStudents(IEnumerable<User> students)
        {
            if (students == null)
                return false;
            if (students.Count() == 0)
                return false;

            foreach(var student in students)
            {
                if (student.Type != UserType.Student)
                    return false;
            }

            return true;
        }
        #endregion
    }
}

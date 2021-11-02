using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dell_fsd_project_1
{
    class Teacher
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Class { get; private set; }
        public string Section { get; private set; }

        public Teacher(int id) { Id = id; }

        public Teacher(int id, string firstName, string lastName, string className, string section)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
            Section = section;
        }
    }
}

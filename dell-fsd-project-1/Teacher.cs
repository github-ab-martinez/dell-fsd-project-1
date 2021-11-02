using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dell_fsd_project_1
{
    class Teacher
    {
        private static int id_Counter = 0;
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Class { get; private set; }
        public string Section { get; private set; }

        public Teacher() { 
            Id = System.Threading.Interlocked.Increment(ref id_Counter); 
        }

        public Teacher(string firstName, string lastName, string className, string section)
        {
            Id = System.Threading.Interlocked.Increment(ref id_Counter);
            FirstName = firstName;
            LastName = lastName;
            Class = className;
            Section = section;
        }
    }
}

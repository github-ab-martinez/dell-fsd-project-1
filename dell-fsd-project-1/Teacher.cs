using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dell_fsd_project_1
{
    public class Teacher : IComparable<Teacher>
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

        public void UpdateTeacher(string firstName, string lastName, string className, string section)
        {
            FirstName = firstName != "" ? firstName : FirstName;
            LastName = lastName != "" ? lastName : LastName;
            Class = className != "" ? className : Class;
            Section = section != "" ? section : Section;
        }

        public void PrintTeacher()
        {
            Console.WriteLine("  Id  |  First Name  |  Last Name  |  Class  |  Section  ");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("  " + Id + "  |  " + FirstName + "  |  " + LastName + "  |  " + Class + "  |  " + Section + "  ");
        }

        //public int SortByFirstName(Teacher compareTeacher)
        //{
        //    if (compareTeacher == null)
        //        return 1;
        //    else
        //        return this.FirstName.CompareTo(compareTeacher.FirstName);
        //}

        public int CompareTo(Teacher compareTeacher)
        {
            if (compareTeacher == null)
                return 1;
            else
                return this.Id.CompareTo(compareTeacher.Id);
        }
    }
}

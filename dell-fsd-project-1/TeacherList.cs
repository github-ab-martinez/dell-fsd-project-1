using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dell_fsd_project_1
{
    public class TeacherList
    {
        public List<Teacher> Teachers { get; set; }

        public Teacher GetTeacher(int id)
        {
            int index = Teachers.FindIndex(i => i.Id == id);
            if (index != -1)
            {
                return Teachers[index];

            } else
            {
                return null;
            }
        }

        public void PrintList()
        {
            Console.WriteLine("  Id  |  First Name  |  Last Name  |  Class  |  Section  ");
            Console.WriteLine("---------------------------------------------------------");
            foreach (Teacher teacher in Teachers)
            {
                Console.WriteLine("  " + teacher.Id + "  |  " + teacher.FirstName + "  |  " + teacher.LastName + "  |  " + teacher.Class + "  |  " + teacher.Section + "  ");
                Console.WriteLine("---------------------------------------------------------");
            }
        }
    }
}

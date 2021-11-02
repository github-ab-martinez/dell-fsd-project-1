using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dell_fsd_project_1
{
    class Section
    {
        public string Name { get; private set; }
        public Teacher SectionTeacher { get; private set; }

        public Section(string name, Teacher sectionTeacher)
        {
            Name = name;
            SectionTeacher = sectionTeacher;
        }
    }
}

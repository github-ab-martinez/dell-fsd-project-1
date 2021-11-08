using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dell_fsd_project_1
{
    public class FirstNameComparer : IComparer<Teacher>
    {
        public int Compare(Teacher x, Teacher y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;
            else if (null == x)
                return -1;
            else if (null == y)
                return 1;
            else
                return string.Compare(x.FirstName, y.FirstName);
        }
    }
}

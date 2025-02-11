using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticSchool.AppData
{
    internal class Connect
    {
        public static SchoolEntities c;

        public static SchoolEntities Contex
        {
            get
            {
                if (c == null)
                    c = new SchoolEntities();
                return c;
            }
        }
    }
}

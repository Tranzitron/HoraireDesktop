using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoraireDesktop
{
    class Week
    {
        public int id;
        public string name;
        public Day[] days;

        public Week(string name, Day[] days)
        {
            this.name = name;
            this.days = days;
        }
    }
}

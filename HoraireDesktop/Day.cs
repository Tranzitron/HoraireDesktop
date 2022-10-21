using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoraireDesktop
{
    class Day
    {
        public enum Days { DIMANCHE, LUNDI, MARDI, MERCREDI, JEUDI, VENDREDI, SAMEDI }
        public int day;
        public Block[] blocks;

        public Day(Days dayOfWeek,Block[] blocks)
        {
            this.day = (int)dayOfWeek;
            this.blocks = blocks;
        }

    }
}

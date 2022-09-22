using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoraireDesktop
{
    class BlockTime
    {
        public int hour;
        public int minute;
        public int totalMinute { get; }

        public BlockTime(int hour, int minute)
        {
            this.hour = hour;
            this.minute = minute;
            this.totalMinute = hour * 60 + minute;
        }


        public string timeFormat()
        {
            string hour = this.hour == 0 ? "" : this.hour.ToString() + "h";
            return hour + this.minute;
        }
    }
}

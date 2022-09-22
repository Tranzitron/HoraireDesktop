using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoraireDesktop
{
    class Block
    {
        public int id;
        public string name;
        public string description;
        public BlockTime timeStart;
        public BlockTime timeStop;
        public int timeTotal;

        public Block(int id, string name, string description, BlockTime timeStart, BlockTime timeStop)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.timeStart = timeStart;
            this.timeStop = timeStop;
            this.timeTotal = timeStop.minute - timeStart.minute;
        }

        public Block[] getTestBlocks()
        {
            Block busSix = new Block(0, "Bus", "Prendre le bus", new BlockTime(6, 45), new BlockTime(7, 30));
            Block busSeven = new Block(1, "Bus", "Prendre le bus", new BlockTime(7, 45), new BlockTime(8, 30));
            Block[] blocks = { busSix, busSeven };
            return blocks;
        }
    }
}

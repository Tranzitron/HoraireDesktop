using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoraireDesktop
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        static Size form1Size;
        Table t = new Table();

        static Block blockA = new Block(0,"blockA","Description", new BlockTime(10,0),new BlockTime(12,0));
        static Block blockB = new Block(1,"blockB","Description", new BlockTime(14,0),new BlockTime(16,0));
        static Block blockC = new Block(2,"Bus","Description", new BlockTime(6,45),new BlockTime(7,30));
        static Block blockD = new Block(3,"A block","Description", new BlockTime(6,45),new BlockTime(7,30));
        static Block[] blocks = { blockA, blockB, blockC, blockD };


        Day day = new Day(blocks);
        // User defined (not yet)
        int columnAmount = 5;
        int spaceBetweenColumns = 100;
        int columnsHeight = (int)(form1Size.Height * 0.8);
        int startX = 100;
        int startY = 30;

        Font font = new Font("Arial", 12);
        Single blockTitleHeight = 0.0f;
        Single blockDescHeight = 1.0f;
        // bool autoAdjust: check minimum time and maximum time automatically
        int gridStart = 6;
        int gridStop = 18;

        private void Form1_Resize(object sender, EventArgs e)
        {
            Graphics g;
            g = this.CreateGraphics();
            draw(g);
            GC.Collect();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = this.CreateGraphics();
            draw(g);
        }

        public void draw(Graphics g)
        {
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            form1Size = Form1.ActiveForm.Size;
            t.createCustomTable(g, columnAmount, spaceBetweenColumns, (int)(form1Size.Height * 0.8), startX, startY);
            foreach (Block block in blocks)
            {
                t.createCustomBlock(g, block, (int)(form1Size.Height * 0.8), gridStart, gridStop, spaceBetweenColumns,startX,startY, font, blockTitleHeight, blockDescHeight);
            }
            t.createCustomText(g, columnAmount, spaceBetweenColumns, (int)(form1Size.Height * 0.8), startX, startY, gridStart, gridStop, font);
        }
    }
}

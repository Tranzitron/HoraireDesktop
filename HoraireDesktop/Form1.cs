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
        static Block[] blocks = { blockA, blockB };
        Day day = new Day(blocks);

        // User defined (not yet)
        int columnAmount = 5;
        int spaceBetweenColumns = 100;
        int columnsHeight = (int)(form1Size.Height * 0.8);
        int startX = 30;
        int startY = 30;

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            form1Size = Form1.ActiveForm.Size;
            System.Drawing.Graphics g;
            g = this.CreateGraphics();
            //t.createTestTable(g);
            g.Clear(Color.White);
            t.createCustomTable(g, columnAmount, spaceBetweenColumns, (int)(form1Size.Height * 0.8), startX, startY);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            form1Size = Form1.ActiveForm.Size;
            System.Drawing.Graphics g;
            g = this.CreateGraphics();
            //t.createTestTable(g);
            t.createCustomTable(g, columnAmount, spaceBetweenColumns, (int)(form1Size.Height * 0.8), startX, startY);
            t.createTestText(g, columnAmount, spaceBetweenColumns, (int)(form1Size.Height * 0.8), startX, startY);
        }

    }
}

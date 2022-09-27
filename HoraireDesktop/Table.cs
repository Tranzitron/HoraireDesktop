using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.AxHost;

namespace HoraireDesktop
{
    internal class Table
    {
        Pen penBlue = new Pen(System.Drawing.Color.Blue, 2);
        Pen penRed = new Pen(System.Drawing.Color.Red, 2);
        Pen penBlack = new Pen(System.Drawing.Color.Black, 2);
        static int color = 200;
        SolidBrush backBrush = new SolidBrush(Color.FromArgb(255, color, color, color));
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        int rows = 5;
        int rowsPx = 100;
        int columnsPx = 600;
        int sX = 100;
        int sY = 30;

        public void createTestTable(System.Drawing.Graphics g)
        {
            // Background
            Rectangle fullTable = new Rectangle(sX, sY, (int)((rows-1) * rowsPx), columnsPx);
            g.FillRectangle(backBrush, fullTable);
            // Top & Bottom
            g.DrawLine(penBlue, sX, sY, (int)(sX + ((rows-1) * rowsPx)), sY);
            g.DrawLine(penBlue, sX, sY+columnsPx, (int)(sX + ((rows-1) * rowsPx)), sY + columnsPx);
            // Colums
            for(int i = 0; i < rows; i++)
            {
                g.DrawLine(penRed, sX+(i*rowsPx), sY, sX + (i * rowsPx), sY + columnsPx);
            }

        }

        public void createCustomTable(System.Drawing.Graphics g, int columnAmount,int spaceBetweenColumns,int columnsHeight, int startX, int startY)
        {
            // Background
            Rectangle fullTable = new Rectangle(startX, startY, (columnAmount) * spaceBetweenColumns, columnsHeight);
            g.FillRectangle(backBrush, fullTable);
            // Top & Bottom
            g.DrawLine(penBlack, startX, startY, startX + ((columnAmount) * spaceBetweenColumns), startY);
            g.DrawLine(penBlack, startX, startY + columnsHeight, startX + ((columnAmount) * spaceBetweenColumns), startY + columnsHeight);
            // Columns
            for (int i = 0; i <= columnAmount; i++)
            {
                g.DrawLine(penBlack, startX + (i * spaceBetweenColumns), startY, startX + (i * spaceBetweenColumns), startY + columnsHeight);
            }

        }

        public void createTestText(System.Drawing.Graphics g, int columnAmount, int spaceBetweenColumns, int columnsHeight, int startX, int startY)
        {
            Font font = new Font("Arial", 12);
            Rectangle fullTable = new Rectangle(startX, startY, (columnAmount - 1) * spaceBetweenColumns, columnsHeight);
            // g.DrawString("Text", font, blackBrush, fullTable);
            int start = 8;
            int stop = 18;
            for(int i = start; i <= stop; i++)
            {
                string text = i + "h00";
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(text, font);
                Rectangle spot = new Rectangle((int)((float)startX- stringSize.Width*1.05), startY + (columnsHeight*(i-start)/10), (columnAmount - 1) * spaceBetweenColumns, columnsHeight);
                g.DrawString(text, font, blackBrush, spot);
            }
        }

        public void createTestBlock(System.Drawing.Graphics g, Block block)
        {
            float start = block.timeStart.hour+(block.timeStart.minute/60);
            float stop = block.timeStop.hour+(block.timeStop.minute/60);
            float height = block.timeTotal;
            
            Rectangle fullTable = new Rectangle(sX, sY + (int)(stop / start * columnsPx), rowsPx, (int)(stop / start * columnsPx));
            g.FillRectangle(blackBrush, fullTable);
            g.DrawLine(penBlack, sX, sY+(stop/start*columnsPx),sX+ rowsPx, sY + (stop / start * columnsPx));
            g.DrawLine(penBlack, sX, sY+height+ sY + (stop / start * columnsPx), sX + rowsPx, sY + height + sY + (stop / start * columnsPx));
        }
    }
}

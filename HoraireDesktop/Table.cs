using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HoraireDesktop
{
    internal class Table
    {
        Pen penBlue = new Pen(System.Drawing.Color.Blue, 2);
        Pen penRed = new Pen(System.Drawing.Color.Red, 2);
        SolidBrush gainsboroBrush = new SolidBrush(Color.Gainsboro);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        double rows = (int) 50;
        int rowsPx = 10;
        int columnsPx = 400;
        int sX = 30;
        int sY = 30;

        public void createTestTable(System.Drawing.Graphics g)
        {
            // Background
            Rectangle fullTable = new Rectangle(sX, sY, (int)((rows-1) * rowsPx), columnsPx);
            g.FillRectangle(gainsboroBrush, fullTable);
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
            Rectangle fullTable = new Rectangle(startX, startY, (columnAmount - 1) * spaceBetweenColumns, columnsHeight);
            g.FillRectangle(gainsboroBrush, fullTable);
            // Top & Bottom
            g.DrawLine(penBlue, startX, startY, startX + ((columnAmount - 1) * spaceBetweenColumns), startY);
            g.DrawLine(penBlue, startX, startY + columnsHeight, startX + ((columnAmount - 1) * spaceBetweenColumns), startY + columnsHeight);
            // Colums
            for (int i = 0; i < columnAmount; i++)
            {
                g.DrawLine(penRed, startX + (i * spaceBetweenColumns), startY, startX + (i * spaceBetweenColumns), startY + columnsHeight);
            }

        }

        public void createTestText(System.Drawing.Graphics g, int columnAmount, int spaceBetweenColumns, int columnsHeight, int startX, int startY)
        {
            Font font = new Font("Arial", 12);
            Rectangle fullTable = new Rectangle(startX, startY, (columnAmount - 1) * spaceBetweenColumns, columnsHeight);
            g.DrawString("Text", font, blackBrush, fullTable);
        }
    }
}

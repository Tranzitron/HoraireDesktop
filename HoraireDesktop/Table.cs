using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media;
using Pen = System.Drawing.Pen;
using Color = System.Drawing.Color;
using System;

namespace HoraireDesktop
{
    internal class Table
    {
        Pen penBlue = new Pen(Color.Blue, 2);
        Pen penRed = new Pen(Color.Red, 2);
        Pen penBlack = new Pen(Color.Black, 1);
        static int backcolor = 200;
        static int trianglecolor = 0;
        SolidBrush backBrush = new SolidBrush(Color.FromArgb(255, backcolor, backcolor, backcolor));
        SolidBrush triangleBrush = new SolidBrush(Color.FromArgb(255, trianglecolor, trianglecolor, trianglecolor));
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);


        public void createCustomTable(Graphics g, int columnAmount,int spaceBetweenColumns,int columnsHeight, int startX, int startY)
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

        public void createCustomText(Graphics g, int columnAmount, int spaceBetweenColumns, int columnsHeight, int startX, int startY, int gridStart, int gridStop, Font font)
        {
            Rectangle fullTable = new Rectangle(startX, startY, (columnAmount - 1) * spaceBetweenColumns, columnsHeight);
            for(int i = gridStart; i <= gridStop; i++)
            {
                string text = i + "h00";
                SizeF stringSize = g.MeasureString(text, font);
                Rectangle spot = new Rectangle((int)((float)startX- stringSize.Width*1.05), startY + (columnsHeight*(i- gridStart) /(gridStop-gridStart)), (columnAmount - 1) * spaceBetweenColumns, columnsHeight);
                g.DrawString(text, font, blackBrush, spot);
            }
        }

        public void createCustomBlock(Graphics g, Block block, int columnsHeight, int gridStart, int gridStop, int spaceBetweenColumns, int startX, int startY, Font font, Single blockTitleHeight, Single blockDescHeight)
        {

            float start = (float)block.timeStart.hour+((float)block.timeStart.minute/60);
            float stop = (float)block.timeStop.hour+((float)block.timeStop.minute/60);

            float startHeight = startY + ((start - gridStart) / (gridStop - gridStart) * columnsHeight);
            float stopHeight = startY + ((stop - gridStart) / (gridStop - gridStart) * columnsHeight);
            g.FillRectangle(whiteBrush, startX+(block.id * spaceBetweenColumns), startHeight, spaceBetweenColumns, stopHeight- startHeight);
            g.DrawRectangle(penBlack, startX + (block.id * spaceBetweenColumns), startHeight, spaceBetweenColumns, stopHeight - startHeight);

            // Text Title
            if (block.name.Trim().Length > 0)
            {
                SizeF stringSize = g.MeasureString(block.name, font);
                int stringLeft = (int)(startX + (block.id * spaceBetweenColumns) + ((spaceBetweenColumns - stringSize.Width) / 2));
                int stringTop = (int)(startHeight + ((stopHeight - startHeight) * blockTitleHeight) - (stringSize.Height / 2));
                if(blockTitleHeight <= 0)
                {
                    stringTop = (int)(startHeight + ((stopHeight - startHeight) * blockTitleHeight));
                }
                Rectangle nameSpot = Rectangle.FromLTRB(stringLeft, stringTop, 0, stringTop);
                g.DrawString(block.name, font, blackBrush, nameSpot);
            }

            // Text Description
            bool placeDesc = ((g.MeasureString(block.name, font).Height)+(g.MeasureString(block.description, font).Height)) < (stopHeight-startHeight);
            if (block.description.Trim().Length > 0 && placeDesc)
            {
                SizeF stringSize = g.MeasureString(block.description, font);
                int stringLeft = (int)(startX + (block.id * spaceBetweenColumns) + ((spaceBetweenColumns - stringSize.Width) / 2));
                int stringTop = (int)(startHeight + ((stopHeight - startHeight) * blockDescHeight) + (stringSize.Height/2));
                int stringBottom = (int)((stopHeight - stringSize.Height));
                if(blockDescHeight >= 1)
                {
                    stringBottom = (int)(stopHeight - stringSize.Height);
                }
                Rectangle nameSpot = Rectangle.FromLTRB(stringLeft, stringBottom, 0, stringBottom);
                g.DrawString(block.description, font, blackBrush, nameSpot);
            } 
            else // triangle if no description
            {
                Single square = 0.9f; // get minimum of both side
                PointF[] points = {
                    new PointF((int)(startX + (block.id * spaceBetweenColumns) + (spaceBetweenColumns*square)),(int)stopHeight)
                    ,new PointF((int)(startX + (block.id * spaceBetweenColumns) + spaceBetweenColumns),(int)stopHeight)
                    ,new PointF((int)(startX + (block.id * spaceBetweenColumns) + spaceBetweenColumns),(int)(stopHeight-(spaceBetweenColumns*(1-square))))
                    };
                g.FillPolygon(triangleBrush, points);
                //g.DrawLine(penBlack, points[0].X,points[0].Y,points[2].X,points[2].Y);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_task2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int size = 25;
            DrawRectangles(32, size, e);

            //DrawBigPixel(5, 5, e);
            Bresenham(2, 2, 25, 2, size, e);
            
        }


        // function for line generation 
        private void Bresenham(int x1, int y1, int x2, int y2, int size, PaintEventArgs e)
        {

            int m_new = 2 * (y2 - y1);
            int slope_error_new = m_new - (x2 - x1);

            for (int x = x1, y = y1; x <= x2; x++)
            {
                
                DrawBigPixel(x, y, size, e);
                // Add slope to increment angle formed 
                slope_error_new += m_new;

                // Slope error reached limit, time to 
                // increment y and update slope error. 
                if (slope_error_new >= 0)
                {
                    y++;
                    slope_error_new -= 2 * (x2 - x1);
                }
            }
        }

        private void DrawRectangles(int numOfCells, int cellSize, PaintEventArgs e)
		{
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);
            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

		private void DrawBigPixel(int x,int y, int size, PaintEventArgs e)
		{
            SolidBrush pixelBrush = new SolidBrush(Color.Red);
            int bitMapXCoordinate = (x - 1) * size;
            int bitMapYCoordinate = (y - 1) * size;
            e.Graphics.FillRectangle(pixelBrush, bitMapXCoordinate, bitMapYCoordinate, 25, 25);
        }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_task2
{
	public partial class Form1 : Form
	{

        int size = 25;

		public Form1()
		{
			InitializeComponent();
		}

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(32, size);
            Midptellipse(3, 3, 3, 3);
        }


        private void Bresenham(int x1, int y1, int x2, int y2)
        {

            int w = x2 - x1;
            int h = y2 - y1;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                DrawBigPixel(x1, y1);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x1 += dx1;
                    y1 += dy1;
                }
                else
                {
                    x1 += dx2;
                    y1 += dy2;
                }
            }
        }

        

        private void DrawGrid(int numOfCells, int cellSize)
		{
            Graphics g = CreateGraphics();
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

		private void DrawBigPixel(int x,int y)
		{
            Graphics g = CreateGraphics();
            SolidBrush pixelBrush = new SolidBrush(Color.Red);
            int bitMapXCoordinate = (x - 1) * size;
            int bitMapYCoordinate = (y - 1)  * size;
            Rectangle rect = new Rectangle(bitMapXCoordinate, bitMapYCoordinate, size, size);
            g.FillRectangle(pixelBrush, rect);
        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
            
		}

		private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int x2 = int.Parse(textBox3.Text);
            int y2 = int.Parse(textBox4.Text);

            Bresenham(x1, y1, x2, y2);


        }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_app
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawMandelbrot();
        }
        private void DrawMandelbrot()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            bmp = new Bitmap(width, height);
            for (int xc = 0;xc < width;xc++)
            {
                for (int yc = 0; yc < height; yc++)
                {
                    double parte_real = (xc - width / 3d) * 4d / (width*4);
                    double parte_img = (yc - height / -1d) * 4d / (height*7);
                    double x = 0, y = 0;
                    int ciclos = 0;
                    while(ciclos < 5000 && (x*x +y*y)<4)
                    {
                        double temp_x = (x * x) - (y * y) + parte_real;
                        y = 2d * x * y + parte_img;
                        x = temp_x;
                        ciclos++;
                    }
                    if (ciclos>=0 && ciclos<1500)
                    {
                        bmp.SetPixel(xc, yc, Color.FromArgb(4 * ciclos % 255, ciclos % 3 * 30, 50));
                    }
                    else if (ciclos >= 1500 && ciclos < 3000)
                    {
                        bmp.SetPixel(xc, yc, Color.FromArgb(255, ciclos % 2 * 255, 3*ciclos%255));
                    }
                    else if (ciclos >= 3000 && ciclos < 4500)
                    {
                        bmp.SetPixel(xc, yc, Color.FromArgb(4*ciclos % 255, ciclos % 3 * 30, 50));
                    }
                    else 
                    {
                        bmp.SetPixel(xc, yc, Color.FromArgb(ciclos % 18, ciclos % 37, ciclos % 177));
                    }
                    
                }
                pictureBox1.Image = bmp;
            }
        }
    }
}

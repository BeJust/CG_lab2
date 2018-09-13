using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lb2
{
    public partial class MainWindow : Form
    {
        Graphics gBitmap;
        Graphics gScreen;
        Bitmap bitmap;

        public MainWindow()
        {
            InitializeComponent();
            gBitmap = CreateGraphics();
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            
            Draw();
            
        }

        private void Draw()
        {
            Pen pen = new Pen(Color.Black);
            gBitmap.Clear(Color.White);
            BresCircle(200, 200, 100);
            gScreen.DrawImage(bitmap, ClientRectangle);
            gBitmap.Dispose();
            gScreen.Dispose();
            bitmap.Dispose();
        }

        private void BresCircle(int x0, int y0, int r)
        {
            int x = 0;
            int y = r;
            int delta = 1 - 2 * r;
            int error = 0;
            while (y >= 0)
            {
                bitmap.SetPixel(x0 + x, y0 + y, Color.Black);             
                bitmap.SetPixel(x0 - x, y0 + y, Color.Black);             
                error = 2 * (delta + y) - 1;

                if (delta < 0 && error <= 0)
                {
                    ++x;
                    delta += 2 * x + 1;
                    continue;
                }
                error = 2 * (delta - x) - 1;
                if (delta > 0 && error > 0)
                {
                    --y;
                    delta += 1 - 2 * y;
                    continue;
                }

                ++x;
                delta += 2 * (x - y);
                --y;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            gScreen = CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            gBitmap = Graphics.FromImage(bitmap);
        }
    }
}

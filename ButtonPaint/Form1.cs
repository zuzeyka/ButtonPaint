using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonPaint
{
    public partial class Form1 : Form
    {
        Button button;
        Point start = new Point(0, 0);
        bool button_set = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (button_set)
            {
                button = new Button();
                button.Location = e.Location;
                start = e.Location;
                button.Size = new Size(0, 0);
                this.Controls.Add(button);
                button_set = false;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            button_set = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (button_set == false)
            {
                int x = e.Location.X - start.X;
                int y = e.Location.Y - start.Y;
                Point newLocation = button.Location;
                Size newSize = button.Size;

                if (x < 0)
                {
                    newLocation.X = e.Location.X;
                    newSize.Width = start.X - e.Location.X;
                }
                else newSize.Width = x;

                if (y < 0)
                {
                    newLocation.Y = e.Location.Y;
                    newSize.Height = start.Y - e.Location.Y;
                }
                else newSize.Height = y;

                button.Size = newSize;
                button.Location = newLocation;
            }
        }
    }
}

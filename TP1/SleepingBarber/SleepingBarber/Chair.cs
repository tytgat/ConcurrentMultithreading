using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SleepingBarber
{
    public class Chair
    {
        PictureBox chair;
        bool tacken;

        public Chair (PictureBox pb)
        {
            this.chair = pb;
            chair.BackColor = Color.White;
            tacken = false;
        }

        public bool takeChair()
        {
            if (tacken)
            {
                return false;
            }
            tacken = true;
            chair.BackColor = Color.Black;
            chair.Invalidate();
            return tacken;
        }

        public bool freeChair()
        {
            if (!tacken)
            {
                return false;
            }
            chair.BackColor = Color.White;
            chair.Invalidate();
            tacken = false;
            return true;
        }
    }
}

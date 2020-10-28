using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class frmScreenSaver : Form
    {
        List<Image> BGImages = new List<Image>();
        List<BritPic> BritPics = new List<BritPic>();
        Random rand = new Random();

        class BritPic
        {
            public int PicNum;
            public float X;
            public float Y;
            public float Speed;
        }

        public frmScreenSaver()
        {
            InitializeComponent();
        }

        private void frmScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void frmScreenSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pics");

            foreach (string image in images)
            {
                //creates a new bitmap picture
                BGImages.Add(new Bitmap(image));
            }

            for (int times = 0; times < 50; times++)
            {
                BritPic mp = new BritPic();
                mp.PicNum = times % BGImages.Count;
                mp.X = rand.Next(0, Width);
                mp.Y = rand.Next(0, Height);

                BritPics.Add(mp);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }


        private void frmScreenSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach(BritPic picture in BritPics)
            {
                e.Graphics.DrawImage(BGImages[picture.PicNum], picture.X, picture.Y);
                picture.X += 0;

                if (picture.X < -250)
                {
                    picture.X = Width + rand.Next(20, 100);
                }
            }
        }
    }
}

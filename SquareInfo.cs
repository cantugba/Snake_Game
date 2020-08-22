using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    class SquareInfo
    {
        public Point location { get; set; }
        public Size size { get; set; }
        public Color backColor { get; set; }
        public PictureBox pictureBox { get; set; }

        public int indeks { get; set; }
        public bool squareLen { get; set; }
        public bool food { get; set; }
        public bool bound { get; set; }


        public Panel panel { get; set; }

        public SquareInfo(Panel panel, Point location, Size size, int indeks)
        {
            this.panel = panel;
            this.location = location;
            this.size = size;
            this.indeks = indeks;
            this.backColor = Color.Black;
            this.squareLen = false;
            this.food = false;
            this.bound = false;
            addPictureBox();

        }

        void addPictureBox()
        {
            this.pictureBox = new PictureBox();
            pictureBox.Location = this.location;
            pictureBox.Size = this.size;
            pictureBox.BackColor = this.backColor;
            this.panel.Controls.Add(pictureBox);

        }

        public void makeSnakeLen()
        {
            this.pictureBox.BackColor = Color.GreenYellow;
            this.squareLen = true;
        }

        public void dontMakeLen()
        {
            this.pictureBox.BackColor = this.backColor;
            this.squareLen = false;
        }

        public void makeFood()
        {
            this.pictureBox.BackColor = Color.Red;
            this.food = true;
        }

        public void dontMakeFood()
        {
            this.pictureBox.BackColor = this.backColor;
            this.food = false;
        }

        public void makeBound()
        {
            this.pictureBox.BackColor = Color.DarkGray;
            this.bound = true;
        }


    }
}

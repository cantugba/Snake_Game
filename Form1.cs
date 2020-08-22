using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<SquareInfo> listSquare = new List<SquareInfo>();
        List<SquareInfo> listSnakeLen = new List<SquareInfo>();
        SnakeInfo snakeInfo = null;
        int direction = 2; // first start the game
        //int countSquare = 30;
        int totalSquare = 900;
        bool gameOver = false;
        bool haveFood = false;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //450*450 -> 450/30=15 15 - 2(margin between squareFrames) = 13
            //totalSquare = countSquare * countSquare;

            int squareEdgeLen = 12;
            int squareX = 1;
            int squareY = 1;
            int margin = 2;

            for (int i = 0; i < totalSquare; i++)
            {
                SquareInfo squareInfo = new SquareInfo(this.panel, new Point(squareX, squareY), new Size(squareEdgeLen, squareEdgeLen), i);
                listSquare.Add(squareInfo);
                squareX += squareEdgeLen + margin;

                if ((i + 1) % 30 == 0)
                {
                    squareX = 1;
                    squareY += squareEdgeLen + margin;
                }
            }

            addBound();

            snakeInfo = new SnakeInfo(listSquare, listSnakeLen);
            

        }

        void newGame()
        {
            timer.Stop();
            foreach (SquareInfo item in listSquare)
            {
                if (!item.bound)
                {
                    item.dontMakeLen();
                    item.dontMakeFood();
                }
            }

            gameOver = false;
            direction = 2;
            haveFood = false;
            lblSkor.Text = "0";
            listSnakeLen.Clear();
            snakeInfo = new SnakeInfo(listSquare, listSnakeLen);
        }

        void addFood()
        {
            if (haveFood)
            {
                return;
            }
            Random random = new Random();
            int indis = 0;
            bool findFood = false;
            while (findFood == false)
            {
                indis = random.Next(0, totalSquare);
                findFood = true;
                if(this.listSquare[indis].squareLen || this.listSquare[indis].bound)
                {
                    findFood = false;
                }
            }

            if (findFood)
            {
                this.listSquare[indis].makeFood();
                this.haveFood = true;
            }
           

        }

        void addBound()
        {  
            //upBound
            for (int i = 0; i <= 29; i+=1)
            {
                listSquare[i].makeBound();
            }

            //leftBound
            for (int i = 0; i <= 870; i += 30)
            {
                listSquare[i].makeBound();
            }
            //downBound
            for (int i = 870; i <= 899; i += 1)
            {
                listSquare[i].makeBound();
            }
            //rightBound
            for (int i = 29; i <= 899; i += 30)
            {
                listSquare[i].makeBound();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            addFood();

            int result = snakeInfo.move(direction);

            switch (result)
            {
                case 0:
                    timer.Stop();
                    gameOver = true;
                    MessageBox.Show("Game over...");
                    break;
                case 1:
                    break;
                case 2:
                    haveFood = false;
                    lblSkor.Text = Convert.ToString(Convert.ToInt32(lblSkor.Text) +1);
                    break;
                default:
                    break;
            }
        }

        private void pictureUp_Click(object sender, EventArgs e)
        {
            if(snakeInfo.snakeDirection != 3)
            {
                direction = 1;

            }
        }

        private void pictureRight_Click(object sender, EventArgs e)
        {
            if(snakeInfo.snakeDirection != 4)
            {
                direction = 2;
            }
        }

        private void pictureDown_Click(object sender, EventArgs e)
        {
            if (snakeInfo.snakeDirection != 1)
            {
                direction = 3;
            }
        }

        private void pictureLeft_Click(object sender, EventArgs e)
        {
            if(snakeInfo.snakeDirection != 2)
            {
                direction = 4;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                timer.Start();
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                timer.Stop();
            }

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            newGame();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                if (snakeInfo.snakeDirection != 3)
                {
                    direction = 1;

                }
            }

            if (keyData == Keys.Right)
            {
                if (snakeInfo.snakeDirection != 4)
                {
                    direction = 2;
                }
            }

            if(keyData == Keys.Down)
            {
                if(snakeInfo.snakeDirection != 1)
                {
                    direction = 3;
                }
            }

            if(keyData == Keys.Left)
            {
                if (snakeInfo.snakeDirection != 2)
                {
                    direction = 4;
                }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}

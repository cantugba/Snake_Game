using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeInfo
    {
        public int startPosition = 33;
        public int snakeDirection { get; set; }
        List<SquareInfo> listSquare { get; set; }
        List<SquareInfo> listLen { get; set; }

        public SnakeInfo(List<SquareInfo> listSquare, List<SquareInfo> listLen)
        {
            this.listSquare = listSquare;
            this.listLen = listLen;

            this.listSquare[31].makeSnakeLen();
            this.listSquare[32].makeSnakeLen();
            this.listSquare[33].makeSnakeLen();

            this.listLen.Add(this.listSquare[31]);
            this.listLen.Add(this.listSquare[32]);
            this.listLen.Add(this.listSquare[33]);
        }

        public int move(int direction)
        {
            this.snakeDirection = direction;
            switch (direction)
            {
                // up,right,down,left
                case 1: 
                    startPosition = startPosition - 30;
                    break;
                case 2:
                    startPosition = startPosition + 1;
                    break;
                case 3:
                    startPosition = startPosition + 30;
                    break;
                case 4:
                    startPosition = startPosition - 1;
                    break;
                default:
                    break;
            }

            if (this.listSquare[startPosition].squareLen || this.listSquare[startPosition].bound)
            {
                return 0; //Game Over 
            }
            else
            {
                this.listSquare[startPosition].makeSnakeLen();
                this.listLen.Add(this.listSquare[startPosition]);

                if (this.listSquare[startPosition].food)
                {
                    this.listSquare[startPosition].food = false;
                    return 2; // if eat food
                }
                else
                {
                    this.listSquare[this.listLen[0].indeks].dontMakeLen();
                    this.listLen.RemoveAt(0);
                    return 1; // if queue deleted
                }
            }
            
        }

    }
}

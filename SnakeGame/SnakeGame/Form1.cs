using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Name: Harsh Solanki
//Date: January 11th, 2018
//This code allows users to play snake game

namespace SnakeGame
{
    public partial class frmSnake : Form
    {
        Random rand;
        enum GameSize
        {
            Free,
            Snake,
            Food
        }
        ;

        enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }
        ;

        struct SnakeCoordinates
        {
            public int x;
            public int y;
        }

        //creating a 2d array for the game's border
        GameSize[,] gameSize;
        
        //the coordinate of snake using arrays
        SnakeCoordinates[] snakeXY; 

        //after the snake eats bonus, another piece of body gets added and the length increases by one
        int snakeLength; 
        
        //direction where the head is facing
        Directions direction; 
        Graphics g;

        public frmSnake()
        {
            InitializeComponent();
            gameSize = new GameSize[11, 11]; //2d array for game's border
            snakeXY = new SnakeCoordinates[100]; //Snake's coordinate within the border
            rand = new Random();
        }
        private void topBottomWalls(int i, int counter, Graphics g)
        {
            g.DrawImage(imgList.Images[6], i * 35, 0);//moving 35 pixels to the right
            g.DrawImage(imgList.Images[6], i * 35, 385); //moving 35 pixels to the right, but on the bottom of the game board (starting in index 1; so it's 35*11 = 385)
            i = i + 1;
            if (i <= counter)
            {
                topBottomWalls(i, 10, g);
            }

        }

        private void frmSnake_Load(object sender, EventArgs e)
        {
            picGameSize.Image = new Bitmap(420, 420); //35 pixels * 12 fields (10 fields of game board + 2 fields for the wall)
            g = Graphics.FromImage(picGameSize.Image);
            g.Clear(Color.White);
            int j = 1;
            
            //top and bottom walls Recursion function
            topBottomWalls(j, 10, g);
            
            for (int i = 0; i <= 11; i++)
            {
                //left and right walls
                g.DrawImage(imgList.Images[6], 0, i * 35); //moving 35 pixels down
                g.DrawImage(imgList.Images[6], 385, i* 35); //moving 35 pixels down, but starting on the right side of the game board (starting from index 1; so it's 35 * 11 = 385
            }

            //making the snakes body and head
            snakeXY[0].x = 5; //head
            snakeXY[0].y = 5;
            snakeXY[1].x = 5;//first body part
            snakeXY[1].y = 6;
            snakeXY[2].x = 5;//second body part
            snakeXY[2].y = 7;

            g.DrawImage(imgList.Images[5], 5 * 35, 5 * 35); //head
            g.DrawImage(imgList.Images[4], 5 * 35, 6 * 35); //first body part
            g.DrawImage(imgList.Images[4], 5 * 35, 7 * 35); //second body part

            gameSize[5, 5] = GameSize.Snake; //head
            gameSize[5, 6] = GameSize.Snake; //first body part
            gameSize[5, 7] = GameSize.Snake; //second body part

            direction = Directions.Up;
            snakeLength = 3;

            for (int i = 0; i < 4; i++)
            {
                Food();
            }
        }

        private void Food()
        {
            int x, y;
            var imgIndex = rand.Next(0, 4);

            //if bonus is randomly generated food anywhere on a snake field 
            do
            {
                x = rand.Next(1, 10);
                y = rand.Next(1, 10);
            }
            while (gameSize[x, y] != GameSize.Free);

            gameSize[x, y] = GameSize.Food; 
            g.DrawImage(imgList.Images[imgIndex], x * 35, y * 35); //draw the randomly generated food on the form
        }

        private void frmSnake_KeyDown(object sender, KeyEventArgs e)
        {
  
            //using the keys to move the snake in all directions
            if (e.KeyCode == Keys.Up)
            {
                direction = Directions.Up;
            }
            else if (e.KeyCode ==Keys.Down)
            {
                direction = Directions.Down;
            }
            else if (e.KeyCode == Keys.Right)
            {
                direction = Directions.Right;
            }
            else if (e.KeyCode == Keys.Left)
            {
                direction = Directions.Left;
            }

        }

        private void GameOver()
        {
            //displays a messagebox after game is over for the user to decide whether he wants to play again of quit
            timer.Enabled = false;
            string message = "Do you want to Restart?";
            string title = "Game Over!!!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                Application.Restart();
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //delete the end of the snake
            g.FillRectangle(Brushes.White, snakeXY[snakeLength - 1].x * 35,
            snakeXY[snakeLength - 1].y * 35, 35, 35);
            //set the game board filed of the last body part to be free
            gameSize[snakeXY[snakeLength - 1].x, snakeXY[snakeLength - 1].y] = GameSize.Free;

            //move snake from th position of previous one
            for (int i = snakeLength; i >= 1; i--)
            {
                snakeXY[i].x = snakeXY[i - 1].x;
                snakeXY[i].y = snakeXY[i - 1].y;
            }



            g.DrawImage(imgList.Images[4], snakeXY[0].x * 35, snakeXY[0].y * 35);

            //change direction of the head
            if (direction == Directions.Up )
            {
                snakeXY[0].y = snakeXY[0].y - 1;
            }
            else if (direction == Directions.Down)
            {
                snakeXY[0].y = snakeXY[0].y + 1;
            }
            else if (direction == Directions.Left)
            {
                snakeXY[0].x = snakeXY[0].x - 1;
            }
            else if (direction == Directions.Right)
            {
                snakeXY[0].x = snakeXY[0].x + 1;
            }


            //if snake hit the wall the game is over
            if (snakeXY[0].x < 1 || snakeXY[0].x > 10 || snakeXY[0].y < 1 || snakeXY[0].y > 10)
            {
                GameOver();
                picGameSize.Refresh();
                return;
            }

            //if the snake hits its own body then game is over
            if (gameSize[snakeXY[0].x,snakeXY[0].y] == GameSize.Snake)
            {
                GameOver();
                picGameSize.Refresh();
                return;
            }

            //check if snake ate the food
            if (gameSize[snakeXY[0].x, snakeXY[0].y] == GameSize.Food)
            {
                //add another body part after the last body part of the snake
                g.DrawImage(imgList.Images[4], snakeXY[snakeLength].x * 35,
                    snakeXY[snakeLength].y * 35);
                //set the field of the newly added body part to be of Snake
                gameSize[snakeXY[snakeLength].x, snakeXY[snakeLength].y] = GameSize.Snake;
                snakeLength++;

               
                
                if (snakeLength < 96)
                    Food();

                this.Text = "Snake - score: " + snakeLength;
            }

            //draw the head
            g.DrawImage(imgList.Images[5], snakeXY[0].x * 35, snakeXY[0].y * 35);
            //change the game board field of new head to be of Snake
            gameSize[snakeXY[0].x, snakeXY[0].y] = GameSize.Snake;

            //refresh the whole game board
            picGameSize.Refresh();
        }

     
    }
}

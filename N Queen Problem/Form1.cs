using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Queen_Problem
{
    public partial class Form1 : Form
    {
        static int N;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                N = int.Parse(textBox1.Text);
            }
            int[,] board = new int[N,N];
		    if(!theBoardSolver(board, 0))
		    {
			    label1.Text="Solution not found\n";
		    }
		    printBoard(board);
        }

        private void printBoard(int[,] board)
        {
            StringBuilder strb = new StringBuilder();
            int i;
            strb.Clear();
		    for(i=0;i<N;i++)
		    {
			    for(int j=0;j<N;j++)
				    if(board[i,j]==1)
				    {
                        strb.Append("Q    ");
				    }
				    else
				    {
                        strb.Append("-    ");
				    }
                    strb.Append("\n");
		    }
            label1.Text = strb.ToString();
        }

        private bool theBoardSolver(int[,] board, int col)
        {
            if (col >= N)
                return true;
            for (int i = 0; i < N; i++)
            {
                if (toPlaceOrNotToPlace(board, i, col))
                {
                    board[i,col] = 1;
                    if (theBoardSolver(board, col + 1))
                    {
                        return true;
                    }
                    board[i,col] = 0;
                }
            }
            return false;
        }

        private bool toPlaceOrNotToPlace(int[,] board, int row, int col)
        {
            int i, j;
            for (i = 0; i < col; i++)
            {
                if (board[row,i] == 1)
                {
                    return false;
                }
            }
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i,j] == 1)
                {
                    return false;
                }
            }
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
            {
                if (board[i,j] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Location = new Point(label4.Location.X + 5, label4.Location.Y);

            if (label4.Location.X > this.Width)
            {
                label4.Location = new Point(0 - label4.Width, label4.Location.Y);
            }
        }
    }
}

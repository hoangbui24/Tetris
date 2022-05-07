using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
            //Khoi tao cot va hang
            private readonly int[,] grid;
            public int Rows { get; }
            public int Cols { get; }
            public int this[int r, int c]
            {
                get => grid[r, c];
                set => grid[r, c] = value;
            }
            public GameGrid(int rows, int cols)
            {
                this.Rows = rows;
                this.Cols = cols;
                grid = new int[rows, cols];
            }

            //Ham kiem tra xem vi tri co dang nam trong luoi da duoc tao ra khong
            public bool isInside(int r, int c)
            {
                return r >= 0 && r < this.Rows && c >= 0 && c < this.Cols;
            }

            //Ham kiem tra xem trong luoi co trong khong
            public bool isEmpty(int r, int c)
            {
                return isInside(r, c) && grid[r, c] == 0;
            }

            //Ham kiem tra xem 1 hang co dang full cac block 1x1 chua
            public bool isRowFull(int r)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (grid[r, c] == 0)
                        return false;
                }
                return true;
            }
            //public bool isColsFull(int c)
            //{
            //    for (int r = 0; r < Rows; r++)
            //    {
            //        if (grid[r, c] == 0)
            //            return false;
            //    }
            //    return true;
            //}

            //Ham kiem tra 1 dong co bi trong khong
            public bool isRowEmpty(int r)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (grid[r, c] != 0)
                        return false;
                }
                return true;
            }

            //Ham xoa het mot dong
            public void ClearRows(int r)
            {
                for (int c = 0; c < Cols; c++)
                {
                    grid[r, c] = 0;
                }
            }

            //Khi mot hang full cac block 1x1, no se mat di, luc do cac hang phia tren no phai di chuyen xuong
            public void MoveRowsDown(int r, int numsRow)
            {
                for (int c = 0; c < Cols; c++)
                {
                    grid[r + numsRow, c] = grid[r, c];
                    grid[r, c] = 0;
                }
            }

            //Xoa tat ca cac hang
            public int ClearFullRows()
            {
                int cleared = 0;
                for (int r = Rows - 1; r >= 0; r--)
                {
                    if (isRowFull(r))
                    {
                        ClearRows(r);
                        cleared++;
                    }
                    else if (cleared > 0)
                    {
                        MoveRowsDown(r, cleared);
                    }
                }
                return cleared;
            }
        }
}

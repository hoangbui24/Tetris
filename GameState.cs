using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Tetrominoes currentTetro;
        public Tetrominoes CurrentTetro
        {
            //Tao cac khoi Tetro
            get => currentTetro;
            private set
            {
                currentTetro = value;
                currentTetro.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentTetro.Move(1, 0);
                    if (!TetrominoesFits())
                    {
                        currentTetro.Move(-1, 0);
                    }    
                }    
            }
        }
        public GameGrid GameGrid { get; }
        public TetrominoesQueue queue { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }
        public Tetrominoes HeldTetro { get; private set; }
        public bool CanHold { get; private set; }
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            queue = new TetrominoesQueue();
            CurrentTetro = queue.GetAndUpdate();
            CanHold = true;
        }
        private bool TetrominoesFits()
        {
            foreach (Pos p in CurrentTetro.TilePositions())
            {
                if(!GameGrid.isEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        //Dua khoi tetro vao khung Hold de giu lai xai sau
        public void HoldTeto()
        {
            if (!CanHold)
            {
                return;
            }    
            if (HeldTetro == null)
            {
                HeldTetro = CurrentTetro;
                CurrentTetro = queue.GetAndUpdate();
            } 
            else
            {
                //Ham swap co ban
                Tetrominoes temp = CurrentTetro;
                CurrentTetro = HeldTetro;
                HeldTetro = temp;
            }   
            CanHold = false;
        }

        //Xoay khoi tetro theo chieu kim dong ho (clock wise)
        public void RotateTetroCW()
        {
            CurrentTetro.RotateClockWise();
            if (!TetrominoesFits())
            {
                CurrentTetro.RotateCouterClockWise();
            }
        }

        //Xoay cac khoi tetro theo chieu nguoc kim dong ho (counter clock wise)
        public void RotateTetroCCW()
        {
            CurrentTetro.RotateCouterClockWise();
            if (!TetrominoesFits())
            {
                CurrentTetro.RotateClockWise();
            }
        }

        //Di chuyen khoi tetro sang phai
        public void MoveRight()
        {
            CurrentTetro.Move(0, 1);
            if (!TetrominoesFits())
            {
                CurrentTetro.Move(0,-1);
            }
        }

        //Di chuyen khoi tetro sang ben trai
        public void MoveLeft()
        {
            CurrentTetro.Move(0,-1);
            if (!TetrominoesFits())
            {
                CurrentTetro.Move(0,1);
            }
        }
        
        //Kiem tra xem game da ket thuc chua
        public bool isGameOver()
        {
            return !(GameGrid.isRowEmpty(0) && GameGrid.isRowEmpty(1));
        }


        private void PlaceTetro()
        {
            foreach(Pos p in CurrentTetro.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentTetro.Id;
            }

            Score += GameGrid.ClearFullRows();

            if (isGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentTetro = queue.GetAndUpdate();
                CanHold = true;
            }
        }

        //Di chuyen khoi tetro xuong duoi
        public void MoveDown()
        {
            CurrentTetro.Move(1,0);
            if (!TetrominoesFits())
            {
                CurrentTetro.Move(-1, 0);
                PlaceTetro();
            }
        }

        private int TileDropDistance(Pos p)
        {
            int drop = 0;

            while (GameGrid.isEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }    
            return drop;
        }

        public int TetroDropDistance()
        {
            int drop = GameGrid.Rows;
            foreach (Pos p in CurrentTetro.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }
            return drop;
        }

        public void DropTetro()
        {
            CurrentTetro.Move(TetroDropDistance(), 0);
            PlaceTetro();
        }
        public void Pause()
        {
            
        }
    }
}

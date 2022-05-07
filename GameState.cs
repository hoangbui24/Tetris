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
            get => currentTetro;
            private set
            {
                currentTetro = value;
                currentTetro.Reset();
            }
        }
        public GameGrid gameGrid { get; }
        public TetrominoesQueue queue { get; }
        public bool GameOver { get; private set; }
        public GameState()
        {
            gameGrid = new GameGrid(22, 10);
            queue = new TetrominoesQueue();
            currentTetro = queue.GetAndUpdate();
        }
        private bool TetrominoesFits()
        {
            foreach (Pos p in CurrentTetro.TilePositions())
            {
                if(gameGrid.isEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }
        public void RotateTetroCW()
        {
            CurrentTetro.RotateClockWise();
            if (!TetrominoesFits())
            {
                CurrentTetro.RotateCouterClockWise();
            }
        }
        public void RotateTetroCCW()
        {
            CurrentTetro.RotateCouterClockWise();
            if (!TetrominoesFits())
            {
                CurrentTetro.RotateClockWise();
            }
        }
        public void MoveRight()
        {
            CurrentTetro.Move(0, 1);
            if (!TetrominoesFits())
            {
                CurrentTetro.Move(0,-1);
            }
        }

        public void MoveLeft()
        {
            CurrentTetro.Move(0,-1);
            if (!TetrominoesFits())
            {
                CurrentTetro.Move(0,1);
            }
        }

        public bool isGameOver()
        {
            return !(gameGrid.isRowEmpty(0) && gameGrid.isRowEmpty(1));
        }

        private void PlaceTetro()
        {
            foreach(Pos p in CurrentTetro.TilePositions())
            {
                gameGrid[p.Row, p.Column] = CurrentTetro.Id;
            }

            gameGrid.ClearFullRows();

            if (isGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentTetro = queue.GetAndUpdate();
            }
        }

        public void MoveDown()
        {
            CurrentTetro.Move(1,0);
            if (!TetrominoesFits())
            {
                CurrentTetro.Move(-1, 0);
                PlaceTetro();
            }
        }
    }
}

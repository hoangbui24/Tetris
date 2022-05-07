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

    }
}

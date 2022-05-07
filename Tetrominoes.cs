using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Tetrominoes
    {
        protected abstract Pos[][] Tiles { get; }
        protected abstract Pos startOffset { get; }
        public abstract int Id { get; }
        private int rotationState;
        private Pos offset;
        public Tetrominoes()
        {
            offset = new Pos(startOffset.Row, startOffset.Column);
        }
        public IEnumerable<Pos> TilePositions()
        {
            foreach (Pos pos in Tiles[rotationState])
            {
                yield return new Pos(pos.Row + offset.Row, pos.Column + offset.Column);
            }
        }
        public void RotateClockWise()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }
        public void RotateCouterClockWise()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = startOffset.Row;
            offset.Column = startOffset.Column;
        }
    }
}

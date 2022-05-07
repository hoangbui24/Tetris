using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class O_Tetrominoes : Tetrominoes
    {
        private readonly Pos[][] tiles = new Pos[][]
        {
            new Pos[] { new (0,0), new (0,1), new(1,0), new(1,1)}
        };
        public override int Id => 4;
        protected override Pos startOffset => new Pos(0,4);
        protected override Pos[][] Tiles => tiles;
    }
}

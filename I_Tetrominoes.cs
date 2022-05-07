using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class I_Tetrominoes : Tetrominoes
    {
        private readonly Pos[][] tiles = new Pos[][]
            {
                //O vi tri khoi tao, khoi tetro I nam o cac vi tri sau day
                new Pos[] { new (1,0), new (1,1), new (1,2), new (1,3) },
                new Pos[] { new (2,0), new (2,1), new (2,2), new (2,3) },
                new Pos[] { new (0,1), new (1,1), new (2,1), new (3,1) },
                new Pos[] { new (0,2), new (1,2), new (2,2), new (3,2) },
            };

        public override int Id => 1;
        protected override Pos startOffset => new Pos(-1,3);
        protected override Pos[][] Tiles => tiles;
    }
}

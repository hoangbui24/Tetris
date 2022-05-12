using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class T_Tetrominoes : Tetrominoes
    {
        protected override Pos[][] Tiles => new Pos[][]
        {
            //Khoi tao cac vi tri cua khoi T
            new Pos[] { new(1,0), new(1,1), new(1,2), new(2,1) },
            new Pos[] { new(0,1), new(1,0), new(1,1), new(1,2) },
            new Pos[] { new(0,1), new(1,1), new(1,2), new(2,1) },
            new Pos[] { new(0,1), new(1,0), new(1,1), new(2,1) },
        };
        
        //gan cho khoi nay co ID = 6
        public override int Id => 6;
        protected override Pos startOffset => new(0,3);
        
    }
}

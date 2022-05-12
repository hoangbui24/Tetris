using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class J_Tetrominoes : Tetrominoes
    {
        //Khoi tao vi tri cua khoi J trong o 3x3
        protected override Pos[][] Tiles => new Pos[][]
        {
            new Pos[] { new(0,0), new(1,0), new(1,1), new(1,2) },
            new Pos[] { new(0,1), new(0,2), new(1,1), new(2,1) },
            new Pos[] { new(1,0), new(1,1), new(1,2), new(2,2) },
            new Pos[] { new(0,1), new(1,1), new(2,0), new(2,1) }
        };
        public override int Id => 2;
        protected override Pos startOffset => new(0,5);
        


    }
}

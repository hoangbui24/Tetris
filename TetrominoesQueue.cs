using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrominoesQueue
    {
        private readonly Tetrominoes[] tetrominoes = new Tetrominoes[]
        {
            new I_Tetrominoes(),
            new J_Tetrominoes(),
            new L_Tetrominoes(),
            new O_Tetrominoes(),
            new S_Tetrominoes(),
            new T_Tetrominoes(),
            new Z_Tetrominoes(),
        };

        private readonly Random rnd = new Random();
        public Tetrominoes NextTetro { get; private set; }
        public TetrominoesQueue()
        {
            NextTetro = RandomTetrominoes();
        }
        private Tetrominoes RandomTetrominoes()
        {
            return tetrominoes[rnd.Next(tetrominoes.Length)];
        }
        public Tetrominoes GetAndUpdate()
        {
            Tetrominoes tetrominoes = NextTetro;
            do
            {
                NextTetro = RandomTetrominoes();
            } while (tetrominoes.Id == NextTetro.Id);
            return tetrominoes;
        }
    }
}

using FNVCB.MODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.MODEL
{
    internal class Guess : IGuess
    {
        private readonly string _value;
        private readonly int _score;

        public Guess(string entry, int score)
        {
            _value = entry;
            _score = score; 
        }

        public string Value => _value;

        public int Score => _score;

        public int Length => _value.Length;
    }
}

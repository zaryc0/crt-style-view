using FNVCB.MODEL.Interfaces;
using FNVCB.VIEWMODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.VIEWMODEL
{
    public class Guess_VM : BaseViewModel, IGuess_VM
    {
        private IGuess _guess;
        public Guess_VM() { }
        public Guess_VM(IGuess guess)
        {
            _guess = guess;
        }

        public string Value => _guess.Value;

        public string Score => $"{_guess.Score + "/" + _guess.Length}";

    }
}

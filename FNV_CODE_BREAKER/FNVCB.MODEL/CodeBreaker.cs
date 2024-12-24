using FNVCB.MODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.MODEL
{
    internal class CodeBreaker : ICodeBreaker
    {
        private List<IGuess> _guesses = [];
        public int AddGuess(IGuess guess)
        {
            if (_guesses.Count() > 0 && _guesses[0].Length != guess.Length)
            {
                // error code -1 entry length does not match previous entries
                return -1;
            }
            _guesses.Add(guess);
            return 0;
        }

        public int ClearCache()
        {
            _guesses = [];
            if (_guesses.Count != 0)
            {
                return -1;
            }
            return 0;
        }

        public int CompareResult(string entry, out bool result)
        {
            result = false;
            if (_guesses.Count > 0)
            {
                if (_guesses[0].Length != entry.Length)
                {
                    // error code -1 entry length does not match previous entries
                    return -1;
                }
                foreach (IGuess guess in _guesses)
                {
                    int matches = 0;
                    for (int i = 0; i < guess.Length; i++)
                    {
                        char a = guess.Value[i];
                        char b = entry[i];
                        if (a == b)
                        {
                            matches++;
                        }
                    }
                    if (matches < guess.Score)
                    {
                        result = false;
                        return 1;
                    }
                    if (matches > guess.Score)
                    {
                        result = false;
                        return 2;
                    }
                }
                result = true;
                return 0;
            }
            else return -2;
        }

        public void RemoveGuessAt(int selectedItem)
        {
            _guesses.RemoveAt(selectedItem);
        }
    }
}

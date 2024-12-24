using FNVCG.MODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.MODEL
{
    internal class CodeBreaker : ICodeBreaker
    {
        private string _code;
        private int _attempts;
        public int SetCode(string code)
        {
            if(_code == null || _code == "")
            {
                _code = code;
                return 0;
            }
            return 1;
        }

        public int ClearCache()
        {
            _code = "";
            return 0;
        }

        public int CompareResult(string entry, out bool result)
        {
            int matches = 0;
            result = false;
            _attempts--;
            if (_code != null && _code.Length > 3)
            {

                for (int i = 0; i < _code.Length; i++)
                {
                    char a = _code[i];
                    char b = entry[i];
                    if (a == b)
                    {
                        matches++;
                    }
                }
                if (matches == _code.Length)
                {
                    result = true;
                }
            }
            return matches;
        }

        public int GetRemainingAttempts()
        {
            return _attempts;
        }

        public int ResetAttempts()
        {
           return _attempts = 4;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.MODEL.Interfaces
{
    public interface ICodeBreaker
    {
        int AddGuess(IGuess guess);
        int CompareResult(string entry, out bool result);
        int ClearCache();
        void RemoveGuessAt(int selectedItem);
    }
}

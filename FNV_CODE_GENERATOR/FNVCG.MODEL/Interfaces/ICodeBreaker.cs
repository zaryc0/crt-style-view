using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.MODEL.Interfaces
{
    public interface ICodeBreaker
    {
        int SetCode(string Code);
        int GetRemainingAttempts();
        int ResetAttempts();
        int CompareResult(string entry, out bool result);
        int ClearCache();
    }
}

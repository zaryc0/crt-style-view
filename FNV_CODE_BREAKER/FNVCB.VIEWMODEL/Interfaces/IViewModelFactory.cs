using FNVCB.MODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.VIEWMODEL.Interfaces
{
    public interface IViewModelFactory
    {
        IConsole_VM GenerateConsoleVM();
        IInput_VM GenerateInputVM();
        IShell_VM GenerateShellVM();
        IGuess_VM GetGuessVM(IGuess guess);
    }
}

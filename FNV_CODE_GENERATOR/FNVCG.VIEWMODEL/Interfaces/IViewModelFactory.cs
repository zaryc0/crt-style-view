using FNVCG.MODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.VIEWMODEL.Interfaces
{
    public interface IViewModelFactory
    {
        IConsole_VM GenerateConsoleVM();
        IShell_VM GenerateShellVM();
    }
}

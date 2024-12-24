using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.VIEWMODEL.Interfaces
{
    public interface IShell_VM
    {
        string Title { get; set; }
        IConsole_VM ConsoleVM { get; set; }
        IInput_VM InputVM { get; set; }
    }
}

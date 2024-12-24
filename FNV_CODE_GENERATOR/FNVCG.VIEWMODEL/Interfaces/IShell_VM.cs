using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.VIEWMODEL.Interfaces
{
    public interface IShell_VM
    {
        string Title { get; set; }
        IConsole_VM ConsoleVM { get; set; }
    }
}

using FNVCG.COMMON.Interfaces;
using FNVCG.MODEL.Interfaces;
using FNVCG.VIEWMODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.VIEWMODEL
{
    public class Shell_VM : BaseViewModel, IShell_VM
    {
        private IViewModelFactory _viewModelFactory;
        private string _title;
        private IConsole_VM _consolevm;
        public Shell_VM() { }
        public Shell_VM(IViewModelFactory vmf)
        {
            _viewModelFactory = vmf;
            ConsoleVM = vmf.GenerateConsoleVM();
            Title = "FNV-Code-Generator";
        }
        public string Title
        {
            get => _title;
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged(nameof(Title));
                }
            }
        }
        public IConsole_VM ConsoleVM 
        {
            get => _consolevm;
            set
            {
                if (value != _consolevm)
                {
                    _consolevm = value;
                    NotifyPropertyChanged(nameof(ConsoleVM));
                }
            }
        }
    }
}

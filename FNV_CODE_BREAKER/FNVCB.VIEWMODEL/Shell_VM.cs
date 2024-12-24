using FNVCB.COMMON.Interfaces;
using FNVCB.MODEL.Interfaces;
using FNVCB.VIEWMODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.VIEWMODEL
{
    public class Shell_VM : BaseViewModel, IShell_VM
    {
        private IViewModelFactory _viewModelFactory;
        private string _title;
        private IConsole_VM _consolevm;
        private IInput_VM _inputvm;
        public Shell_VM() { }
        public Shell_VM(IViewModelFactory vmf)
        {
            _viewModelFactory = vmf;
            ConsoleVM = vmf.GenerateConsoleVM();
            InputVM = vmf.GenerateInputVM();
            Title = "FNV-Code-Breaker";
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

        public IInput_VM InputVM 
        {
            get => _inputvm; 
            set
            { 
                if (_inputvm != value)
                {
                    _inputvm = value;
                    NotifyPropertyChanged(nameof(InputVM));
                }
            } 
        }
    }
}

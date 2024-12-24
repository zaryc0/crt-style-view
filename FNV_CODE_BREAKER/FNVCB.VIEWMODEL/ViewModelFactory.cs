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
    public class ViewModelFactory : IViewModelFactory
    {
        private IEventAggregator _eventAggregator;
        private IModelFactory _modelFactory;
        public ViewModelFactory(IEventAggregator ea, IModelFactory mf) 
        {
            _eventAggregator = ea;
            _modelFactory = mf;
        }
        public IGuess_VM GetGuessVM(IGuess guess)
        {
            return new Guess_VM(guess);
        }

        public IConsole_VM GenerateConsoleVM()
        {
            return new Console_VM(_eventAggregator, this, _modelFactory);
        }

        public IInput_VM GenerateInputVM()
        {
            return new Input_VM(_eventAggregator,_modelFactory);
        }

        public IShell_VM GenerateShellVM()
        {
            return new Shell_VM(this);
        }
    }
}

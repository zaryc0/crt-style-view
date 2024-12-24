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
    public class ViewModelFactory : IViewModelFactory
    {
        private IEventAggregator _eventAggregator;
        private IModelFactory _modelFactory;
        public ViewModelFactory(IEventAggregator ea, IModelFactory mf) 
        {
            _eventAggregator = ea;
            _modelFactory = mf;
        }

        public IConsole_VM GenerateConsoleVM()
        {
            return new Console_VM(_eventAggregator, this, _modelFactory);
        }

        public IShell_VM GenerateShellVM()
        {
            return new Shell_VM(this);
        }
    }
}

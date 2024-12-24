using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FNVCB.VIEWMODEL.Interfaces
{
    public interface IInput_VM
    {
        public string Value { get; set; }
        public string Score { get; set; }
        public string Submission { get; }
        public ICommand Submit { get; }
    }
}

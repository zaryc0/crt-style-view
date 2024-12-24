using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.MODEL.Interfaces
{
    public interface IModelFactory
    {
        public ICodeGenerator GenerateCodeGenerator(int seed = 0);
        public ICodeBreaker GenerateCodeBreaker();
    }
}

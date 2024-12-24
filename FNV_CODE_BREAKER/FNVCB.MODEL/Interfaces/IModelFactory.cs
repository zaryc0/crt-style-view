using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.MODEL.Interfaces
{
    public interface IModelFactory
    {
        public IGuess GenerateGuess(string value, int score);
        public ICodeBreaker GenerateCodeBreaker();
    }
}

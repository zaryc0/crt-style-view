using FNVCG.MODEL.Interfaces;
using System.Buffers;

namespace FNVCG.MODEL
{
    public class ModelFactory : IModelFactory
    {
        private readonly ICodeGenerator _cg = new CodeGenerator();
        public ModelFactory() 
        { }

        public ICodeBreaker GenerateCodeBreaker()
        {
            return new CodeBreaker();
        }

        public ICodeGenerator GenerateCodeGenerator(int seed = 0)
        {
            return _cg;
        }
    }
}

using FNVCB.MODEL.Interfaces;
using System.Buffers;

namespace FNVCB.MODEL
{
    public class ModelFactory : IModelFactory
    {
        private ICodeBreaker _cb;
        public ModelFactory()
        {
            _cb = new CodeBreaker();
        }

        public ICodeBreaker GenerateCodeBreaker()
        {
            return _cb;
        }

        public IGuess GenerateGuess(string guess, int value)
        {
            return new Guess(guess,value);
        }

    }
}

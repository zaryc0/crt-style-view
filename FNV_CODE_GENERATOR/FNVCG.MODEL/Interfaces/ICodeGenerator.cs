using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.MODEL.Interfaces
{
    public interface ICodeGenerator
    {
        int GenerateWordList(int length, out List<string> words);
        int GenerateCode(out string code);
        void ResetCache();
        List<string> GetWordList();
    }
}

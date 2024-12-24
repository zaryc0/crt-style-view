using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCB.MODEL.Interfaces
{
    public interface IGuess
    {
        public string Value { get; }
        public int Score { get; }
        public int Length { get; }
    }
}

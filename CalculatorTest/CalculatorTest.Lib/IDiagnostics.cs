using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest.Lib
{
    public interface IDiagnostics
    {
        void LogResult(string function, string result);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CalculatorTest.Lib
{
    public class SimpleCalculator : ISimpleCalculator
    {
        IDiagnostics _daignostics;
        int result = 0;

        public SimpleCalculator(IDiagnostics diagnostics)
        {
            _daignostics = diagnostics;
        }

        public int Add(int start, int amount)
        {
             result = start + amount;
            _daignostics.LogResult(MethodBase.GetCurrentMethod().Name, result.ToString());
            return result;
        }

        public int Divide(int start, int by)
        {
            result = start / by;
            _daignostics.LogResult(MethodBase.GetCurrentMethod().Name, result.ToString());
            return result;
        }

        public int Multiply(int start, int by)
        {
            result = start * by;
            _daignostics.LogResult(MethodBase.GetCurrentMethod().Name, result.ToString());
            return result;
        }

        public int Subtract(int start, int amount)
        {
            result = start - amount;
            _daignostics.LogResult(MethodBase.GetCurrentMethod().Name, result.ToString());
            return result;
        }
    }
}

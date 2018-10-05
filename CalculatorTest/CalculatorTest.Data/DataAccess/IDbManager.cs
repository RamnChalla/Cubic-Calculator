using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest.Data.DataAccess
{
    public interface IDbManager
    {
        void SaveResult(string function, string result, int mode);
    }
}

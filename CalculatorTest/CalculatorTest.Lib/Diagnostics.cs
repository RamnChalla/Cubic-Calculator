using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorTest.Data.DataAccess;

namespace CalculatorTest.Lib
{
    public class Diagnostics : IDiagnostics
    {
        private LogMode Mode { get; set; }

        public Diagnostics()
        {
            Mode = LogMode.Console;
        }
        public Diagnostics(LogMode logMode)
        {
            Mode = logMode;
        }

        public void LogResult(string function, string result)
        {
            IDbManager dbManager = new DbManager();

            if (Mode.Equals(LogMode.Console))
            {
                Console.WriteLine("Calculator function - {0} with result - {1}", function, result);
                Console.ReadLine();
            }
            else 
            {
                dbManager.SaveResult(function, result, (int)Mode);
            }            
        }
    }
}

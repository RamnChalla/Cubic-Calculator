using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest.Data
{
    public class Constants
    {
        public const int AdoNetMode = 1;
        public const int OrmMode = 2;

        public static string AdoNetConnection = "CalculatorDbConnectionString";
        public static string OrmConnection = "CalculationsEntities";
        public static string InsertResultDataProc = "InsertCalculatorResult";

    }
}

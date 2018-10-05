using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest.Lib
{
    public enum LogMode
    {
        Console,
        ADONET,
        ORM
    }

    public class LogIdentifier
    {
        public LogMode Mode { get; set; }
    }
}

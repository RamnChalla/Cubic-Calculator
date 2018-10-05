using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CalculatorTest.Lib;

namespace CalculatorTest.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : ApiController
    {
        [HttpGet]
        public int Add(int value1, int value2)
        {
            IDiagnostics diagnostics = new Diagnostics(LogMode.ORM);
            ISimpleCalculator calculator = new SimpleCalculator(diagnostics);

            return calculator.Add(value1, value2);            
        }

        [HttpGet]
        public int Substract(int value1, int value2)
        {
            IDiagnostics diagnostics = new Diagnostics(LogMode.ORM);
            ISimpleCalculator calculator = new SimpleCalculator(diagnostics);

            return calculator.Subtract(value1, value2);
        }

        [HttpGet]
        public int Multiply(int value1, int value2)
        {
            IDiagnostics diagnostics = new Diagnostics(LogMode.ORM);
            ISimpleCalculator calculator = new SimpleCalculator(diagnostics);

            return calculator.Multiply(value1, value2);
        }

        [HttpGet]
        public int Divide(int value1, int value2)
        {
            IDiagnostics diagnostics = new Diagnostics(LogMode.ORM);
            ISimpleCalculator calculator = new SimpleCalculator(diagnostics);

            return calculator.Divide(value1, value2);
        }

        [HttpGet]
        public string Get()
        {
            return "Calculator API";
        }
    }
}

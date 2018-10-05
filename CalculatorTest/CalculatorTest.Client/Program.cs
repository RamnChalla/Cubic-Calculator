using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CalculatorTest.Lib;
using Newtonsoft.Json;

namespace CalculatorTest.Client
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            // 1. Log to the console
            //IDiagnostics diagnosticsConsole = new Diagnostics();         
            //ISimpleCalculator calculator = new SimpleCalculator(diagnosticsConsole);
            //calculator.Add(2, 254);

            //2. Log into database via ADO.NET
            //IDiagnostics diagnosticsAdoNet = new Diagnostics(LogMode.ADONET);
            //ISimpleCalculator calculatorAdo = new SimpleCalculator(diagnosticsAdoNet);
            //calculatorAdo.Add(2, 254);

            //3. Log into database via ADO.NET
            IDiagnostics diagnosticsOrm = new Diagnostics(LogMode.ORM);
            ISimpleCalculator calculatorOrm = new SimpleCalculator(diagnosticsOrm);
            calculatorOrm.Add(2, 254);

            //4. Consume Calculator Api 

            //  var baseUrl = "http://localhost:25919/Api/Calculator";          
            //var input = new
            //{
            //    value1 = 2,
            //    value2 = 4
            //};
            //string inputJson = JsonConvert.SerializeObject(input);
            //var client = new WebClient();
            //client.Headers["Content-type"] = "application/json";
            //client.Encoding = Encoding.UTF8;
            //string json = client.UploadString(baseUrl + "/Add", inputJson);

            //Console.WriteLine("Result - {0}", json);           
            //Console.ReadLine();

        }
    }

}

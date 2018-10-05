using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CalculatorTest.Lib;

namespace CalculatorTest.Tests
{
    [TestClass]
    public class SampleCalculatorTest
    {
        private SimpleCalculator _simplecalculator;   // object under test, real object
        private Mock<IDiagnostics> _diagnostics;     // dependency of SimpleCalculator

        [TestInitialize]
        public void Initialize()
        {
            _diagnostics = new Mock<IDiagnostics>();
            _simplecalculator = new SimpleCalculator(_diagnostics.Object);
        }

        [TestMethod]
        public void Add_TwoNumbers_ShouldReturnsExpectedResult()
        {            
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
                It.IsAny<string>()));                       
            var result = _simplecalculator.Add(2, 2);

            // Verify the Add result 
            Assert.AreEqual(result, 4);                                  
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ShouldReturnsExpectedResult()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
                It.IsAny<string>()));

            // Verify the Add result 
            Assert.AreEqual(_simplecalculator.Multiply(14, 2), 28);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ShouldReturnsExpectedResult()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
                It.IsAny<string>()));

            // Verify the Add result 
            Assert.AreEqual(_simplecalculator.Divide(4, 3), 1);
        }

        [TestMethod]
        public void Substract_TwoNumbers_ShouldReturnsExpectedResult()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
               It.IsAny<string>()));

            // Verify the Add result 
            Assert.AreEqual(_simplecalculator.Subtract(8, 2), 6);
        }

        [TestMethod]
        public void Verify_CalculatorAdd_CallsDiagnosticsLogging()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
               It.IsAny<string>()));
            var result = _simplecalculator.Add(2, 2);

            //Verify that Diagnostics method was called
            _diagnostics.Verify((m => m.LogResult(It.IsAny<string>(), It.IsAny<string>())), Times.Once());
        }            

        [TestMethod]
        public void Verify_CalculatorMultiply_CallsDiagnosticsLogging()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
               It.IsAny<string>()));
            var result = _simplecalculator.Multiply(2, 2);

            //Verify that Diagnostics method was called
            _diagnostics.Verify((m => m.LogResult(It.IsAny<string>(), It.IsAny<string>())), Times.Once());
        }

        [TestMethod]
        public void Verify_CalculatorDivide_CallsDiagnosticsLogging()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
               It.IsAny<string>()));
            var result = _simplecalculator.Divide(4, 2);

            //Verify that Diagnostics method was called
            _diagnostics.Verify((m => m.LogResult(It.IsAny<string>(), It.IsAny<string>())), Times.Once());
        }

        [TestMethod]
        public void Verify_CalculatorSubstract_CallsDiagnosticsLogging()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
                It.IsAny<string>()));
            var result = _simplecalculator.Subtract(4, 2);

            //Verify that Diagnostics method was called
            _diagnostics.Verify((m => m.LogResult(It.IsAny<string>(), It.IsAny<string>())), Times.Once());
        }


        [TestMethod]
        public void Verify_CalculatorAdd_NeverCallsDiagnosticsLogging()
        {
            // setup diagnostics mock object
            _diagnostics.Setup(m => m.LogResult(It.IsAny<string>(),
                It.IsAny<string>()));

            //Verify that Diagnostics method was called
            _diagnostics.Verify((m => m.LogResult(It.IsAny<string>(), It.IsAny<string>())), Times.Once());
        }
    }
}

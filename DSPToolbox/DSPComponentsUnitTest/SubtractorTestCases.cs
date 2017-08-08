using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DSPAlgorithms.Algorithms;
using DSPAlgorithms.DataStructures;

namespace DSPComponentsUnitTest
{
    [TestClass]
    public class SubtractorTestCases
    {
        //signal2 - signal1
        [TestMethod]
        public void SubtractorTestMethod1()
        {
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal1.ds");
            var sig2 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal2.ds");

            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Subtractor_TestCase1.ds").Samples;
           
            Subtractor m = new Subtractor();
            m.InputSignal1 = sig2;
            m.InputSignal2 = sig1;

            m.Run();
            
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, m.OutputSignal.Samples));
        }

        //signal3 - signal1
        [TestMethod]
        public void SubtractorTestMethod2()
        {
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal1.ds");
            var sig2 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal3.ds");

            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Subtractor_TestCase2.ds").Samples;
           
            Subtractor m = new Subtractor();
            m.InputSignal1 = sig2;
            m.InputSignal2 = sig1;

            m.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, m.OutputSignal.Samples));
        }
    }
}

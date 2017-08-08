using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.Algorithms;
using System.Collections.Generic;

namespace DSPComponentsUnitTest
{
    [TestClass]
    public class MultiplySignalByConstantTestCases
    {
        //multiply signal1 by 5
        [TestMethod]
        public void MultiplySignalByConstantTestMethod1()
        {
            // test case 1 ..
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal1.ds");

            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/MultiplySignalByConstant_TestCase1.ds").Samples;
           
            MultiplySignalByConstant m = new MultiplySignalByConstant();
            m.InputSignal = sig1;
            m.InputConstant = 5 ;
           
            m.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, m.OutputMultipliedSignal.Samples));
        }

        //magnify the signal2 by 10
        [TestMethod]
        public void MultiplySignalByConstantTestMethod2()
        {
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal2.ds");
            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/MultiplySignalByConstant_TestCase2.ds").Samples;
           

            MultiplySignalByConstant m = new MultiplySignalByConstant();
            m.InputSignal = sig1;
            m.InputConstant = 10;

            m.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, m.OutputMultipliedSignal.Samples));
        }

      
    }
}

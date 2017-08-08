using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.Algorithms;

namespace DSPComponentsUnitTest
{
    [TestClass]
    public class MovingAverageTestCases
    {

        //signal 1 by 3
        [TestMethod]
        public void MovingAverageTestMethod1()
        {
            // test case 1 ..
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal1.ds");
            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/MovingAverage_TestCase1.ds").Samples;

            MovingAverage a = new MovingAverage();
            a.InputSignal = sig1;
            a.InputWindowSize = 3;
            
            a.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, a.OutputAverageSignal.Samples));
        }


        //signal 2 by 5
        [TestMethod]
        public void MovingAverageTestMethod2()
        {
            // test case 2 ..
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal2.ds");
            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/MovingAverage_TestCase2.ds").Samples;

            MovingAverage a = new MovingAverage();
            a.InputSignal = sig1;
            a.InputWindowSize = 5;         

            a.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, a.OutputAverageSignal.Samples));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.Algorithms;
using System.Collections.Generic;

namespace DSPComponentsUnitTest
{
    [TestClass]
    public class NormalizerTestCases
    {

        //normalize a signal1 from -1 to 1 
        [TestMethod]
        public void NormalizerTestMethod1()
        {
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal1.ds");

            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Normalizer_TestCase1.ds").Samples;
           
            Normalizer a = new Normalizer();
            a.InputMinRange = -1;
            a.InputMaxRange = 1;
            a.InputSignal = sig1;

            a.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, a.OutputNormalizedSignal.Samples));
        }

        //normalize a signal2 from 0 to 1 
        [TestMethod]
        public void NormalizerTestMethod2()
        {
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal2.ds");
            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Normalizer_TestCase2.ds").Samples;
           
            Normalizer a = new Normalizer();
            a.InputMinRange = 0;
            a.InputMaxRange = 1;
            a.InputSignal = sig1;

            a.Run();
            
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, a.OutputNormalizedSignal.Samples));
        }

    }
}

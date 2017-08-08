using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DSPAlgorithms.DataStructures;
using DSPAlgorithms.Algorithms;

namespace DSPComponentsUnitTest
{
    [TestClass]
    public class AdderTestCases
    {
        //Add 2 signals -- 1,2
        [TestMethod]
        public void AdderTestMethod1()
        {
            // test case 1 ..
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal1.ds");
            var sig2 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal2.ds");


           var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Adder_TestCase1.ds");

            Adder a = new Adder();            
            a.InputSignals = new List<Signal>();
            a.InputSignals.Add(sig1);
            a.InputSignals.Add(sig2);

            a.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, a.OutputSignal.Samples));
        }

        //Add 2 signals -- 1,3
        [TestMethod]
        public void AdderTestMethod2()
        {
           
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal1.ds");
            var sig2 = UnitTestUtitlities.LoadSignal("TestingSignals/Signal3.ds");

            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Adder_TestCase2.ds"); 

            Adder a = new Adder();
            a.InputSignals = new List<Signal>();
            a.InputSignals.Add(sig1);
            a.InputSignals.Add(sig2);

            a.Run();
            
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, a.OutputSignal.Samples));
        }

         
    }
}

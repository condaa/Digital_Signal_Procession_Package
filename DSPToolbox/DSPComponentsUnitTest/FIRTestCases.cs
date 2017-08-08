using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.Algorithms;

namespace DSPComponentsUnitTest
{
    /// <summary>
    /// Summary description for FIRTestCases
    /// </summary>
    [TestClass]
    public class FIRTestCases
    {
        [TestMethod]
        public void LowCoefficientsTestMethod1()
        {
            FIR FIR = new FIR();
                        
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedCoefficients = UnitTestUtitlities.LoadSignal("TestingSignals/LPFCoefficients.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.LOW;
            FIR.InputFS = 8000;
            FIR.InputStopBandAttenuation = 50;
            FIR.InputCutOffFrequency = 1500;
            FIR.InputTransitionBand = 500;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedCoefficients, FIR.OutputHn));
        }

        [TestMethod]
        public void LowFilteredSignalTestMethod1()
        {
            FIR FIR = new FIR();

            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedFilteredSignal = UnitTestUtitlities.LoadSignal("TestingSignals/ecg_low_pass_filtered.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.LOW;
            FIR.InputFS = 8000;
            FIR.InputStopBandAttenuation = 50;
            FIR.InputCutOffFrequency = 1500;
            FIR.InputTransitionBand = 500;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedFilteredSignal, FIR.OutputYn));

            //
            // TODO: Add test logic here
            //
        }
      
        [TestMethod]
        public void HighCoefficientsTestMethod2()
        {
            FIR FIR = new FIR();

            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedCoefficients = UnitTestUtitlities.LoadSignal("TestingSignals/HPFCoefficients.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.HIGH;
            FIR.InputFS = 8000;
            FIR.InputStopBandAttenuation = 70;
            FIR.InputCutOffFrequency = 1500;
            FIR.InputTransitionBand = 500;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedCoefficients, FIR.OutputHn));
        }

        [TestMethod]
        public void HighFilteredSignalTestMethod2()
        {
            FIR FIR = new FIR();

            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedFilteredSignal = UnitTestUtitlities.LoadSignal("TestingSignals/ecg_high_pass_filtered.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.HIGH;
            FIR.InputFS = 8000;
            FIR.InputStopBandAttenuation = 70;
            FIR.InputCutOffFrequency = 1500;
            FIR.InputTransitionBand = 500;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedFilteredSignal, FIR.OutputYn));
        }
    
        [TestMethod]
        public void BandPassCoefficientsTestMethod3()
        {
            FIR FIR = new FIR();

            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedCoefficients = UnitTestUtitlities.LoadSignal("TestingSignals/BPFCoefficients.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.BAND_PASS;
   
            FIR.InputFS = 1000;
            FIR.InputStopBandAttenuation = 60;
            FIR.InputF1 = 150;
            FIR.InputF2 = 250;
            FIR.InputTransitionBand = 50;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedCoefficients, FIR.OutputHn));
        }

        [TestMethod]
        public void BandPassFilteredSignalTestMethod3()
        {
            FIR FIR = new FIR();

            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedFilteredSignal = UnitTestUtitlities.LoadSignal("TestingSignals/ecg_band_pass_filtered.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.BAND_PASS;
            
            FIR.InputFS = 1000;
            FIR.InputStopBandAttenuation = 60;
            FIR.InputF1 = 150;
            FIR.InputF2 = 250;
            FIR.InputTransitionBand = 50;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedFilteredSignal, FIR.OutputYn));
        }

        [TestMethod]
        public void BandStopCoefficientsTestMethod4()
        {
            FIR FIR = new FIR();

            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedCoefficients = UnitTestUtitlities.LoadSignal("TestingSignals/BSFCoefficients.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.BAND_STOP;

            FIR.InputFS = 1000;
            FIR.InputStopBandAttenuation = 60;
            FIR.InputF1 = 150;
            FIR.InputF2 = 250;
            FIR.InputTransitionBand = 50;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedCoefficients, FIR.OutputHn));
        }

        [TestMethod]
        public void BandStopFilteredSignalTestMethod4()
        {
            FIR FIR = new FIR();

            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            var expectedFilteredSignal = UnitTestUtitlities.LoadSignal("TestingSignals/ecg_band_stop_filtered.ds");

            FIR.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.BAND_STOP;

            FIR.InputFS = 1000;
            FIR.InputStopBandAttenuation = 60;
            FIR.InputF1 = 150;
            FIR.InputF2 = 250;
            FIR.InputTransitionBand = 50;

            FIR.InputTimeDomainSignal = sig1;

            FIR.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedFilteredSignal, FIR.OutputYn));
        }
    }
}
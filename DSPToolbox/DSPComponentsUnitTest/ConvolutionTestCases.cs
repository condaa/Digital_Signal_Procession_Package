using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.Algorithms;
using DSPAlgorithms.DataStructures;

namespace DSPComponentsUnitTest
{
    /// <summary>
    /// Summary description for ConvolutionTestCases
    /// </summary>
    [TestClass]
    public class ConvolutionTestCases
    {
        [TestMethod]
        public void DirectConvolutionTestMethod1()
        {
            DirectConvolution dc = new DirectConvolution();
            // test case 1 ..
            var expectedOutput = new Signal(new List<float>() { 1, 3, 7, 7, 7, 6, 4 }, false);

            dc.InputSignal1 = new Signal(new List<float>() { 1, 2, 4 }, false);
            dc.InputSignal2 = new Signal(new List<float>() { 1, 1, 1, 1, 1 }, false);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputConvolvedSignal.Samples));
        }

        [TestMethod]
        public void DirectConvolutionTestMethod2()
        {
            DirectConvolution dc = new DirectConvolution();

            var expectedOutput = new Signal(new List<float>() { 0.5f, 1, 1, 1, 1.5f, 2, 1.5f, 0.5f }, false);

            dc.InputSignal1 = new Signal(new List<float>() { 1, 0, 0, 1, 1 }, false);
            dc.InputSignal2 = new Signal(new List<float>() { 0.5f, 1, 1, 0.5f }, false);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputConvolvedSignal.Samples));
        }

        [TestMethod]
        public void DirectConvolutionTestMethod3()
        {
            DirectConvolution dc = new DirectConvolution();

            var expectedOutput = new Signal(new List<float>() { 44, 143, 243, 442, 454, 367, 495, 132 }, false);

            dc.InputSignal1 = new Signal(new List<float>() { 1, 2, 3, 4 }, false);
            dc.InputSignal2 = new Signal(new List<float>() { 44, 55, 1, 99, 33 }, false);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputConvolvedSignal.Samples));
        }

        [TestMethod]
        public void DirectConvolutionTestMethod4()
        {
            DirectConvolution dc = new DirectConvolution();
            // test case 4 ..
            var expectedOutput = new Signal(new List<float>() { 1, 1, -1, 0, 0, 3, 3, 2, 1 }, new List<int>() { -2, -1, 0, 1, 2, 3, 4, 5, 6 }, false);

            dc.InputSignal1 = new Signal(new List<float>() { 1, 2, 1, 1 }, new List<int>() { -2, -1, 0, 1 }, false);

            dc.InputSignal2 = new Signal(new List<float>() { 1, -1, 0, 0, 1, 1 }, new List<int>() { 0, 1, 2, 3, 4, 5 }, false);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputConvolvedSignal.Samples));
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedOutput, dc.OutputConvolvedSignal));
        }



        [TestMethod]
        public void DirectConvolutionTestMethod5()
        {
            DirectConvolution dc = new DirectConvolution();
            // test case 4 ..
            var expectedOutput = new Signal(new List<float>() { -3, 2, 2, 3, 2 }, new List<int>() { -3, -2, -1, 0, 1 }, false);

            dc.InputSignal1 = new Signal(new List<float>() { 3, 1, 2, 0 }, new List<int>() { -2, -1, 0, 1 }, false);

            dc.InputSignal2 = new Signal(new List<float>() { -1, 1, 1 }, new List<int>() { -1, 1, 1 }, false);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputConvolvedSignal.Samples));
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedOutput, dc.OutputConvolvedSignal));
        }

        [TestMethod]
        public void FastConvolutionTestMethod1()
        {
            FastConvolution fc = new FastConvolution();

            var expectedOutput = new Signal(new List<float>() { 0.5f, 1, 1, 1, 1.5f, 2, 1.5f, 0.5f }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 1, 0, 0, 1, 1}, false);
            fc.InputSignal2 = new Signal(new List<float>() { 0.5f, 1, 1, 0.5f }, false);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputConvolvedSignal.Samples));
        }

        [TestMethod]
        public void FastConvolutionTestMethod2()
        {
            FastConvolution fc = new FastConvolution();

            var expectedOutput = new Signal(new List<float>() { 44, 143, 243, 442, 454, 367, 495, 132 }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 1, 2, 3, 4 }, false);
            fc.InputSignal2 = new Signal(new List<float>() { 44, 55, 1, 99, 33 }, false);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputConvolvedSignal.Samples));
        }
    }
}

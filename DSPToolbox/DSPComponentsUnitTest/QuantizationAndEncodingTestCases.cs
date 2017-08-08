using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.Algorithms;
using System.Collections.Generic;

namespace DSPComponentsUnitTest
{
    [TestClass]
    public class QuantizationAndEncodingTestCases
    {
        //bits = 3
        [TestMethod]
        public void QuantizationAndEncodingTestMethod1()
        {
            QuantizationAndEncoding Q = new QuantizationAndEncoding();
            Q.InputNumBits = 3;
            Q.InputSignal = new DSPAlgorithms.DataStructures.Signal(new List<float>(){0.387f,0.430f,0.478f,0.531f,0.590f,0.6561f,0.729f, 0.81f,0.9f,1f,0.2f}, false);
            Q.Run();

            List<string> expectedEncodedValues = new List<string>() { "001","010","010","011","011","100","101","110","110","111","000"};
            List<float> expectedQuantizedValues = new List<float>() { 0.35f,0.45f,0.45f,0.55f,0.55f,0.65f,0.75f,0.85f,0.85f,0.95f,0.25f};

            bool encodedValues = true;
            bool quantizedValues = true;

            for (int i = 0; i < expectedEncodedValues.Count; i++)
            {
                if (expectedEncodedValues[i] != Q.OutputEncodedSignal[i])
                {
                    encodedValues = false;
                    break;
                }
            }
            
            quantizedValues = UnitTestUtitlities.SignalsSamplesAreEqual(expectedQuantizedValues, Q.OutputQuantizedSignal.Samples);

            Assert.IsTrue(encodedValues && quantizedValues);       
        }

        //Levels = 8
        [TestMethod]
        public void QuantizationAndEncodingTestMethod2()
        {
            QuantizationAndEncoding Q = new QuantizationAndEncoding();
            Q.InputLevel = 8;
            Q.InputSignal = new DSPAlgorithms.DataStructures.Signal(new List<float>() { 0.387f, 0.430f, 0.478f, 0.531f, 0.590f, 0.6561f, 0.729f, 0.81f, 0.9f, 1f, 0.2f }, false);
            Q.Run();

            List<string> expectedEncodedValues = new List<string>() { "001", "010", "010", "011", "011", "100", "101", "110", "110", "111", "000" };
            List<float> expectedQuantizedValues = new List<float>() { 0.35f, 0.45f, 0.45f, 0.55f, 0.55f, 0.65f, 0.75f, 0.85f, 0.85f, 0.95f, 0.25f };

            bool encodedValues = true;
            bool quantizedValues = true;

            for (int i = 0; i < expectedEncodedValues.Count; i++)
            {
                if (expectedEncodedValues[i] != Q.OutputEncodedSignal[i])
                {
                    encodedValues = false;
                    break;
                }
            }

            quantizedValues = UnitTestUtitlities.SignalsSamplesAreEqual(expectedQuantizedValues, Q.OutputQuantizedSignal.Samples);

            Assert.IsTrue(encodedValues && quantizedValues);
        }

        //Levels = 4
        [TestMethod]
        public void QuantizationAndEncodingTestMethod3()
        {
            QuantizationAndEncoding Q = new QuantizationAndEncoding();
            Q.InputLevel = 4;
            Q.InputSignal = new DSPAlgorithms.DataStructures.Signal(new List<float>() { -1.22f, 1.5f, 3.24f, 3.94f, 2.20f, -1.1f, -2.26f, -1.88f, -1.2f }, false);
            Q.Run();
            
            List<int> expectedIntervalIndices = new List<int>() { 1,3,4,4,3,1,1,1,1};
            List<string> expectedEncodedValues = new List<string>() { "00", "10", "11", "11", "10", "00", "00", "00", "00"};
            List<float> expectedQuantizedValues = new List<float>() { -1.485f, 1.615f, 3.165f, 3.165f, 1.615f, -1.485f, -1.485f, -1.485f, -1.485f };
            List<float> expectedSampledError = new List<float>() { -0.265f, 0.115f, -0.075f, -0.775f, -0.585f, -0.385f, 0.775f , 0.395f, -0.285f};

            bool encodedValues = true;
            bool quantizedValues = true;
            bool indicesValues = true;
            bool errorValues = true;

            for (int i = 0; i < expectedEncodedValues.Count; i++)
            {
                if (expectedEncodedValues[i] != Q.OutputEncodedSignal[i])
                {
                    encodedValues = false;
                    break;
                }
            }

            quantizedValues = UnitTestUtitlities.SignalsSamplesAreEqual(expectedQuantizedValues, Q.OutputQuantizedSignal.Samples);
            errorValues = UnitTestUtitlities.SignalsSamplesAreEqual(expectedSampledError, Q.OutputSamplesError);
            
            for (int i = 0; i < expectedIntervalIndices.Count; i++)
            {
                if (expectedIntervalIndices[i] != Q.OutputIntervalIndices[i])
                {
                    indicesValues = false;
                    break;
                }
            }

            Assert.IsTrue(encodedValues && quantizedValues && indicesValues && errorValues);
        }
    }
}

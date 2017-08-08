using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPComponentsUnitTest
{
    public static class UnitTestUtitlities
    {
        public static void ConstructSignalFromSamples(string filePath)
        {
            StreamReader sr = new StreamReader("TestingSignals/FilterCoefficients_Low.txt");
            StreamWriter streamSaver = new StreamWriter(@"D:\Career\Teaching\2017\Second Term\DSP\DSP Toolbox\DSPToolbox\DSPUI\bin\Debug\TestingSignals\LPFCoefficients.ds");

            List<float> SigSamples = new List<float>();
            List<int> SigIndices = new List<int>();
            int c = 0;

            while (!sr.EndOfStream)
            {
                var sample = float.Parse(sr.ReadLine());
                SigSamples.Add(sample);
                SigIndices.Add(c++);
            }
         
            sr.Close();

            streamSaver.WriteLine(0);
            streamSaver.WriteLine(0);
            streamSaver.WriteLine(SigSamples.Count);

            for (int i = 0; i < SigSamples.Count; i++)
            {
                streamSaver.Write(SigIndices[i]);
                streamSaver.WriteLine(" " + SigSamples[i]);
            }

            streamSaver.Flush();
            streamSaver.Close();
        }
        public static Signal LoadSignal(string filePath)
        {
            Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(stream);

            var sigType = byte.Parse(sr.ReadLine());
            var isPeriodic = byte.Parse(sr.ReadLine());
            long N1 = long.Parse(sr.ReadLine());

            List<float> SigSamples = new List<float>(unchecked((int)N1));
            List<int> SigIndices = new List<int>(unchecked((int)N1));
            List<float> SigFreq = new List<float>(unchecked((int)N1));
            List<float> SigFreqAmp = new List<float>(unchecked((int)N1));
            List<float> SigPhaseShift = new List<float>(unchecked((int)N1));

            if (sigType == 1)
            {
                SigSamples = null;
                SigIndices = null;
            }

            for (int i = 0; i < N1; i++)
            {
                if (sigType == 0 || sigType == 2)
                {
                    var timeIndex_SampleAmplitude = sr.ReadLine().Split();
                    SigIndices.Add(int.Parse(timeIndex_SampleAmplitude[0]));
                    SigSamples.Add(float.Parse(timeIndex_SampleAmplitude[1]));
                }
                else
                {
                    var Freq_Amp_PhaseShift = sr.ReadLine().Split();
                    SigFreq.Add(float.Parse(Freq_Amp_PhaseShift[0]));
                    SigFreqAmp.Add(float.Parse(Freq_Amp_PhaseShift[1]));
                    SigPhaseShift.Add(float.Parse(Freq_Amp_PhaseShift[2]));
                }
            }

            if (!sr.EndOfStream)
            {
                long N2 = long.Parse(sr.ReadLine());

                for (int i = 0; i < N2; i++)
                {
                    var Freq_Amp_PhaseShift = sr.ReadLine().Split();
                    SigFreq.Add(float.Parse(Freq_Amp_PhaseShift[0]));
                    SigFreqAmp.Add(float.Parse(Freq_Amp_PhaseShift[1]));
                    SigPhaseShift.Add(float.Parse(Freq_Amp_PhaseShift[2]));
                }
            }

            stream.Close();
            return new Signal(SigSamples, SigIndices, isPeriodic == 1, SigFreq, SigFreqAmp, SigPhaseShift);
        }
        public static bool SignalsSamplesAreEqual(List<float> l1, List<float> l2)
        {
            if (l1.Count != l2.Count)
                return false;

            for (int i = 0; i < l1.Count; i++)
            {
                if ((!float.IsNaN(l1[i]) && float.IsNaN(l2[i])) || (float.IsNaN(l1[i]) && !float.IsNaN(l2[i])))
                    return false;
                else if (Math.Abs(l1[i] - l2[i]) > 0.0001)
                    return false;
            }

            return true;
        }
        public static bool SignalsSamplesIndicesAreEqual(Signal l1, Signal l2)
        {
            if (l1.Samples.Count != l2.Samples.Count)
                return false;
            
            if (l1.SamplesIndices.Count != l2.SamplesIndices.Count)
                return false;

            for (int i = 0; i < l1.Samples.Count; i++)
            {
                if ((!float.IsNaN(l1.Samples[i]) && float.IsNaN(l2.Samples[i]))
                    || (float.IsNaN(l1.Samples[i]) && !float.IsNaN(l2.Samples[i])))
                    return false;
                else if (Math.Abs(l1.Samples[i] - l2.Samples[i]) > 0.002)
                    return false;
                else if (l1.SamplesIndices[i] != l2.SamplesIndices[i])
                    return false;
            }

            return true;
        }
        public static bool SignalsPhaseShiftsAreEqual(List<float> l1, List<float> l2)
        {
            if (l1.Count != l2.Count)
                return false;

            for (int i = 0; i < l1.Count; i++)
            {
                l1[i] = UnitTestUtitlities.RoundPhaseShift(l1[i]);
                l2[i] = UnitTestUtitlities.RoundPhaseShift(l2[i]);

                if ((!float.IsNaN(l1[i]) && float.IsNaN(l2[i])) || (float.IsNaN(l1[i]) && !float.IsNaN(l2[i])))
                    return false;
                else if (Math.Abs(l1[i] - l2[i]) > 0.0001)
                    return false;
            }

            return true;
        }

        private static float RoundPhaseShift(double p)
        {
            while (p < 0)
            {
                p += 2*Math.PI;
            }

            return (float) (p % (2* Math.PI));
        }
        public static List<float> LoadSamples(string filePath)
        {
            Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(stream);

            long N1 = long.Parse(sr.ReadLine());
            List<float> SigSamples = new List<float>(unchecked((int)N1));

            for (int i = 0; i < N1; i++)
            {
                var timeIndex_SampleAmplitude = sr.ReadLine();
                SigSamples.Add(float.Parse(timeIndex_SampleAmplitude));
            }

            stream.Close();
            return  SigSamples;
        }

        public static void SaveSignalTimeDomain(Signal sig, string filePath)
        {
            StreamWriter streamSaver = new StreamWriter(filePath);

            streamSaver.WriteLine(0);
            streamSaver.WriteLine(0);
            streamSaver.WriteLine(sig.Samples.Count);

            for (int i = 0; i < sig.Samples.Count; i++)
            {
                streamSaver.Write(sig.SamplesIndices[i]);
                streamSaver.WriteLine(" " + sig.Samples[i]);
            }

            streamSaver.Flush();
            streamSaver.Close();
        }
    }
}

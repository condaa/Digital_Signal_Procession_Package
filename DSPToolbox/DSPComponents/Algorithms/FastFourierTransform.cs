using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class FastFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public int InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }

        public override void Run()
        {
            OutputFreqDomainSignal = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            int N = InputTimeDomainSignal.Samples.Count;
            List<Complex> harmonics = new List<Complex>();
            harmonics = FFT(InputTimeDomainSignal.Samples);
            for (int i = 0; i < InputTimeDomainSignal.Samples.Count; i++)
            {
                OutputFreqDomainSignal.FrequenciesAmplitudes.Add((float)Math.Sqrt(Math.Pow(harmonics[i].Real, 2) + Math.Pow(harmonics[i].Imaginary, 2)));
                OutputFreqDomainSignal.FrequenciesPhaseShifts.Add((float)Math.Atan2(harmonics[i].Imaginary, harmonics[i].Real));//* (180 / Math.PI)
            }


            //throw new NotImplementedException();
        }

        private List<Complex> FFT(List<float> signal_samples)
        {
            List<Complex> harmonics = new List<Complex>();
            if (signal_samples.Count == 2)
            {
                harmonics.Add(new Complex(signal_samples[0] + signal_samples[1], 0));
                harmonics.Add(new Complex(signal_samples[0] - signal_samples[1], 0));
                return harmonics;
            }
            else
            {
                List<float> even = new List<float>();
                List<float> odd = new List<float>();
                for (int i = 0; i < signal_samples.Count; i++)
                {
                    if (i % 2 == 0)
                        even.Add(signal_samples[i]);
                    else
                        odd.Add(signal_samples[i]);
                    harmonics.Add(0);
                }
                List<Complex> even_harmonics = FFT(even);
                List<Complex> odd_harmonics = FFT(odd);

                for (int i = 0; i < even.Count; i++)
                {
                    double theta = -1 * i * 2 * Math.PI / signal_samples.Count;
                    double real = Math.Cos(theta);
                    double imag = Math.Sin(theta);
                    harmonics[i] = butterflyTop(even_harmonics[i], odd_harmonics[i], new Complex(real, imag));
                    harmonics[i+even.Count]= butterflyDown(even_harmonics[i], odd_harmonics[i], new Complex(real, imag));
                }
                return harmonics;
            }
        }
        private Complex butterflyTop(Complex a, Complex b, Complex c )
        {
            return a + b * c;
        }
        private Complex butterflyDown(Complex a, Complex b, Complex c)
        {
            return a - b * c;
        }


    }
}

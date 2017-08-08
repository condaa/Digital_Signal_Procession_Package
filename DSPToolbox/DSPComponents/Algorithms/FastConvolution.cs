using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class FastConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            OutputConvolvedSignal = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());

            int min_sample_index = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];

            //for (int i= min_sample_index;i< InputSignal1.SamplesIndices[0]; i++)
            //{
            //    InputSignal1.Samples.Insert(0, 0);
            //    InputSignal1.SamplesIndices.Insert(0, i);
            //}
            //for (int i = min_sample_index; i < InputSignal2.SamplesIndices[0]; i++)
            //{
            //    InputSignal2.Samples.Insert(0, 0);
            //    InputSignal2.SamplesIndices.Insert(0, i);
            //}

            int signal1_length_to_be = (int)Math.Pow(2, Math.Ceiling(Math.Log(InputSignal1.Samples.Count, 2)));
            int signal2_length_to_be = (int)Math.Pow(2, Math.Ceiling(Math.Log(InputSignal2.Samples.Count, 2)));
            int max_length = Math.Max(signal1_length_to_be, signal2_length_to_be);
            for (int i = InputSignal1.Samples.Count; i < max_length; i++)
                InputSignal1.Samples.Add(0);
            for (int i = InputSignal2.Samples.Count; i < max_length; i++)
                InputSignal2.Samples.Add(0);

            List<Complex> InputSignal1Complex = new List<Complex>();
            InputSignal1Complex = FFT(InputSignal1.Samples);
            List<Complex> InputSignal2Complex = new List<Complex>();
            InputSignal2Complex = FFT(InputSignal2.Samples);
            List<Complex> SignalsMultiplication = new List<Complex>();

            for (int i = 0; i < max_length; i++)
                SignalsMultiplication.Add(InputSignal1Complex[i]* InputSignal2Complex[i]);

            List<Complex> answer = new List<Complex>();
            answer = IFFT(SignalsMultiplication);

            for (int i = 0; i < max_length; i++)
            {
                OutputConvolvedSignal.Samples.Add((float)answer[i].Real / max_length);
                OutputConvolvedSignal.SamplesIndices.Add(min_sample_index++);
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
                    harmonics[i + even.Count] = butterflyDown(even_harmonics[i], odd_harmonics[i], new Complex(real, imag));
                }
                return harmonics;
            }
        }
        private List<Complex> IFFT(List<Complex> harmonics_from_amp_pha)
        {
            List<Complex> harmonics = new List<Complex>();
            if (harmonics_from_amp_pha.Count == 2)
            {
                harmonics.Add(harmonics_from_amp_pha[0] + harmonics_from_amp_pha[1]);
                harmonics.Add(harmonics_from_amp_pha[0] - harmonics_from_amp_pha[1]);
                return harmonics;
            }
            else
            {
                List<Complex> even = new List<Complex>();
                List<Complex> odd = new List<Complex>();
                for (int i = 0; i < harmonics_from_amp_pha.Count; i++)
                {
                    if (i % 2 == 0)
                        even.Add(harmonics_from_amp_pha[i]);
                    else
                        odd.Add(harmonics_from_amp_pha[i]);
                    harmonics.Add(0);
                }
                List<Complex> even_harmonics = IFFT(even);
                List<Complex> odd_harmonics = IFFT(odd);

                for (int i = 0; i < even.Count; i++)
                {
                    double sum = i * 2 * Math.PI / harmonics_from_amp_pha.Count;
                    double real = Math.Cos(sum);
                    double imag = Math.Sin(sum);
                    harmonics[i] = butterflyTop(even_harmonics[i], odd_harmonics[i], new Complex(real, imag));
                    harmonics[i + even.Count] = butterflyDown(even_harmonics[i], odd_harmonics[i], new Complex(real, imag));
                }

                return harmonics;
            }
        }

        private Complex butterflyTop(Complex a, Complex b, Complex c)
        {
            return a + b * c;
        }
        private Complex butterflyDown(Complex a, Complex b, Complex c)
        {
            return a - b * c;
        }

    }
}

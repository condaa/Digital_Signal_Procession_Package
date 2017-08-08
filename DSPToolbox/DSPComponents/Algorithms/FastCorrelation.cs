using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class FastCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }

        public override void Run()
        {
            #region initializations
            OutputNonNormalizedCorrelation = new List<float>();
            OutputNormalizedCorrelation = new List<float>();
            #endregion

            #region auto-correlation
            if (InputSignal2 == null) //auto-correlation
            {
                #region initializations
                List<float> auto_correlation = new List<float>();
                List<double> signal1_samples = new List<double>();
                List<double> signal1_samples_copy = new List<double>();
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                {
                    signal1_samples.Add(InputSignal1.Samples[i]);
                    signal1_samples_copy.Add(InputSignal1.Samples[i]);
                }

                int signal1_length_to_be = (int)Math.Pow(2, Math.Ceiling(Math.Log(signal1_samples.Count, 2)));
                int signal2_length_to_be = (int)Math.Pow(2, Math.Ceiling(Math.Log(signal1_samples_copy.Count, 2)));
                int max_length = Math.Max(signal1_length_to_be, signal2_length_to_be);

                for (int i = signal1_samples.Count; i < max_length; i++)
                    signal1_samples.Add(0);
                for (int i = signal1_samples_copy.Count; i < max_length; i++)
                    signal1_samples_copy.Add(0);

                #endregion

                #region normalization summation
                double normalization_summation = 0, signal_samples_summation = 0, signal_samples_copy_summation = 0;
                for (int i = 0; i < signal1_samples.Count; i++)
                {
                    signal_samples_summation += signal1_samples[i] * signal1_samples[i];
                    signal_samples_copy_summation += signal1_samples_copy[i] * signal1_samples_copy[i];
                }
                normalization_summation = signal_samples_summation * signal_samples_copy_summation;
                normalization_summation = Math.Sqrt(normalization_summation);
                normalization_summation /= signal1_samples.Count;
                #endregion

                #region FFT and similar
                List<Complex> InputSignal1Complex = new List<Complex>();
                InputSignal1Complex = FFT(InputSignal1.Samples);
                for (int i = 0; i < InputSignal1Complex.Count; i++)
                    InputSignal1Complex[i] = new Complex(InputSignal1Complex[i].Real, InputSignal1Complex[i].Imaginary * -1);

                List<Complex> InputSignal2Complex = new List<Complex>();
                InputSignal2Complex = FFT(InputSignal1.Samples);

                List<Complex> SignalsMultiplication = new List<Complex>();

                for (int i = 0; i < InputSignal1Complex.Count; i++)
                    SignalsMultiplication.Add(InputSignal1Complex[i] * InputSignal2Complex[i]);

                List<Complex> answer = new List<Complex>();
                answer = IFFT(SignalsMultiplication);

                for (int i = 0; i < InputSignal1Complex.Count; i++)
                    auto_correlation.Add((float)answer[i].Real / InputSignal1Complex.Count / InputSignal1Complex.Count);

                #endregion

                #region output
                OutputNonNormalizedCorrelation = auto_correlation;

                for (int i = 0; i < OutputNonNormalizedCorrelation.Count; i++)
                    OutputNormalizedCorrelation.Add((float)(OutputNonNormalizedCorrelation[i] / normalization_summation));
                #endregion
            }
            #endregion

            #region cross-correlation
            else // cross-correlation
            {
                #region initializations
                List<float> auto_correlation = new List<float>();
                List<float> signal1_samples = new List<float>();
                List<float> signal2_samples = new List<float>();
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    signal1_samples.Add(InputSignal1.Samples[i]);
                for (int i = 0; i < InputSignal2.Samples.Count; i++)
                    signal2_samples.Add(InputSignal2.Samples[i]);

                int signal1_length_to_be = (int)Math.Pow(2, Math.Ceiling(Math.Log(signal1_samples.Count, 2)));
                int signal2_length_to_be = (int)Math.Pow(2, Math.Ceiling(Math.Log(signal2_samples.Count, 2)));
                int max_length = Math.Max(signal1_length_to_be, signal2_length_to_be);

                for (int i = signal1_samples.Count; i < max_length; i++)
                    signal1_samples.Add(0);
                for (int i = signal2_samples.Count; i < max_length; i++)
                    signal2_samples.Add(0);

                #endregion

                #region normalization summation
                double normalization_summation = 0, signal1_samples_summation = 0, signal2_samples_summation = 0;
                for (int i = 0; i < signal1_samples.Count; i++)
                {
                    signal1_samples_summation += signal1_samples[i] * signal1_samples[i];
                    signal2_samples_summation += signal2_samples[i] * signal2_samples[i];
                }
                normalization_summation = signal1_samples_summation * signal2_samples_summation;
                normalization_summation = Math.Sqrt(normalization_summation);
                normalization_summation /= signal1_samples.Count;
                #endregion

                #region FFT and similar
                List<Complex> InputSignal1Complex = new List<Complex>();
                InputSignal1Complex = FFT(signal1_samples);
                for (int i = 0; i < InputSignal1Complex.Count; i++)
                    InputSignal1Complex[i] = new Complex(InputSignal1Complex[i].Real, InputSignal1Complex[i].Imaginary * -1);

                List<Complex> InputSignal2Complex = new List<Complex>();
                InputSignal2Complex = FFT(signal2_samples);

                List<Complex> SignalsMultiplication = new List<Complex>();

                for (int i = 0; i < InputSignal1Complex.Count; i++)
                    SignalsMultiplication.Add(InputSignal1Complex[i] * InputSignal2Complex[i]);

                List<Complex> answer = new List<Complex>();
                answer = IFFT(SignalsMultiplication);

                for (int i = 0; i < InputSignal1Complex.Count; i++)
                    auto_correlation.Add((float)answer[i].Real / InputSignal1Complex.Count / InputSignal1Complex.Count);

                #endregion

                #region output
                OutputNonNormalizedCorrelation = auto_correlation;

                for (int i = 0; i < OutputNonNormalizedCorrelation.Count; i++)
                    OutputNormalizedCorrelation.Add((float)(OutputNonNormalizedCorrelation[i] / normalization_summation));
                #endregion
            }
            #endregion



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
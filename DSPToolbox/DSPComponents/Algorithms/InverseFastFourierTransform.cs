using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class InverseFastFourierTransform : Algorithm
    {
        double Epsilon = .000001d;
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }

        public override void Run()
        {
            OutputTimeDomainSignal = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            int N = InputFreqDomainSignal.FrequenciesAmplitudes.Count;
            List<Complex> harmonics = new List<Complex>();

            for (int i = 0; i < InputFreqDomainSignal.FrequenciesAmplitudes.Count; i++)
                harmonics.Add(Complex.FromPolarCoordinates(InputFreqDomainSignal.FrequenciesAmplitudes[i], InputFreqDomainSignal.FrequenciesPhaseShifts[i]));

            harmonics = FFT(harmonics);

            for(int i=0;i< harmonics.Count; i++)
            {
                double sample_value = harmonics[i].Real / N;
                #region el machine 3ndy feha garpage keter t2rebn fb3ml floor aw celing lw hya el mafrod teb2a int f3ln :D
                double roundingVar = Math.Ceiling(harmonics[i].Real / N);
                if (Math.Abs(roundingVar - harmonics[i].Real / N) < Epsilon)
                    sample_value = roundingVar;
                roundingVar = Math.Floor(sample_value);
                if (Math.Abs(roundingVar - sample_value) < Epsilon)
                    sample_value = roundingVar;
                #endregion
                OutputTimeDomainSignal.Samples.Add((float)(sample_value));
                OutputTimeDomainSignal.SamplesIndices.Add(i);
            }


            
            //throw new NotImplementedException();
        }

        private List<Complex> FFT(List<Complex> harmonics_from_amp_pha)
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
                List<Complex> even_harmonics = FFT(even);
                List<Complex> odd_harmonics = FFT(odd);

                for (int i = 0; i < even.Count; i++)
                {
                    double sum = i * 2 * Math.PI / harmonics_from_amp_pha.Count;
                    double real = Math.Cos(sum);
                    double imag = Math.Sin(sum);
                    harmonics[i] = butterflyTop(even_harmonics[i], odd_harmonics[i], new Complex(real, imag));
                    harmonics[i+even.Count]= butterflyDown(even_harmonics[i], odd_harmonics[i], new Complex(real, imag));
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

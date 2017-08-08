using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;
namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }

        public override void Run()
        {
            OutputFreqDomainSignal = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            int N = InputTimeDomainSignal.Samples.Count;
            List<Complex> harmonics = new List<Complex>();

            for (int i = 0; i < N; i++)   
            {
                Complex ith_harmonic = new Complex();
                for (int j = 0; j < N; j++)
                {
                    double jth_theta = (-i * 2 * Math.PI * j) / N;
                    double jth_real = InputTimeDomainSignal.Samples[j]*Math.Cos(jth_theta);
                    double jth_imaginary = InputTimeDomainSignal.Samples[j]*Math.Sin(jth_theta); // law jth_theta neg hy7sbha lw7do asln (zy ma fe el cosine bybl3 el neg) (msh lazm a7ot condition eno lw saleb yeb2a  = -sin(-theta y3ne)  )
                    ith_harmonic += new Complex(jth_real, jth_imaginary);
                }
                harmonics.Add(ith_harmonic);
            }

            for (int i = 0; i < N; i++)
            {
                OutputFreqDomainSignal.FrequenciesAmplitudes.Add((float)Math.Sqrt(Math.Pow(harmonics[i].Real, 2) + Math.Pow(harmonics[i].Imaginary, 2)));
                OutputFreqDomainSignal.FrequenciesPhaseShifts.Add((float)Math.Atan2(harmonics[i].Imaginary, harmonics[i].Real));//* (180 / Math.PI)
            }


            //throw new NotImplementedException();
        }
    }
}

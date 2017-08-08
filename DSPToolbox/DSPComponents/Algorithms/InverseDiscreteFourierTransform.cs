using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }
        double Epsilon = .000001d;
        public override void Run()
        {
            OutputTimeDomainSignal = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            int N = InputFreqDomainSignal.FrequenciesAmplitudes.Count;
            List<Complex> harmonics = new List<Complex>();

            for (int i = 0; i < N; i++)
                harmonics.Add(Complex.FromPolarCoordinates(InputFreqDomainSignal.FrequenciesAmplitudes[i], InputFreqDomainSignal.FrequenciesPhaseShifts[i]));

            for (int i = 0; i < N; i++)
            {
                Complex ith_harmonic = new Complex();
                for (int j = 0; j < N; j++)
                {
                    double jth_theta = i * 2 * Math.PI * j / N;
                    double jth_real = Math.Cos(jth_theta);
                    double jth_imaginary = Math.Sin(jth_theta);
                    ith_harmonic += new Complex(jth_real, jth_imaginary) * harmonics[j];
                }
                ith_harmonic /= N;  
                #region el machine 3ndy feha garpage keter t2rebn fb3ml floor aw celing lw hya el mafrod teb2a int f3ln 
                double roundingVar = Math.Ceiling(ith_harmonic.Real);
                if (Math.Abs(roundingVar - ith_harmonic.Real) < Epsilon)
                    ith_harmonic = new Complex(roundingVar, ith_harmonic.Imaginary);
                roundingVar = Math.Floor(ith_harmonic.Real);
                if (Math.Abs(roundingVar - ith_harmonic.Real) < Epsilon)
                    ith_harmonic = new Complex(roundingVar, ith_harmonic.Imaginary);
                #endregion
                OutputTimeDomainSignal.Samples.Add((float)ith_harmonic.Real);
            }



            //throw new NotImplementedException();
        }
    }
}

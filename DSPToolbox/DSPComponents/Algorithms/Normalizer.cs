using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {

            float max_sample = float.MinValue;
            float min_sample = float.MaxValue;
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                if (InputSignal.Samples[i] > max_sample)
                    max_sample = InputSignal.Samples[i];
                if (InputSignal.Samples[i] < min_sample)
                    min_sample = InputSignal.Samples[i];
            }

            for (int i = 0; i < InputSignal.Samples.Count; i++)
                InputSignal.Samples[i] = InputMinRange + ((InputSignal.Samples[i] - min_sample) * (InputMaxRange - InputMinRange) / (max_sample - min_sample));
            OutputNormalizedSignal = InputSignal;

            //throw new NotImplementedException();
        }
    }
}

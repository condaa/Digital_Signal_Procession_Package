using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class MovingAverage : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int InputWindowSize { get; set; }
        public Signal OutputAverageSignal { get; set; }

        public override void Run()
        {
            OutputAverageSignal = new Signal(new List<float>(), new List<int>(), false);
            //OutputAverageSignal = InputSignal;
            //OutputAverageSignal.Samples.Clear();
            //OutputAverageSignal.SamplesIndices.Clear();
            // 1001 3 999
            for (int i = 0; i < InputSignal.Samples.Count - InputWindowSize + 1; i++)
            {
                float samples_sum = 0;
                for (int j = i; j < i + InputWindowSize; j++)
                    samples_sum += InputSignal.Samples[j];
                samples_sum /= (float)InputWindowSize;
                OutputAverageSignal.Samples.Add(samples_sum);
                OutputAverageSignal.SamplesIndices.Add(i);
            }

            //throw new NotImplementedException();
        }
    }
}

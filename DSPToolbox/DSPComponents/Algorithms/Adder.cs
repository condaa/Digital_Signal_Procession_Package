using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Adder : Algorithm
    {
        public List<Signal> InputSignals { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            OutputSignal = InputSignals[0];

            for (int i = 1; i < InputSignals.Count; i++) 
            {
                for (int j = 0; j < InputSignals[i].Samples.Count; j++)
                {
                    // if sample index does not exist append it and its value, else add new amp to it
                    int sample_index = -1;

                    for(int k = 0; k < OutputSignal.SamplesIndices.Count; k++)
                        // is output signal(first signal) has this sample index?
                        if(OutputSignal.SamplesIndices[k]== InputSignals[i].SamplesIndices[j])
                        {
                            sample_index = k;
                            break;
                        }

                    if (sample_index != -1) 
                        OutputSignal.Samples[sample_index] += InputSignals[i].Samples[j];
                    else
                    {
                        OutputSignal.SamplesIndices.Add(InputSignals[i].SamplesIndices[j]);
                        OutputSignal.Samples.Add(InputSignals[i].Samples[j]);
                    }

                }
            }

            //throw new NotImplementedException();
        }
    }
}

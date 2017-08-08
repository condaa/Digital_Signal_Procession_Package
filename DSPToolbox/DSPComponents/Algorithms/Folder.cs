using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            //OutputFoldedSignal = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());

            //for (int i = 0; i < InputSignal.SamplesIndices.Count; i++)
            //{
            //    OutputFoldedSignal.Samples.Add(InputSignal.Samples[i]);
            //    OutputFoldedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i]);
            //}

            OutputFoldedSignal = InputSignal;
            for (int i = 0; i < InputSignal.SamplesIndices.Count / 2; i++)
            {
                float tmp = OutputFoldedSignal.Samples[OutputFoldedSignal.Samples.Count - i - 1];
                OutputFoldedSignal.Samples[OutputFoldedSignal.Samples.Count - i - 1] = OutputFoldedSignal.Samples[i];
                OutputFoldedSignal.Samples[i] = tmp;
            }

                //throw new NotImplementedException();
            }
        }
}

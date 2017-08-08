using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
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

            int output_length = InputSignal1.Samples.Count + InputSignal2.Samples.Count - 2;
            int min_sample_index = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];

            float signal_1_k_th_element, signal_2_n_minus_k_th_element, output_element;

            for (int n = 0; n <= output_length; n++)
            {
                output_element = 0;
                for (int k = 0; k <= n; k++)
                {
                    if (k < InputSignal1.Samples.Count)
                        signal_1_k_th_element = InputSignal1.Samples[k];
                    else
                    {
                        signal_1_k_th_element = 0; // no more coefficients, so break
                        break;
                    }
                    if (n - k < InputSignal2.Samples.Count)
                        signal_2_n_minus_k_th_element = InputSignal2.Samples[n - k];
                    else
                        signal_2_n_minus_k_th_element = 0;
                    output_element += signal_1_k_th_element * signal_2_n_minus_k_th_element;
                }
                OutputConvolvedSignal.Samples.Add(output_element);
                OutputConvolvedSignal.SamplesIndices.Add(min_sample_index++);
            }

            while (OutputConvolvedSignal.Samples[OutputConvolvedSignal.Samples.Count - 1] == 0)
            {
                OutputConvolvedSignal.Samples.RemoveAt(OutputConvolvedSignal.Samples.Count - 1);
                OutputConvolvedSignal.SamplesIndices.RemoveAt(OutputConvolvedSignal.SamplesIndices.Count - 1);
            }

            while (OutputConvolvedSignal.Samples[0] == 0)
            {
                OutputConvolvedSignal.Samples.RemoveAt(0);
                OutputConvolvedSignal.SamplesIndices.RemoveAt(0);
            }






            //throw new NotImplementedException();
        }
    }
}

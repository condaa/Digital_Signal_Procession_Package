using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public struct range_borders
    {
       public double start, end;
    }
    public class QuantizationAndEncoding : Algorithm
    {
        // You will have only one of (InputLevel or InputNumBits), the other property will take a negative value
        // If InputNumBits is given, you need to calculate and set InputLevel value and vice versa
        public int InputLevel { get; set; }
        public int InputNumBits { get; set; }
        public Signal InputSignal { get; set; }
        public Signal OutputQuantizedSignal { get; set; }
        public List<int> OutputIntervalIndices { get; set; }
        public List<string> OutputEncodedSignal { get; set; }
        public List<float> OutputSamplesError { get; set; }
        float Eps = (float)0.0001;
        public override void Run()
        {
            #region get max and min amplitude
            double max_amp = double.MinValue;
            double min_amp = double.MaxValue;
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                if (InputSignal.Samples[i] > max_amp)
                    max_amp = InputSignal.Samples[i];
                if (InputSignal.Samples[i] < min_amp)
                    min_amp = InputSignal.Samples[i];
            }
            #endregion
            #region get num of levels and num of bits and level range(delta)
            if (InputNumBits < 1)
                InputNumBits = (int)Math.Ceiling(Math.Log(InputLevel, 2)); // ceiling 3shan lw el raqm msh 2^n fa myrmesh b2et el levels
            else                                                          //  lw 5 msln yeb2a 3 bits l2n 2 bits hyshel le7d 4 bs
                InputLevel = (int)Math.Pow(2, InputNumBits);

            double delta = (max_amp - min_amp) / InputLevel;
            #endregion
            #region get levels borders
            List<range_borders> levels_start_and_end = new List<range_borders>();
            range_borders level = new range_borders();
            level.start= min_amp;
            level.end=min_amp + delta;
            levels_start_and_end.Add(level);
            for (int i = 1; i < InputLevel; i++)
            {
                level.start = levels_start_and_end[i - 1].end;
                level.end = levels_start_and_end[i - 1].end + delta;
                levels_start_and_end.Add(level);
            }
            #endregion
            #region get levels midpoints
            List<double> levels_midpoints = new List<double>();
            for (int i = 0; i < InputLevel; i++)
                levels_midpoints.Add((levels_start_and_end[i].start+ levels_start_and_end[i].end)/2);
            #endregion
            #region get output interval indices
            // kol sample byo23 fe anhy level (1 based)
            OutputIntervalIndices = new List<int>();
            for(int i = 0; i < InputSignal.Samples.Count; i++)
            {
                for(int j=0;j< levels_start_and_end.Count; j++)
                {
                    if((InputSignal.Samples[i]  >= levels_start_and_end[j].start|| Math.Abs(InputSignal.Samples[i] - levels_start_and_end[j].end) < Eps) && (InputSignal.Samples[i]<= levels_start_and_end[j].end||Math.Abs(InputSignal.Samples[i]- levels_start_and_end[j].end)<Eps ))
                    {
                        OutputIntervalIndices.Add(j+1);
                        break;
                    }
                }
            }
            #endregion
            #region get quantized signal
            // a heya el qema el gdeda le kol sample(el mid point bta3t el level bta3o)
            OutputQuantizedSignal = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            for (int i = 0; i < OutputIntervalIndices.Count; i++)
            {
                OutputQuantizedSignal.Samples.Add((float)levels_midpoints[OutputIntervalIndices[i]-1]);
                OutputQuantizedSignal.SamplesIndices.Add(i);
            }
            #endregion
            #region calculate el error
            OutputSamplesError = new List<float>();
            for (int i = 0; i < OutputIntervalIndices.Count; i++)
                OutputSamplesError.Add(OutputQuantizedSignal.Samples[i] - InputSignal.Samples[i]);
            #endregion
            #region get the encoding for the signal
            OutputEncodedSignal = new List<string>();
            for (int i = 0; i < OutputIntervalIndices.Count; i++)
            {
                OutputEncodedSignal.Add(Convert.ToString(OutputIntervalIndices[i]-1, 2));
                while(OutputEncodedSignal[i].Length < InputNumBits)
                    OutputEncodedSignal[i]=OutputEncodedSignal[i].Insert(0, "0");
            }
            #endregion
            //throw new NotImplementedException();
        }
    }
}

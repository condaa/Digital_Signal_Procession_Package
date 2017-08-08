using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.DataStructures
{
    public class Signal
    {
        public List<float> Samples { get; set; }
        public List<int> SamplesIndices { get; set; }

        //Added
        public List<float> Frequencies { get; set; }

        public List<float> FrequenciesAmplitudes { get; set; }
        public List<float> FrequenciesPhaseShifts { get; set; }
        public bool Periodic { get; set; }


        public Signal(List<float> _SignalSamples, bool _periodic)
        {
            Samples = _SignalSamples;
            Periodic = _periodic;
            SamplesIndices = new List<int>(_SignalSamples.Count);

            for (int i = 0; i < _SignalSamples.Count; i++)
                SamplesIndices.Add(i);
        }
        public Signal(List<float> _SignalSamples, List<int> _SignalIndixes, bool _periodic)
        {
            Samples = _SignalSamples;
            Periodic = _periodic;
            SamplesIndices = _SignalIndixes;
        }
        public Signal(bool _periodic, List<float> _SignalFrquencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts)
        {
            Periodic = _periodic;
            Frequencies = _SignalFrquencies;
            FrequenciesAmplitudes = _SignalFrequenciesAmplitudes;
            FrequenciesPhaseShifts = _SignalFrequenciesPhaseShifts;
        }
        public Signal(List<float> _SignalSamples, bool _periodic, List<float> _SignalFrequencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts)
        {
            Periodic = _periodic;
            Samples = _SignalSamples;
            SamplesIndices = new List<int>(_SignalSamples.Count);

            for (int i = 0; i < _SignalSamples.Count; i++)
                SamplesIndices.Add(i);

            Frequencies = _SignalFrequencies;
            FrequenciesAmplitudes = _SignalFrequenciesAmplitudes;
            FrequenciesPhaseShifts = _SignalFrequenciesPhaseShifts;
        }
        public Signal(List<float> _SignalSamples, List<int> _SignalIndixes, bool _periodic, List<float> _SignalFrequencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts)
        {
            Samples = _SignalSamples;
            Periodic = _periodic;
            SamplesIndices = _SignalIndixes;
            Frequencies = _SignalFrequencies;
            FrequenciesAmplitudes = _SignalFrequenciesAmplitudes;
            FrequenciesPhaseShifts = _SignalFrequenciesPhaseShifts;
        }
    }
}

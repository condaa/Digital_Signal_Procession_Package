using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using DSPUI.Utilities;

namespace DSPUI.Components
{
    public class FIRAttributes : ComponentAttributes
    {
        public Signal Yn { get; set; }
        public FILTER_TYPES? FilterType { get; set; }
        public float? SamplingFrequency { get; set; }
        public float? CutOffFrequency { get; set; }
        public float? F1 { get; set; }
        public float? F2 { get; set; }
        public float? StopBandAttenuation { get; set; }
        public float? TransitionBand { get; set; }
        //public Signal Hn { get; set; }
    }

    public class FIR : Component
    {
        public DSPAlgorithms.Algorithms.FIR mySolver { get; set; }
        private FIRAttributes myData { get { return (FIRAttributes)Data; } set { Data = value; } }

        public FIR()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.FIR();
            this.Data = new FIRAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return InputComponents.Count == 0
              && ComponentUtility.ComponentAttributesHasSignal(c);
        }

        public override bool ComponentReady()
        {
            ErrorMessage = "";

            if (InputComponents.Count != 1)
            {
                ErrorMessage = "Need 1 Input Connection.";
                return false;
            }
            else if (!myData.SamplingFrequency.HasValue)
            {
                ErrorMessage = "Kindly insert a value for FS by doubling click this component.";
                return false;
            }
            else if (!myData.FilterType.HasValue)
            {
                ErrorMessage = "Kindly chose the filter type by doubling click this component.";
                return false;
            }
            else if (!myData.CutOffFrequency.HasValue && (!myData.F1.HasValue || !myData.F2.HasValue))
            {
                ErrorMessage = "Kindly insert a value for the Cut off frequency(ies) by doubling click this component.";
                return false;
            }
            else if (!myData.StopBandAttenuation.HasValue)
            {
                ErrorMessage = "Kindly insert a value for Stop Band Attenuation by doubling click this component.";
                return false;
            }
            else if (!myData.TransitionBand.HasValue)
            {
                ErrorMessage = "Kindly insert a value for the Transition Band by doubling click this component.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputTimeDomainSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputFilterType = myData.FilterType.Value;
            mySolver.InputFS = myData.SamplingFrequency.Value;

            if (myData.CutOffFrequency.HasValue)
                mySolver.InputCutOffFrequency = myData.CutOffFrequency.Value;
            else
            {
                mySolver.InputF1 = myData.F1.Value;
                mySolver.InputF2 = myData.F2.Value;
            }

            mySolver.InputStopBandAttenuation = myData.StopBandAttenuation.Value;
            mySolver.InputTransitionBand = myData.TransitionBand.Value;
            
            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            //myData.Hn = mySolver.OutputHn;
            myData.Yn = mySolver.OutputYn;

            NotifyAllComponentOutputReady();
        }
        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.FIR(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "FIR";
        }
    }
}

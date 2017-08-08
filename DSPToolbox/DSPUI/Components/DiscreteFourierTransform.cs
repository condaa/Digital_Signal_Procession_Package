namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class DiscreteFourierTransformAttributes : ComponentAttributes
    {
        public Signal FreqDomainSignal { get; set; }
        public float? SamplingFrequency { get; set; }
    }

    public class DiscreteFourierTransform : Component
    {
        public DSPAlgorithms.Algorithms.DiscreteFourierTransform mySolver { get; set; }
        private DiscreteFourierTransformAttributes myData { get { return (DiscreteFourierTransformAttributes)Data; } set { Data = value; } }

        public DiscreteFourierTransform()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.DiscreteFourierTransform();
            this.Data = new DiscreteFourierTransformAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return InputComponents.Count == 0 && ComponentUtility.ComponentAttributesHasSignal(c);
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

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputTimeDomainSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputSamplingFrequency = myData.SamplingFrequency.Value;

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.FreqDomainSignal = mySolver.OutputFreqDomainSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.DiscreteFourierTransform(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "DFT";
        }
    }
}

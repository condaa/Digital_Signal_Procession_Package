namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class InverseFastFourierTransformAttributes : ComponentAttributes
    {
        public Signal TimeDomainSignal { get; set; }
    }

    public class InverseFastFourierTransform : Component
    {
        public DSPAlgorithms.Algorithms.InverseFastFourierTransform mySolver { get; set; }
        private InverseFastFourierTransformAttributes myData { get { return (InverseFastFourierTransformAttributes)Data; } set { Data = value; } }

        public InverseFastFourierTransform()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.InverseFastFourierTransform();
            this.Data = new InverseFastFourierTransformAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return InputComponents.Count == 0 && Utilities.ComponentUtility.ComponentAttributesHasSignal(c);
        }

        public override bool ComponentReady()
        {
            ErrorMessage = "";

            if (InputComponents.Count != 1)
            {
                ErrorMessage = "Need 1 Input Connection.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputFreqDomainSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.TimeDomainSignal = mySolver.OutputTimeDomainSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
        }

        public override string ToString()
        {
            return "IFFT";
        }
    }
}

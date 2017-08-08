namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class ConvolutionAttributes : ComponentAttributes
    {
        public Signal ConvolvedSignal { get; set; }
    }

    public class Convolution : Component
    {
        public DSPAlgorithms.Algorithms.DirectConvolution mySolver { get; set; }
        private ConvolutionAttributes myData { get { return (ConvolutionAttributes)Data; } set { Data = value; } }

        public Convolution() 
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.DirectConvolution();
            this.Data = new ConvolutionAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return Utilities.ComponentUtility.ComponentAttributesHasSignal(c) && InputComponents.Count < 2;
        }

        public override bool ComponentReady()
        {
            ErrorMessage = "";

            if (InputComponents.Count != 2)
            {
                ErrorMessage = "Need 2 Input Connections";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputSignal1 = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputSignal2 = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[1].Data);

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.ConvolvedSignal = mySolver.OutputConvolvedSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
        }

        public override string ToString()
        {
            return "Conv";
        }
    }
}

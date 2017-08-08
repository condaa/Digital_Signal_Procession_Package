namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class CorrelationAttributes : ComponentAttributes
    {
        public Signal Correlation { get; set; }
    }

    public class Correlation : Component
    {
        public DSPAlgorithms.Algorithms.DirectCorrelation  mySolver { get; set; }
        private CorrelationAttributes myData { get { return (CorrelationAttributes)Data; } set { Data = value; } }

        public Correlation()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.DirectCorrelation();
            this.Data = new CorrelationAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return InputComponents.Count < 2 && ComponentUtility.ComponentAttributesHasSignal(c);
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
            myData.Correlation = new Signal(mySolver.OutputNormalizedCorrelation, mySolver.InputSignal2.Periodic);

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
        }

        public override string ToString()
        {
            return "Corr";
        }
    }
}

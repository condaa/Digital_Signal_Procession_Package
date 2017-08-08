namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using DSPAlgorithms.Algorithms;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class SubtractorAttributes : ComponentAttributes
    {
        public Signal SubtractedSignal { get; set; }
    }
    public class Subtractor : Component
    {
        public DSPAlgorithms.Algorithms.Subtractor mySolver { get; set; }
        private SubtractorAttributes myData { get { return (SubtractorAttributes)Data; } set { Data = value; } }

        public Subtractor()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.Subtractor();
            this.Data = new SubtractorAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return InputComponents.Count < 2 && Utilities.ComponentUtility.ComponentAttributesHasSignal(c);
        }

        public override bool ComponentReady()
        {
            ErrorMessage = "";

            if (InputComponents.Count != 2)
            {
                ErrorMessage = "Need 2 Input Connections.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputSignal1= ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputSignal2 = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[1].Data);

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.SubtractedSignal = mySolver.OutputSignal;
       
            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
        }

        public override string ToString()
        {
            return "Subtract";
        }
    }
}

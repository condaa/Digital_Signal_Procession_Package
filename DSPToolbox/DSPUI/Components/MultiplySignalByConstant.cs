namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using DSPAlgorithms.Algorithms;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class MultiplySignalByConstantAttributes : ComponentAttributes
    {
        public Signal MultipliedSignal { get; set; }
        public float? ConstantValue { get; set; }
    }

    public class MultiplySignalByConstant : Component
    {
        public DSPAlgorithms.Algorithms.MultiplySignalByConstant mySolver { get; set; }
        private MultiplySignalByConstantAttributes myData { get { return (MultiplySignalByConstantAttributes)Data; } set { Data = value; } }

        public MultiplySignalByConstant()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.MultiplySignalByConstant();
            this.Data = new MultiplySignalByConstantAttributes();
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
            else if (myData.ConstantValue == null)
            {
                ErrorMessage = "Kindly insert a value for the constant by doubling click this component.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputConstant = myData.ConstantValue.Value;

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.MultipliedSignal = mySolver.OutputMultipliedSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.MultiplySignalByConstant(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "Mult by Cons";
        }
    }
}

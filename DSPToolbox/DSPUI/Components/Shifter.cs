namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class ShifterAttributes : ComponentAttributes
    {
        public int? ShiftingValue { get; set; }
        public Signal ShiftedSignal { get; set; }
    }

    public class Shifter : Component
    {
        public DSPAlgorithms.Algorithms.Shifter mySolver { get; set; }
        private ShifterAttributes myData { get { return (ShifterAttributes)Data; } set { Data = value; } }

        public Shifter()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.Shifter();
            this.Data = new ShifterAttributes();
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
            else if (myData.ShiftingValue == null)
            {
                ErrorMessage = "Kindly insert the Shifting Value by doubling click this component.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.ShiftingValue = myData.ShiftingValue.Value;

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.ShiftedSignal = mySolver.OutputShiftedSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.Shifter(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "Shifter";
        }
    }
}

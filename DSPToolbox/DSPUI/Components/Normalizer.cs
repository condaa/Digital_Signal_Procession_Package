namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class NormalizerAttributes : ComponentAttributes
    {
        public float? MinValue { get; set; }
        public float? MaxValue { get; set; }
        public Signal NormalizedSignal { get; set; }
    }

    public class Normalizer : Component
    {
        public DSPAlgorithms.Algorithms.Normalizer mySolver { get; set; }
        private NormalizerAttributes myData { get { return (NormalizerAttributes)Data; } set { Data = value; } }

        public Normalizer()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.Normalizer();
            this.Data = new NormalizerAttributes();
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
            else if (myData.MinValue == null || myData.MaxValue == null)
            {
                ErrorMessage = "Kindly insert the Min/Max Values by doubling click this component.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputMinRange = myData.MinValue.Value;
            mySolver.InputMaxRange = myData.MaxValue.Value;

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.NormalizedSignal = mySolver.OutputNormalizedSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.Normalizer(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "Normalizer";
        }
    }
}

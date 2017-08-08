using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using DSPUI.Utilities;

namespace DSPUI.Components
{
    public class QuantizationEncodingAttributes : ComponentAttributes
    {
        public Signal QuantizedSignal { get; set; }
        public int? Level { get; set; }
        public int? NumBits { get; set; }
    }

    public class QuantizationAndEncoding : Component
    {
        public DSPAlgorithms.Algorithms.QuantizationAndEncoding mySolver { get; set; }
        private QuantizationEncodingAttributes myData { get { return (QuantizationEncodingAttributes)Data; } set { Data = value; } }

        public QuantizationAndEncoding() 
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.QuantizationAndEncoding();
            this.Data = new QuantizationEncodingAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return Utilities.ComponentUtility.ComponentAttributesHasSignal(c) && InputComponents.Count == 0;
        }

        public override bool ComponentReady()
        {
            ErrorMessage = "";
            
            if (InputComponents.Count != 1)
            {
                ErrorMessage = "Need 1 Input Connection.";
                return false;
            }
            else if (myData.Level == null || myData.NumBits == null)
            {
                ErrorMessage = "Kindly insert the Level/NumBits Values by doubling click this component.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputLevel = myData.Level.Value;
            mySolver.InputNumBits = myData.NumBits.Value;

            mySolver.Run();

            myData.QuantizedSignal = mySolver.OutputQuantizedSignal;
            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.QuantizationAndEncoding(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "Quan&Enc";
        }
    }
}

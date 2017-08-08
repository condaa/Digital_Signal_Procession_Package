namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class MovingAverageAttributes : ComponentAttributes
    {
        public Signal AveragedSignal { get; set; }
        public int? WindowSize{ get; set; }
    }

    public class MovingAverage : Component
    {
         public DSPAlgorithms.Algorithms.MovingAverage mySolver { get; set; }
         private MovingAverageAttributes myData { get { return (MovingAverageAttributes)Data; } set { Data = value; } }

        public MovingAverage()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.MovingAverage();
            this.Data = new MovingAverageAttributes();
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
            else if (myData.WindowSize == null)
            {
                ErrorMessage = "Kindly insert a value for the Window Size by doubling click this component.";
                return false;
            }

            return true;
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            mySolver.InputSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);
            mySolver.InputWindowSize = myData.WindowSize.Value;

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.AveragedSignal = mySolver.OutputAverageSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.MovingAverage(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "Moving Avg";
        }
    }
}

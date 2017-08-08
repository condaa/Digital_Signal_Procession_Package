using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using DSPUI.Utilities;

namespace DSPUI.Components
{
    public class Plotter : Component
    {
        public Plotter() 
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return ComponentUtility.ComponentAttributesHasSignal(c);
        }

        public override void StartJob()
        {
            var AlgoInputList = new List<Signal>();

            foreach (var inpComponent in InputComponents)
            {
                AlgoInputList.Add(ComponentUtility.GetSignalFromComponentAttributes(inpComponent.Data));
            }
            
            GraphPlotter.PlotGraph(AlgoInputList);
        }

        public override void ShowComponentsAttributesDialogue()
        {
            StartJob();
        }

        public override bool AcceptsOutput()
        {
            return false;
        }
        
        public override bool ComponentReady()
        {
            return true;
        }

        public override string ToString()
        {
            return "Plotter";
        }
    }
}

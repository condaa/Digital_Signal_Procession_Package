using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using DSPUI.Utilities;

namespace DSPUI.Components
{
    public class FolderAttributes : ComponentAttributes
    {
        public Signal FoldedSignal { get; set; }
    }

    public class Folder : Component
    {
        
        public DSPAlgorithms.Algorithms.Folder mySolver { get; set; }
        private FolderAttributes myData { get { return (FolderAttributes)Data; } set { Data = value; } }

        public Folder()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.Folder();
            this.Data = new FolderAttributes();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return InputComponents.Count == 0 && ComponentUtility.ComponentAttributesHasSignal(c);
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
            mySolver.InputSignal = ComponentUtility.GetSignalFromComponentAttributes(InputComponents[0].Data);

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            myData.FoldedSignal = mySolver.OutputFoldedSignal;

            NotifyAllComponentOutputReady();
        }

        public override void ShowComponentsAttributesDialogue()
        {
        }

        public override string ToString()
        {
            return "Folder";
        }
    }
}

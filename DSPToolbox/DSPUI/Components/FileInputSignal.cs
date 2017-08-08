namespace DSPUI.Components
{
    using System.Collections.Generic;
    using System.IO;
    using DSPAlgorithms.DataStructures;

    public class FileSignalAttributes : ComponentAttributes
    {
        public Signal Signal { get; set; }
        public string FilePath = null;
    }

    public class FileInputSignal : Component
    {
        private FileSignalAttributes myData { get { return (FileSignalAttributes)Data; } set { Data = value; } }

        public FileInputSignal()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            this.Data = myData = new FileSignalAttributes();
        }

        public FileInputSignal(string path, string name)
        {
            this.Name = name;
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            this.Data = myData = new FileSignalAttributes() { FilePath = path};
        }

        public override void StartJob()
        {
            NotifyAllComponentOutputReady();
        }

        public override bool IsValidInputComponent(Component c)
        {
            return false;
        }

        public override bool ComponentReady()
        {
            ErrorMessage = "";

            if (myData.FilePath == null)
            {
                ErrorMessage = "Kindly insert the file path by doubling click this component.";
                return false;
            }

            return true;
        }

        public override bool AcceptsInput()
        {
            return false;
        }

        public override void ShowComponentsAttributesDialogue()
        {
            var ui = new ComponentsAttriutesEditor.FileInputSignal(myData);
            ui.ShowDialog();
        }

        public override string ToString()
        {
            return "Load Signal";
        }
    }
}
namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using DSPAlgorithms.Algorithms;
    using DSPAlgorithms.DataStructures;
    using DSPUI.Utilities;

    public class AdderAttributes: ComponentAttributes
    {
        public Signal SignalSamples { get; set; }
    }

    public class Adder : Component
    {
        private DSPAlgorithms.Algorithms.Adder mySolver;

        public Adder()
        {
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.Adder();
            this.Data = new AdderAttributes();
        }

        public Adder(string name)
        {
            this.Name = name;
            this.InputComponents = new List<Component>();
            this.OutputComponents = new List<Component>();
            mySolver = new DSPAlgorithms.Algorithms.Adder();
            this.Data = new AdderAttributes();
        }

        public override void StartJob()
        {
            // Construct Input for the algorithm 
            var AlgoInputList = new List<Signal>();

            foreach (var inpComponent in InputComponents)
            {
                AlgoInputList.Add(ComponentUtility.GetSignalFromComponentAttributes(inpComponent.Data));
            }
            
            mySolver.InputSignals = AlgoInputList;

            // Run algorithm
            mySolver.Run();

            // Construct Component Data from algorithm Output
            var da = new AdderAttributes();
            da.SignalSamples = mySolver.OutputSignal;
            Data = da;

            NotifyAllComponentOutputReady();
        }

        /// <summary>
        /// Validates that the input Component can be a valid input based on the component attributes. Component Attributes shall contain one signal  
        /// </summary>
        /// <param name="c">Component to be connected to as an input</param>
        /// <returns></returns>
        public override bool IsValidInputComponent(Component c)
        {
            return ComponentUtility.ComponentAttributesHasSignal(c);
        }

        public override bool ComponentReady()
        {
            ErrorMessage = "";

            if (InputComponents.Count == 0)
            {
                ErrorMessage = "No Input Connections";
                return false;
            }

            return true;
        }

        public override void ShowComponentsAttributesDialogue()
        {
        }

        public override string ToString()
        {
            return "Adder";
        }
    }
}
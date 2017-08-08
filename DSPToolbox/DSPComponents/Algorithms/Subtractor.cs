using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Subtractor : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputSignal { get; set; }

        /// <summary>
        /// To do: Subtract Signal2 from Signal1 
        /// i.e OutSig = Sig1 - Sig2 
        /// </summary>
        public override void Run()
        {
            
            MultiplySignalByConstant Signal_To_Be_Multiplied = new MultiplySignalByConstant();
            Signal_To_Be_Multiplied.InputSignal = InputSignal2;
            Signal_To_Be_Multiplied.InputConstant = -1;
            Signal_To_Be_Multiplied.Run();

            List<Signal> Input_Signal_To_Adder = new List<Signal>();
            Input_Signal_To_Adder.Add(InputSignal1);
            Input_Signal_To_Adder.Add(Signal_To_Be_Multiplied.OutputMultipliedSignal);

            Adder Signals_To_Be_Added = new Adder();
            Signals_To_Be_Added.InputSignals = Input_Signal_To_Adder;
            Signals_To_Be_Added.Run();

            OutputSignal = Signals_To_Be_Added.OutputSignal;

            //throw new NotImplementedException();
        }
    }
}
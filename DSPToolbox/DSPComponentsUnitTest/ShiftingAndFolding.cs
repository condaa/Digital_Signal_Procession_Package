using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.DataStructures;
using DSPAlgorithms.Algorithms;

namespace DSPComponentsUnitTest
{
    /// <summary>
    /// Summary description for ShiftingAndFolding
    /// </summary>
    [TestClass]
    public class ShiftingAndFolding
    {
        Signal inputSignal, expectedOutputSignal, actualOutputSignal;

        Shifter s = new Shifter();
        Folder f = new Folder();

        [TestInitialize]
        public void ShiftingAndFoldingInitializer()
        {
            inputSignal = UnitTestUtitlities.LoadSignal("TestingSignals/Input_ShiftFold.ds");
        }

        [TestCleanup]
        public void ShiftingAndFoldingValidation()
        {
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesIndicesAreEqual(expectedOutputSignal, actualOutputSignal));
        }

        [TestMethod]
        public void ShiftLeftTestMethod1()
        {
            s.InputSignal = inputSignal;
            s.ShiftingValue = 500;
            expectedOutputSignal = UnitTestUtitlities.LoadSignal("TestingSignals/Output_Shift_Plus500.ds");
            s.Run();
            actualOutputSignal = s.OutputShiftedSignal;
        }

        [TestMethod]
        public void ShiftingRightTestMethod2()
        {
            s.InputSignal = inputSignal;
            s.ShiftingValue = -500;
            expectedOutputSignal = UnitTestUtitlities.LoadSignal("TestingSignals/Output_Shift_Minus500.ds");
            s.Run();
            actualOutputSignal = s.OutputShiftedSignal;
        }
       
        [TestMethod]
        public void FoldingTestMethod3()
        {
            f.InputSignal = inputSignal;
            expectedOutputSignal = UnitTestUtitlities.LoadSignal("TestingSignals/Output_Fold.ds");
            f.Run();
            actualOutputSignal = f.OutputFoldedSignal;
        }

        [TestMethod]
        public void FoldingAndShiftRightTestMethod4()
        {
            s.ShiftingValue = 500;
            expectedOutputSignal = UnitTestUtitlities.LoadSignal("TestingSignals/Output_Fold_Plus500.ds");
            f.InputSignal = inputSignal;
            f.Run();
            s.InputSignal = f.OutputFoldedSignal;
            s.Run();
            actualOutputSignal = f.OutputFoldedSignal;
        }

        [TestMethod]
        public void FoldingAndShiftLeftTestMethod5()
        {
            s.ShiftingValue = -500;
            expectedOutputSignal = UnitTestUtitlities.LoadSignal("TestingSignals/Output_Fold_Minus500.ds");
            f.InputSignal = inputSignal;
            f.Run();
            s.InputSignal = f.OutputFoldedSignal;
            s.Run();
            actualOutputSignal = s.OutputShiftedSignal;
        }

    }
}

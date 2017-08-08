using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSPAlgorithms.Algorithms;
using DSPAlgorithms.DataStructures;

namespace DSPComponentsUnitTest
{
    /// <summary>
    /// Summary description for CorrelationTestCases
    /// </summary>
    [TestClass]
    public class CorrelationTestCases
    {
        #region auto direct correlation
        [TestMethod]
        public void AutoDirectNonNormalizedNonPeriodicCorrelationTestMethod1()
        {
            DirectCorrelation dc = new DirectCorrelation();
            
            var expectedOutput = new Signal(new List<float>() {
                                           #region expectedOutput
0.145421785526316f,
0.138042811315789f,
0.116859722763158f,
0.084224233421053f,
0.043787748552632f,
0.000012503421053f,
-0.042372349868421f,
-0.078934778684211f,
-0.106057218026316f,
-0.121306617631579f,
-0.123700744473684f,
-0.113731415526316f,
-0.093230693157895f,
-0.065077018026316f,
-0.032791058815789f,
-0.000081059605263f,
0.029601792631579f,
0.053442207368421f,
0.069530525921053f,
0.076999285657895f,
0.076019766710526f,
0.067674143815789f,
0.053729758684211f,
0.036355934736842f,
0.017824319210526f,
0.000233551710526f,
-0.014711043815789f,
-0.025840895263158f,
-0.032583095921053f,
-0.034938634210526f,
-0.033394412368421f,
-0.028789378552632f,
-0.022158962500000f,
-0.014580769210526f,
-0.007041455789474f,
-0.000337463815789f,
0.004983341710526f,
0.008638095657895f,
0.010590359210526f,
0.011004474605263f,
0.010183886184211f,
0.008505514342105f,
0.006358184736842f,
0.004093438815789f,
0.001991600000000f,
0.000244809210526f,
-0.001045239736842f,
-0.001856842368421f,
-0.002230833815789f,
-0.002249111052632f,
-0.002013452236842f,
-0.001627179473684f,
-0.001181853815789f,
-0.000748792105263f,
-0.000375964473684f,
-0.000088670131579f,
0.000106684868421f,
0.000217783026316f,
0.000260585131579f,
0.000254524342105f,
0.000218744605263f,
0.000169398552632f,
0.000118649473684f,
0.000074126184211f,
0.000039611710526f,
0.000015828026316f,
0.000001548421053f,
-0.000005348421053f,
-0.000006818947368f,
-0.000011735263158f,
-0.000008277368421f,
-0.000004515921053f,
-0.000001522894737f,
0.000000287894737f,
0.000000952894737f,
0.000000759473684f
#endregion
                                                 }, false);

            
            dc.InputSignal1 = new Signal(new List<float>() {
                    #region input
                     0.0078f,
                     0.0042f,
                    -0.0010f,
                    -0.0089f,
                    -0.0195f,
                    -0.0321f,
                    -0.0453f,
                    -0.0570f,
                    -0.0644f,
                    -0.0645f,
                    -0.0541f,
                    -0.0308f,
                     0.0065f,
                     0.0569f,
                     0.1168f,
                     0.1802f,
                     0.2385f,
                     0.2815f,
                     0.2985f,
                     0.2802f,
                     0.2203f,
                     0.1175f,
                    -0.0234f,
                    -0.1910f,
                    -0.3680f,
                    -0.5324f,
                    -0.6608f,
                    -0.7313f,
                    -0.7272f,
                    -0.6400f,
                    -0.4719f,
                    -0.2360f,
                     0.0441f,
                     0.3374f,
                     0.6095f,
                     0.8269f,
                     0.9624f,
                     0.9988f,
                     0.9313f,
                     0.7686f,
                     0.5314f,
                     0.2493f,
                    -0.0436f,
                    -0.3133f,
                    -0.5307f,
                    -0.6752f,
                    -0.7370f,
                    -0.7172f,
                    -0.6271f,
                    -0.4853f,
                    -0.3147f,
                    -0.1384f,
                     0.0227f,
                     0.1530f,
                     0.2430f,
                     0.2899f,
                     0.2967f,
                     0.2707f,
                     0.2220f,
                     0.1611f,
                     0.0979f,
                     0.0404f,
                    -0.0062f,
                    -0.0393f,
                    -0.0585f,
                    -0.0654f,
                    -0.0628f,
                    -0.0537f,
                     0.0070f,
                    -0.0413f,
                    -0.0281f,
                    -0.0160f,
                    -0.0062f,
                     0.0009f,
                     0.0053f,
                     0.0074f
#endregion
                   }, false);
            
            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNonNormalizedCorrelation));
        }

        [TestMethod]
        public void AutoDirectNonNormalizedPeriodicCorrelationTestMethod1()
        {
            DirectCorrelation dc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() {
                                           #region expectedOutput
0.145421785526316f,
0.138043570789474f,
0.116860675657895f,
0.084224521315789f,
0.043786225657895f,
0.000007987500000f,
-0.042380627236842f,
-0.078946513947368f,
-0.106064036973684f,
-0.121311966052632f,
-0.123699196052632f,
-0.113715587500000f,
-0.093191081447368f,
-0.065002891842105f,
-0.032672409342105f,
0.000088338947368f,
0.029820537236842f,
0.053696731710526f,
0.069791111052632f,
0.077217068684211f,
0.076126451578947f,
0.067585473684211f,
0.053353794210526f,
0.035607142631579f,
0.016642465394737f,
-0.001393627763158f,
-0.016724496052632f,
-0.028090006315789f,
-0.034813929736842f,
-0.036795476578947f,
-0.034439652105263f,
-0.028544569342105f,
-0.020167362500000f,
-0.010487330394737f,
-0.000683271052632f,
0.008168050526316f,
0.015167227894737f,
0.019642570263158f,
0.021180718421053f,
0.019642570263158f,
0.015167227894737f,
0.008168050526316f,
-0.000683271052632f,
-0.010487330394737f,
-0.020167362500000f,
-0.028544569342105f,
-0.034439652105263f,
-0.036795476578947f,
-0.034813929736842f,
-0.028090006315789f,
-0.016724496052632f,
-0.001393627763158f,
0.016642465394737f,
0.035607142631579f,
0.053353794210526f,
0.067585473684211f,
0.076126451578947f,
0.077217068684211f,
0.069791111052632f,
0.053696731710526f,
0.029820537236842f,
0.000088338947368f,
-0.032672409342105f,
-0.065002891842105f,
-0.093191081447368f,
-0.113715587500000f,
-0.123699196052632f,
-0.121311966052632f,
-0.106064036973684f,
-0.078946513947368f,
-0.042380627236842f,
0.000007987500000f,
0.043786225657895f,
0.084224521315789f,
0.116860675657895f,
0.138043570789474f,

#endregion
                                                 }, true);


            dc.InputSignal1 = new Signal(new List<float>() {
                      #region input
                     0.0078f,
                     0.0042f,
                    -0.0010f,
                    -0.0089f,
                    -0.0195f,
                    -0.0321f,
                    -0.0453f,
                    -0.0570f,
                    -0.0644f,
                    -0.0645f,
                    -0.0541f,
                    -0.0308f,
                     0.0065f,
                     0.0569f,
                     0.1168f,
                     0.1802f,
                     0.2385f,
                     0.2815f,
                     0.2985f,
                     0.2802f,
                     0.2203f,
                     0.1175f,
                    -0.0234f,
                    -0.1910f,
                    -0.3680f,
                    -0.5324f,
                    -0.6608f,
                    -0.7313f,
                    -0.7272f,
                    -0.6400f,
                    -0.4719f,
                    -0.2360f,
                     0.0441f,
                     0.3374f,
                     0.6095f,
                     0.8269f,
                     0.9624f,
                     0.9988f,
                     0.9313f,
                     0.7686f,
                     0.5314f,
                     0.2493f,
                    -0.0436f,
                    -0.3133f,
                    -0.5307f,
                    -0.6752f,
                    -0.7370f,
                    -0.7172f,
                    -0.6271f,
                    -0.4853f,
                    -0.3147f,
                    -0.1384f,
                     0.0227f,
                     0.1530f,
                     0.2430f,
                     0.2899f,
                     0.2967f,
                     0.2707f,
                     0.2220f,
                     0.1611f,
                     0.0979f,
                     0.0404f,
                    -0.0062f,
                    -0.0393f,
                    -0.0585f,
                    -0.0654f,
                    -0.0628f,
                    -0.0537f,
                     0.0070f,
                    -0.0413f,
                    -0.0281f,
                    -0.0160f,
                    -0.0062f,
                     0.0009f,
                     0.0053f,
                     0.0074f
#endregion
                   }, true);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNonNormalizedCorrelation));
        
        }

        [TestMethod]
        public void AutoDirectNormalizedNonPeriodicCorrelationTestMethod1()
        {

            DirectCorrelation dc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() {
                                           #region expectedOutput
1.000000000000000f,
0.949258123988644f,
0.803591582514373f,
0.579172048508587f,
0.301108588332576f,
0.000085980384627f,
-0.291375530255426f,
-0.542798855058250f,
-0.729307631882456f,
-0.834170871940141f,
-0.850634201924987f,
-0.782079625241122f,
-0.641105408109733f,
-0.447505288088622f,
-0.225489315078280f,
-0.000557410328650f,
0.203558170630646f,
0.367497945201271f,
0.478130052312350f,
0.529489342874014f,
0.522753633063938f,
0.465364550234759f,
0.369475305847400f,
0.250003358198783f,
0.122569800295161f,
0.001606029727121f,
-0.101161210217209f,
-0.177696176467876f,
-0.224059248090833f,
-0.240257222011648f,
-0.229638305206877f,
-0.197971565597520f,
-0.152377186264090f,
-0.100265370540975f,
-0.048420914129124f,
-0.002320586386477f,
0.034268192296570f,
0.059400286048142f,
0.072825121574442f,
0.075672806281640f,
0.070029989986388f,
0.058488584164483f,
0.043722367414417f,
0.028148731642748f,
0.013695334524961f,
0.001683442474869f,
-0.007187642023918f,
-0.012768667099642f,
-0.015340437526025f,
-0.015466121836501f,
-0.013845602497280f,
-0.011189379003944f,
-0.008127075400100f,
-0.005149105428414f,
-0.002585338038063f,
-0.000609744484006f,
0.000733623700431f,
0.001497595601151f,
0.001791926365337f,
0.001750249050953f,
0.001504207945677f,
0.001164877408282f,
0.000815898892004f,
0.000509732320658f,
0.000272391859191f,
0.000108842194851f,
0.000010647792881f,
-0.000036778678196f,
-0.000046890824121f,
-0.000080698109402f,
-0.000056919727612f,
-0.000031053951348f,
-0.000010472259925f,
0.000001979722198f,
0.000006552627128f,
0.000005222557827f,

#endregion
                                                 }, false);


            dc.InputSignal1 = new Signal(new List<float>() {
                      #region input
                     0.0078f,
                     0.0042f,
                    -0.0010f,
                    -0.0089f,
                    -0.0195f,
                    -0.0321f,
                    -0.0453f,
                    -0.0570f,
                    -0.0644f,
                    -0.0645f,
                    -0.0541f,
                    -0.0308f,
                     0.0065f,
                     0.0569f,
                     0.1168f,
                     0.1802f,
                     0.2385f,
                     0.2815f,
                     0.2985f,
                     0.2802f,
                     0.2203f,
                     0.1175f,
                    -0.0234f,
                    -0.1910f,
                    -0.3680f,
                    -0.5324f,
                    -0.6608f,
                    -0.7313f,
                    -0.7272f,
                    -0.6400f,
                    -0.4719f,
                    -0.2360f,
                     0.0441f,
                     0.3374f,
                     0.6095f,
                     0.8269f,
                     0.9624f,
                     0.9988f,
                     0.9313f,
                     0.7686f,
                     0.5314f,
                     0.2493f,
                    -0.0436f,
                    -0.3133f,
                    -0.5307f,
                    -0.6752f,
                    -0.7370f,
                    -0.7172f,
                    -0.6271f,
                    -0.4853f,
                    -0.3147f,
                    -0.1384f,
                     0.0227f,
                     0.1530f,
                     0.2430f,
                     0.2899f,
                     0.2967f,
                     0.2707f,
                     0.2220f,
                     0.1611f,
                     0.0979f,
                     0.0404f,
                    -0.0062f,
                    -0.0393f,
                    -0.0585f,
                    -0.0654f,
                    -0.0628f,
                    -0.0537f,
                     0.0070f,
                    -0.0413f,
                    -0.0281f,
                    -0.0160f,
                    -0.0062f,
                     0.0009f,
                     0.0053f,
                     0.0074f
#endregion
                   }, false);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNormalizedCorrelation));
        
        }

        [TestMethod]
        public void AutoDirectNormalizedPeriodicCorrelationTestMethod1()
        {
            DirectCorrelation dc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() {
                                           #region expectedOutput
1.000000000000000f,
0.949263346546471f,
0.803598135141501f,
0.579174028230784f,
0.301098116072651f,
0.000054926433279f,
-0.291432449983038f,
-0.542879553167652f,
-0.729354522706577f,
-0.834207650618337f,
-0.850623554132106f,
-0.781970783046271f,
-0.640833016250542f,
-0.446995555767965f,
-0.224673416186276f,
0.000607467079631f,
0.205062378576322f,
0.369248194252224f,
0.479921978677686f,
0.530986938475165f,
0.523487256764368f,
0.464754805750753f,
0.366889967809337f,
0.244854252770369f,
0.114442724895062f,
-0.009583349276823f,
-0.115006812714489f,
-0.193162298304378f,
-0.239399685616858f,
-0.253025889111290f,
-0.236825947230794f,
-0.196288123122651f,
-0.138681851739129f,
-0.072116638898228f,
-0.004698546714708f,
0.056167997778006f,
0.104298182282958f,
0.135073092329783f,
0.145650243148883f,
0.135073092329783f,
0.104298182282958f,
0.056167997778006f,
-0.004698546714708f,
-0.072116638898228f,
-0.138681851739129f,
-0.196288123122651f,
-0.236825947230794f,
-0.253025889111290f,
-0.239399685616858f,
-0.193162298304378f,
-0.115006812714489f,
-0.009583349276823f,
0.114442724895062f,
0.244854252770369f,
0.366889967809337f,
0.464754805750753f,
0.523487256764368f,
0.530986938475165f,
0.479921978677686f,
0.369248194252224f,
0.205062378576322f,
0.000607467079631f,
-0.224673416186276f,
-0.446995555767965f,
-0.640833016250543f,
-0.781970783046271f,
-0.850623554132106f,
-0.834207650618337f,
-0.729354522706577f,
-0.542879553167652f,
-0.291432449983038f,
0.000054926433279f,
0.301098116072651f,
0.579174028230784f,
0.803598135141502f,
0.949263346546471f,
#endregion
                                                 }, true);


            dc.InputSignal1 = new Signal(new List<float>() {
                      #region input
                     0.0078f,
                     0.0042f,
                    -0.0010f,
                    -0.0089f,
                    -0.0195f,
                    -0.0321f,
                    -0.0453f,
                    -0.0570f,
                    -0.0644f,
                    -0.0645f,
                    -0.0541f,
                    -0.0308f,
                     0.0065f,
                     0.0569f,
                     0.1168f,
                     0.1802f,
                     0.2385f,
                     0.2815f,
                     0.2985f,
                     0.2802f,
                     0.2203f,
                     0.1175f,
                    -0.0234f,
                    -0.1910f,
                    -0.3680f,
                    -0.5324f,
                    -0.6608f,
                    -0.7313f,
                    -0.7272f,
                    -0.6400f,
                    -0.4719f,
                    -0.2360f,
                     0.0441f,
                     0.3374f,
                     0.6095f,
                     0.8269f,
                     0.9624f,
                     0.9988f,
                     0.9313f,
                     0.7686f,
                     0.5314f,
                     0.2493f,
                    -0.0436f,
                    -0.3133f,
                    -0.5307f,
                    -0.6752f,
                    -0.7370f,
                    -0.7172f,
                    -0.6271f,
                    -0.4853f,
                    -0.3147f,
                    -0.1384f,
                     0.0227f,
                     0.1530f,
                     0.2430f,
                     0.2899f,
                     0.2967f,
                     0.2707f,
                     0.2220f,
                     0.1611f,
                     0.0979f,
                     0.0404f,
                    -0.0062f,
                    -0.0393f,
                    -0.0585f,
                    -0.0654f,
                    -0.0628f,
                    -0.0537f,
                     0.0070f,
                    -0.0413f,
                    -0.0281f,
                    -0.0160f,
                    -0.0062f,
                     0.0009f,
                     0.0053f,
                     0.0074f
#endregion
                   }, true);

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNormalizedCorrelation));

        }


        [TestMethod]
        public void AutoDirectNonNormalizedNonPeriodicCorrelationTestMethod2()
        {
            DirectCorrelation dc = new DirectCorrelation();

            dc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationNonPeriodic_TestCase.ds");
            Signal expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationNonNormalizedNonPeriodic_TestCase.ds");

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNonNormalizedCorrelation));
        
        }

        [TestMethod]
        public void AutoDirectNonNormalizedPeriodicCorrelationTestMethod2()
        {
            DirectCorrelation dc = new DirectCorrelation();

            dc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationPeriodic_TestCase.ds");
            Signal expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationNonNormalizedPeriodic_TestCase.ds");

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNonNormalizedCorrelation));
        
        }

        [TestMethod]
        public void AutoDirectNormalizedNonPeriodicCorrelationTestMethod2()
        {

            DirectCorrelation dc = new DirectCorrelation();

            dc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationNonPeriodic_TestCase.ds");
            Signal expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationNormalizedNonPeriodic_TestCase.ds");

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNormalizedCorrelation));
        
       
        }

        [TestMethod]
        public void AutoDirectNormalizedPeriodicCorrelationTestMethod2()
        {

            DirectCorrelation dc = new DirectCorrelation();

            dc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationPeriodic_TestCase.ds");
            Signal expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/AutoCorrelationNormalizedPeriodic_TestCase.ds");

            dc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, dc.OutputNormalizedCorrelation));
        
       
        }

        #endregion auto direct correlation

        #region auto fast correlation
        [TestMethod]
        public void AutoFastNormalizedCorrelationTestMethod1()
        {
            FastCorrelation fc = new FastCorrelation();

            var expectedOutput = new Signal(new List<float>() { 1.00f, 0.50f, 0.00f, 0.50f}, false);

            fc.InputSignal1 = new Signal(new List<float>() { 1, 0, 0, 1 }, true);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }
       
        [TestMethod]
        public void AutoFastNonNormalizedCorrelationTestMethod1()
        {
            FastCorrelation fc = new FastCorrelation();

            var expectedOutput = new Signal(new List<float>() { 0.50f, 0.25f, 0.00f, 0.25f}, false);

            fc.InputSignal1 = new Signal(new List<float>() { 1, 0, 0, 1 }, true);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));
        }

        [TestMethod]
        public void AutoFastNormalizedCorrelationTestMethod2()
        {
            FastCorrelation fc = new FastCorrelation();
            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/FastAutoCorrelationNormalized_TestCase.ds");
            fc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/FastAutoCorrelation.ds");
            fc.Run();
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }

        [TestMethod]
        public void AutoFastNonNormalizedCorrelationTestMethod2()
        {
            FastCorrelation fc = new FastCorrelation();
            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/FastAutoCorrelationNonNormalized_TestCase.ds");
            fc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/FastAutoCorrelation.ds");
            fc.Run();
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));
        }

        #endregion 
        
        #region cross direct correlation

        [TestMethod]
        public void CrossDirectNonNormalizedNonPeriodicCorrelationTestMethod1()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() { 4.8333333f, 2.8333333f, 2.0000000f, 0.0000000f, 0.0000000f, 0.0000000f}, false);

            fc.InputSignal1 = new Signal(new List<float>() { 4, 3, 1, 6 }, false);
            fc.InputSignal2 = new Signal(new List<float>() { 5, 2, 3}, false);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossDirectNonNormalizedPeriodicCorrelationTestMethod1()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() { 4.8333333f, 2.8333333f, 2.0000000f, 5.0000000f, 2.8333333f, 5.8333333f }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 4, 3, 1, 6 }, true);
            fc.InputSignal2 = new Signal(new List<float>() { 5, 2, 3 }, true);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossDirectNormalizedNonPeriodicCorrelationTestMethod1()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() { 0.5974621f, 0.3502364f, 0.2472257f, 0.0000000f, 0.0000000f, 0.0000000f}, false);

            fc.InputSignal1 = new Signal(new List<float>() { 4, 3, 1, 6 }, false);
            fc.InputSignal2 = new Signal(new List<float>() { 5, 2, 3 }, false);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossDirectNormalizedPeriodicCorrelationTestMethod1()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() {0.5974621f, 0.3502364f, 0.2472257f, 0.6180642f, 0.3502364f, 0.7210749f, }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 4, 3, 1, 6 }, true);
            fc.InputSignal2 = new Signal(new List<float>() { 5, 2, 3 }, true);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossDirectNonNormalizedNonPeriodicCorrelationTestMethod2()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() { 0.7142857f, 0.8571429f, 1.1428571f, 0.0000000f, 0.0000000f, 0.0000000f, 0.0000000f }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 2, 1 , 0, 0, 3 }, false);
            fc.InputSignal2 = new Signal(new List<float>() { 2, 1, 4 }, false);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossDirectNonNormalizedPeriodicCorrelationTestMethod2()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() { 0.7142857f, 0.8571429f, 1.1428571f, 0.8571429f, 0.4285714f, 1.7142857f, 0.2857143f }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 2, 1, 0, 0, 3 }, true);
            fc.InputSignal2 = new Signal(new List<float>() { 2, 1, 4 }, true); fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossDirectNormalizedNonPeriodicCorrelationTestMethod2()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() { 0.2916059f, 0.3499271f, 0.4665695f, 0.0000000f, 0.0000000f, 0.0000000f, 0.0000000f}, false);
            
            fc.InputSignal1 = new Signal(new List<float>() { 2, 1, 0, 0, 3 }, false);
            fc.InputSignal2 = new Signal(new List<float>() { 2, 1, 4 }, false); fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossDirectNormalizedPeriodicCorrelationTestMethod2()
        {
            DirectCorrelation fc = new DirectCorrelation();

            var expectedOutput = new Signal(new List<float>() { 0.2916059f, 0.3499271f, 0.4665695f, 0.3499271f, 0.1749636f, 0.6998542f, 0.1166424f, }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 2, 1, 0, 0, 3 }, true);
            fc.InputSignal2 = new Signal(new List<float>() { 2, 1, 4 }, true);
            
            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }

        #endregion 
        
        #region cross fast correlation
        [TestMethod]
        public void CrossFastNormalizedCorrelationTestMethod1()
        {
            FastCorrelation fc = new FastCorrelation();

            var expectedOutput = new Signal(new List<float>() { 0.9667248f, 0.7352555f, 0.6807921f, 0.8577981f}, false);

            fc.InputSignal1 = new Signal(new List<float>() { 4, 3, 1, 6 }, false);
            fc.InputSignal2 = new Signal(new List<float>() { 5, 2, 3, 7 }, false);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossFastNonNormalizedCorrelationTestMethod1()
        {
            FastCorrelation fc = new FastCorrelation();

            var expectedOutput = new Signal(new List<float>() { 17.7500000f, 13.5000000f, 12.5000000f, 15.7500000f }, false);

            fc.InputSignal1 = new Signal(new List<float>() { 4, 3, 1, 6 }, false);
            fc.InputSignal2 = new Signal(new List<float>() { 5, 2, 3, 7 }, false);

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));

        }

        [TestMethod]
        public void CrossFastNormalizedCorrelationTestMethod2()
        {
            FastCorrelation fc = new FastCorrelation();

            fc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/CrossCorrelation_Signal1.ds");
            fc.InputSignal2 = UnitTestUtitlities.LoadSignal("TestingSignals/CrossCorrelation_Signal2.ds");

            Signal expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/CrossCorrelationNormalized_TestCase.ds");

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNormalizedCorrelation));
        }

        [TestMethod]
        public void CrossFastNonNormalizedCorrelationTestMethod2()
        {
            FastCorrelation fc = new FastCorrelation();

            fc.InputSignal1 = UnitTestUtitlities.LoadSignal("TestingSignals/CrossCorrelation_Signal1.ds");
            fc.InputSignal2 = UnitTestUtitlities.LoadSignal("TestingSignals/CrossCorrelation_Signal2.ds");

            Signal expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/CrossCorrelationNonNormalized_TestCase.ds");

            fc.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, fc.OutputNonNormalizedCorrelation));
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSPAlgorithms.DataStructures;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace DSPUI.Utilities
{
    public static class GraphPlotter
    {
        public static void PlotGraph(Signal Sig)
        {
            PlotView plotSamples=null;
            PlotView plotFreqAmp=null;
            PlotView plotFreqPhase=null;
            short time_freq_timefreq = -1;

            if (Sig.Samples != null && Sig.Samples.Count > 0)
            {
                time_freq_timefreq = 0;
                plotSamples = GetPlot(Sig.SamplesIndices, Sig.Samples);
            }
            if (Sig.Frequencies != null && Sig.Frequencies.Count > 0)
            {
                if (time_freq_timefreq == 0)
                    time_freq_timefreq = 2;
                else
                    time_freq_timefreq = 1;
                
                plotFreqAmp = GetPlot(Sig.Frequencies, Sig.FrequenciesAmplitudes);
                plotFreqPhase = GetPlot(Sig.Frequencies, Sig.FrequenciesPhaseShifts);
            }

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;
            
            var fGraph = new Form();

            switch (time_freq_timefreq)
            {
                case 0:
                    var p1 = new Panel();
                    p1.Dock = DockStyle.Fill;
                    p1.Controls.Add(plotSamples);
                    tlp.Controls.Add(p1, 0, 0);
                    break;

                case 1:
                    p1 = new Panel();
                    p1.Dock = DockStyle.Fill;
                    p1.Controls.Add(plotFreqAmp);
                    tlp.Controls.Add(p1, 0, 0);
                    
                    p1 = new Panel();
                    p1.Dock = DockStyle.Fill;
                    p1.Controls.Add(plotFreqPhase);
                    tlp.Controls.Add(p1, 1, 0);

                    tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent , Width=0.5f});
                    tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent , Width=0.5f});
                    break;

                case 2:
                    p1 = new Panel();
                    p1.Dock = DockStyle.Fill;
                    p1.Controls.Add(plotSamples);
                    tlp.Controls.Add(p1, 0, 0);
                    p1 = new Panel();
                    p1.Dock = DockStyle.Fill;
                    p1.Controls.Add(plotFreqAmp);
                    tlp.Controls.Add(p1, 1, 0);
                    p1 = new Panel();
                    p1.Dock = DockStyle.Fill;
                    p1.Controls.Add(plotFreqPhase);
                    tlp.Controls.Add(p1, 2, 0);
                    
                    tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent , Width=0.34f});
                    tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent , Width=0.33f});
                    tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent , Width=0.33f});
                    break;
            }
            
            
            //tlp.Controls.Add(new Label() { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            //tlp.Controls.Add(new ComboBox() { Dock = DockStyle.Fill }, 0, 1);
            fGraph.Controls.Add(tlp);
            fGraph.BackColor = System.Drawing.Color.White;
            fGraph.Width = 1000;
            fGraph.Height = 500;
            fGraph.Show();
        }

        private static PlotView GetPlot(List<float> xAxisSamples, List<float> yAxisSamples)
        {
            var plot = new PlotView();
            LinearAxis XAxis = new LinearAxis() { Position = AxisPosition.Bottom };//, Minimum = 0, Maximum = 10 };
            LinearAxis YAxis = new LinearAxis();

            PlotModel pm = new PlotModel();
            pm.Axes.Add(XAxis);
            pm.Axes.Add(YAxis);

            FunctionSeries fs = new FunctionSeries();
            for (int i = 0; i < xAxisSamples.Count; i++)
            {
                double x = i;
                fs.Points.Add(new DataPoint(xAxisSamples[i], yAxisSamples[i]));
            }

            pm.Series.Add(fs);
            plot.Model = pm;
            //plot.Anchor = AnchorStyles.Left|AnchorStyles.Right;
            //plot.Size = new System.Drawing.Size(100, 100);
            plot.Dock = DockStyle.Fill;
            return plot;
        }

        private static PlotView GetPlot(List<int> list1, List<float> list2)
        {
            var newListFloat = new List<float>(list1.Count);

            foreach (var l in list1)
            {
                newListFloat.Add(l);
            }

            return GetPlot(newListFloat, list2);
        }

        public static void PlotGraph(List<Signal> Sigs)
        {
            //short time_freq_timefreq = -1;

            //foreach (var s in Sigs)
            //{
            //    if (s.Samples != null && s.Samples.Count > 0)
            //    {
            //        if (time_freq_timefreq == 1)
            //        {
            //            time_freq_timefreq = 2;
            //            break;
            //        }
            //        else
            //            time_freq_timefreq = 0;
            //    }
            //    if (s.Frequencies != null && s.Frequencies.Count > 0)
            //    {
            //        if (time_freq_timefreq == 0)
            //        {
            //            time_freq_timefreq = 2;
            //            break;
            //        }
            //        else
            //            time_freq_timefreq = 1;
            //    }
            //}

            PlotView plotSamples = null;
            PlotView plotFreqAmp = null;
            PlotView plotFreqPhase = null;
            
            LinearAxis XAxis = new LinearAxis() { Position = AxisPosition.Bottom, AbsoluteMinimum = 0 };//, Minimum = 0, Maximum = 10 };
            LinearAxis YAxis = new LinearAxis();

            short time_freq_timefreq;
            
            foreach (var Sig in Sigs)
            {
                time_freq_timefreq = -1;

                if (Sig.Samples != null && Sig.Samples.Count > 0)
                {
                    time_freq_timefreq = 0;
                    plotSamples = GetPlot(Sig.SamplesIndices, Sig.Samples);
                }

                if (Sig.Frequencies != null && Sig.Frequencies.Count > 0)
                {
                    if (time_freq_timefreq == 0)
                        time_freq_timefreq = 2;
                    else
                        time_freq_timefreq = 1;
                }

                switch (time_freq_timefreq)
                { 
                    case 0:
                        if (plotSamples == null)
                            plotSamples = GetPlot(Sig.SamplesIndices, Sig.Samples);
                        else
                            plotSamples.Model.Series.Add(GetPlotSeries(Sig, true, false, false));
                        break;
                    
                    case 1:
                        if (plotFreqAmp == null)
                        {
                            plotFreqAmp = GetPlot(Sig.Frequencies, Sig.FrequenciesAmplitudes);
                            plotFreqPhase = GetPlot(Sig.Frequencies, Sig.FrequenciesPhaseShifts);
                        }
                        else
                        {
                            plotFreqAmp.Model.Series.Add(GetPlotSeries(Sig, false, true, false));
                            plotFreqPhase.Model.Series.Add(GetPlotSeries(Sig, false, false, true));
                        }
                        break;
                    
                    case 2:
                        if (plotSamples == null)
                            plotSamples = GetPlot(Sig.SamplesIndices, Sig.Samples);
                        else
                            plotSamples.Model.Series.Add(GetPlotSeries(Sig, true, false, false));

                        if (plotFreqAmp == null)
                        {
                            plotFreqAmp = GetPlot(Sig.Frequencies, Sig.FrequenciesAmplitudes);
                            plotFreqAmp = GetPlot(Sig.Frequencies, Sig.FrequenciesPhaseShifts);
                        }
                        else
                        {
                            plotFreqAmp.Model.Series.Add(GetPlotSeries(Sig, false, true, false));
                            plotFreqPhase.Model.Series.Add(GetPlotSeries(Sig, false, false, true));
                        }
                        break;
                }
            }

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;

            var fGraph = new Form();
            
            var p1 = new Panel();

            if (plotSamples != null)
            {
                p1.Dock = DockStyle.Fill;
                p1.Controls.Add(plotSamples);
                tlp.Controls.Add(p1, 0, 0);
            }

            if (plotFreqAmp != null)
            {
                p1 = new Panel();
                p1.Dock = DockStyle.Fill;
                p1.Controls.Add(plotFreqAmp);
                tlp.Controls.Add(p1, plotSamples == null ? 0 : 1, 0);

                p1 = new Panel();
                p1.Dock = DockStyle.Fill;
                p1.Controls.Add(plotFreqPhase);
                tlp.Controls.Add(p1, plotSamples == null ? 1 : 2, 0);

                if (plotSamples != null)
                    tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent, Width = 0.34f });

                tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent, Width = plotSamples == null ? 0.5f : 0.33f });
                tlp.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent, Width = plotSamples == null ? 0.5f : 0.33f });
            }


            //tlp.Controls.Add(new Label() { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            //tlp.Controls.Add(new ComboBox() { Dock = DockStyle.Fill }, 0, 1);
            fGraph.Controls.Add(tlp);
            fGraph.BackColor = System.Drawing.Color.White;
            fGraph.Width = 500;
            fGraph.Height = 200;
            fGraph.Show();
        }

        private static Series GetPlotSeries(Signal Sig, bool sample, bool freqAmp, bool freqPhase)
        {
            FunctionSeries fs = new FunctionSeries();
            for (int i = 0; i < Sig.Samples.Count; i++)
            {
                double x = i;
                if (sample)
                    fs.Points.Add(new DataPoint(Sig.SamplesIndices[i], Sig.Samples[i]));
                else if (freqAmp)
                    fs.Points.Add(new DataPoint(Sig.Frequencies[i], Sig.FrequenciesAmplitudes[i]));
                else if (freqPhase)
                    fs.Points.Add(new DataPoint(Sig.Frequencies[i], Sig.FrequenciesPhaseShifts[i]));
            }

            return fs;
        }
    }
}

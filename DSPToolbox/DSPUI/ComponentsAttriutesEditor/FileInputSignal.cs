using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSPAlgorithms.DataStructures;
using DSPUI.Utilities;
using OxyPlot;
using OxyPlot.WindowsForms;

namespace DSPUI.ComponentsAttriutesEditor
{
    public partial class FileInputSignal : Form
    {
        private Components.FileSignalAttributes Data;

        public FileInputSignal(Components.FileSignalAttributes _Data)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.Data = _Data;

            if (_Data.FilePath != null)
            {
                FilePathTXTBX.Text = _Data.FilePath;
            }
            
            PlotSignalBTN.Enabled = _Data.Signal != null; 
        }

        private void PlotSignalBTN_Click(object sender, EventArgs e)
        {
            if (Data.Signal != null)
                GraphPlotter.PlotGraph(Data.Signal);
        }

        private void ChangeFileBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Data.FilePath = FilePathTXTBX.Text = ofd.FileName;
                    Stream stream = File.Open(Data.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    var sr = new StreamReader(stream);

                    var sigType = byte.Parse(sr.ReadLine());
                    var isPeriodic = byte.Parse(sr.ReadLine());
                    long N1 = long.Parse(sr.ReadLine());

                    List<float> SigSamples = new List<float>(unchecked((int)N1));
                    List<int> SigIndices = new List<int>(unchecked((int)N1));
                    List<float> SigFreq = new List<float>(unchecked((int)N1));
                    List<float> SigFreqAmp = new List<float>(unchecked((int)N1));
                    List<float> SigPhaseShift = new List<float>(unchecked((int)N1));
                    
                    if (sigType == 1)
                    {
                        SigSamples = null;
                        SigIndices = null;
                    }
                    
                    for (int i = 0; i < N1; i++)
                    {
                        if (sigType == 0 || sigType == 2)
                        {
                            var timeIndex_SampleAmplitude = sr.ReadLine().Split();
                            SigIndices.Add(int.Parse(timeIndex_SampleAmplitude[0]));
                            SigSamples.Add(float.Parse(timeIndex_SampleAmplitude[1]));
                        }
                        else
                        { 
                            var Freq_Amp_PhaseShift = sr.ReadLine().Split();
                            SigFreq.Add(float.Parse(Freq_Amp_PhaseShift[0]));
                            SigFreqAmp.Add(float.Parse(Freq_Amp_PhaseShift[1]));
                            SigPhaseShift.Add(float.Parse(Freq_Amp_PhaseShift[2]));
                        }
                    }

                    if (!sr.EndOfStream)
                    {
                        long N2 = long.Parse(sr.ReadLine());

                        for (int i = 0; i < N2; i++)
                        {
                            var Freq_Amp_PhaseShift = sr.ReadLine().Split();
                            SigFreq.Add(float.Parse(Freq_Amp_PhaseShift[0]));
                            SigFreqAmp.Add(float.Parse(Freq_Amp_PhaseShift[1]));
                            SigPhaseShift.Add(float.Parse(Freq_Amp_PhaseShift[2]));
                        }
                    }

                    Data.Signal = new Signal(SigSamples, SigIndices, isPeriodic == 1, SigFreq, SigFreqAmp, SigPhaseShift);
                    stream.Close();
                    PlotSignalBTN.Enabled = true;
                }
                catch
                {
                    ResetSignal();
                }
            }
            else
            {
                ResetSignal();
            }
        }

        private void ResetSignal()
        {
            Data.Signal = null;
            Data.FilePath = null;
            FilePathTXTBX.Text = "";
        }
    }
}
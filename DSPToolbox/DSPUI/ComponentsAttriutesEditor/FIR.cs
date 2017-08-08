using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSPAlgorithms.DataStructures;

namespace DSPUI.ComponentsAttriutesEditor
{
    public partial class FIR : Form
    {
        private Components.FIRAttributes myData;
        
        public FIR(Components.FIRAttributes myData)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.myData = myData;
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            if (LowPassFilterRB.Checked)
                myData.FilterType = FILTER_TYPES.LOW;
            else if (HighPassFilterRB.Checked)
                myData.FilterType = FILTER_TYPES.HIGH;
            else if (BandPassFilterRB.Checked)
                myData.FilterType = FILTER_TYPES.BAND_PASS;
            else if (BandStopFilterRB.Checked)
                myData.FilterType = FILTER_TYPES.BAND_STOP;
            else
                myData.FilterType = null;

            float tmp;

            if (float.TryParse(FSTXTBX.Text, out tmp))
                myData.SamplingFrequency = tmp;
            else 
                myData.SamplingFrequency = null;

            if (CutOffFrequencyTXTBX.Text != "")
            {
                float.TryParse(CutOffFrequencyTXTBX.Text, out tmp);
                myData.CutOffFrequency = tmp;
            }
            else
            {
                myData.CutOffFrequency = null;

                if (F1TXTBX.Text != "")
                {
                    float.TryParse(F1TXTBX.Text, out tmp);
                    myData.F1 = tmp;
                }
                else
                    myData.F1 = null;

                if (F2TXTBX.Text != "")
                {
                    float.TryParse(F2TXTBX.Text, out tmp);
                    myData.F2 = tmp;
                }
                else
                    myData.F2 = null;
            }

            if (float.TryParse(StopBandDeviationTXTBX.Text, out tmp))
                myData.StopBandAttenuation = tmp;
            else
                myData.StopBandAttenuation = null;

            if (float.TryParse(TransitionBandTXTBX.Text, out tmp))
                myData.TransitionBand = tmp;
            else
                myData.TransitionBand = null;

            Close();
        }
    }
}

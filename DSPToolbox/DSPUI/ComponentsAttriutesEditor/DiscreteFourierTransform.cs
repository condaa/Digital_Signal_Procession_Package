using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSPUI.ComponentsAttriutesEditor
{
    public partial class DiscreteFourierTransform : Form
    {
        private Components.DiscreteFourierTransformAttributes myData;

        public DiscreteFourierTransform(Components.DiscreteFourierTransformAttributes myData)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.myData = myData;
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            try 
            {
                if (SamplingFreqTXBX.Text == "")
                    myData.SamplingFrequency = null;
                else 
                    myData.SamplingFrequency = float.Parse(SamplingFreqTXBX.Text);
                
                Close();
            }
            catch{}
        }
    }
}

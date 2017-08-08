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
    public partial class FastFourierTransform : Form
    {
        private Components.FastFourierTransformAttributes myData;
        
        public FastFourierTransform(Components.FastFourierTransformAttributes myData)
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
                    myData.SamplingFrequency = int.Parse(SamplingFreqTXBX.Text);
              
                Close();
            }
            catch { }
        }
    }
}

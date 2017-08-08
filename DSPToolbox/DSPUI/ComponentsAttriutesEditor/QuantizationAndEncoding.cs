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
    public partial class QuantizationAndEncoding : Form
    {
        private Components.QuantizationEncodingAttributes myData;

        public QuantizationAndEncoding(Components.QuantizationEncodingAttributes myData)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.myData = myData;

        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            int tmp;

            if (int.TryParse(LevelTXBX.Text, out tmp))
            {
                myData.Level = tmp;
                myData.NumBits = -1;
            }
            
            if (int.TryParse(NumBitsTXBX.Text, out tmp))
            {
                myData.NumBits = tmp;
                myData.Level = -1;
            }

            Close();
        }

        private void LevelCBX_CheckedChanged(object sender, EventArgs e)
        {
            LevelTXBX.Enabled = !LevelTXBX.Enabled;
        }

        private void NumBitsCBX_CheckedChanged(object sender, EventArgs e)
        {
            NumBitsTXBX.Enabled = !NumBitsTXBX.Enabled;
        }

        private void LevelTXBX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CloseBTN_Click(null, null);
        }

        private void NumBitsTXBX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CloseBTN_Click(null, null);
        }
    }
}

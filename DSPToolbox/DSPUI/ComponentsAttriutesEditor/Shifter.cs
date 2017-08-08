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
    public partial class Shifter : Form
    {
        private Components.ShifterAttributes myData;

        public Shifter(Components.ShifterAttributes myData)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.myData = myData;
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShiftingValueTXBX.Text == "")
                    myData.ShiftingValue = null;
                else
                    myData.ShiftingValue = int.Parse(ShiftingValueTXBX.Text);
                
                Close();
            }
            catch { }
        }
    }
}

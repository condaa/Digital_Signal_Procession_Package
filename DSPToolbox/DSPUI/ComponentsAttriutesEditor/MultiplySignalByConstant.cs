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
    public partial class MultiplySignalByConstant : Form
    {
        private Components.MultiplySignalByConstantAttributes myData;
        
        public MultiplySignalByConstant(Components.MultiplySignalByConstantAttributes myData)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.myData = myData;
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConstantTXBX.Text == "")
                    myData.ConstantValue = null;
                else
                    myData.ConstantValue = float.Parse(ConstantTXBX.Text);

                Close();
            }
            catch { }
        }
    }
}

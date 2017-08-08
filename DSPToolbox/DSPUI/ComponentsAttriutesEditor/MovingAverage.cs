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
    public partial class MovingAverage : Form
    {
        private Components.MovingAverageAttributes myData;

        public MovingAverage(Components.MovingAverageAttributes myData)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.myData = myData;
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (WindowSizeTXBX.Text == "")
                    myData.WindowSize = null;
                else
                    myData.WindowSize = int.Parse(WindowSizeTXBX.Text);

                Close();
            }
            catch { }
        }
    }
}

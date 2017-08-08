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
    public partial class Normalizer : Form
    {
        private Components.NormalizerAttributes myData;

        public Normalizer(Components.NormalizerAttributes myData)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.myData = myData;
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (MinValueTXBX.Text == "" || MaxValueTXBX.Text == "")
                    Close();
                else
                {
                    myData.MinValue = float.Parse(MinValueTXBX.Text);
                    myData.MaxValue = float.Parse(MaxValueTXBX.Text);
                }

                Close();
            }
            catch { }
        }
    }
}

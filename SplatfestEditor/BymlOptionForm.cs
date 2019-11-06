using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syroot.BinaryData;

namespace SplatfestEditor
{
    public partial class BymlOptionForm : Form
    {
        public ByteOrder SelectedByteOrder { get; set; }
        public ushort SelectedVersion { get; set; }


        public BymlOptionForm()
        {
            InitializeComponent();
        }

        private void BymlOptionForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SelectedByteOrder = (ByteOrder)comboBox1.SelectedIndex;
            SelectedVersion = (ushort)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

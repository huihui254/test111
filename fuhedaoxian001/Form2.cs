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

namespace fuhedaoxian001
{
    public partial class Form22 : Form
    {
        private string stile = "交会计算程序V0.0.0";
        public Form22()
        {
            InitializeComponent();
            this.Text = stile;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog pdlg = new OpenFileDialog();
            pdlg.Filter = "水准观测文件|*.in1|所有文件|*.*";
            DialogResult drt = pdlg.ShowDialog();//
            if (drt != DialogResult.OK)
                return;
            string sFile = pdlg.FileName;
            string sDisplay = Path.GetFileName(sFile);
            this.Text = stile + "-" + sDisplay;
            pknow.Text = String.Format("{0}", 100);
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
        打开OToolStripMenuItem_Click(sender,e);
        }

        private void 打开OToolStripButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}

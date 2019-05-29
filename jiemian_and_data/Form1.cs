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

namespace jiemian_and_data
{
    public partial class Form1 : Form
    {
        private List<MeasPoint> m_ptlst;//链表，模版类，变量，存储，查找方便
        public struct MeasPoint
        {
            public string Name;
            public double x;
            public double y;
        }//存储结构

        private string stile = "交会计算程序 V0.0.0";
        public Form1()
        {
            InitializeComponent();
            this.Text = stile;
            m_ptlst = new List<MeasPoint>();//实例化
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog pdlg = new OpenFileDialog();
            pdlg.Filter = "水准观测文件|*.in1|所有文件|*.*";
            DialogResult drt = pdlg.ShowDialog();
            if (drt != DialogResult.OK)
                return;
            string sFile = pdlg.FileName;
            string sDisplay = Path.GetFileName(sFile);
            this.Text = stile + "-" + sDisplay;//读取显示文件名
            if (drt == DialogResult.OK)
            {
                string sFileName = pdlg.FileName;
                try
                {
                    FileStream file = new FileStream(sFileName, FileMode.Open);
                    StreamReader sr = new StreamReader(file, Encoding.Default);// ancsii编码
                    string st = sr.ReadLine();//一次读一行
                    int ic = 0;//计数器
                    while (st != null)
                    {
                        ic++;
                        if (ic <= 4)
                        {
                            st = sr.ReadLine();
                            continue;
                        }//去掉没必要行的数据
                        if (st.Trim() == " ")
                            continue;//除去有空格的行
                        //切割字符串
                        StringSplit spt = new StringSplitFun(" ");
                        spt.Duplicates = false;
                        string[] sts = spt.Splitting(st);
                        int icols = sts.Count();//判断有几列
                        if (icols != 5)
                        {
                            st = sr.ReadLine();
                            continue;
                        }
                        MeasPoint pt = new MeasPoint();//新建一个结构，捆绑在一起，调用观测数据
                        pt.Name = sts[0];
                        pt.x = double.Parse(sts[1]);
                        pt.y = double.Parse(sts[2]);//局部变量
                        m_ptlst.Add(pt);
                        st = sr.ReadLine();
                    }
                    sr.Close();
                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
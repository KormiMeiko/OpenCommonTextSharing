using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCommonTextSharing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textSource2.Text = null;
            double u, x0;
            double.TryParse(textu.Text, out u);
            double.TryParse(textX0.Text, out x0);

            if (u < 3.57 || u > 4)
            {
                MessageBox.Show("参数u应大于等于3.57且小于等于4。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (x0 <= 0 || x0 >= 1)
            {
                MessageBox.Show("参数x应大于0且小于1。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(textSource.Text);
            byte[] dest = Chaos.Encrypt(data, u, x0);
            textDest.Text = Convert.ToBase64String(dest);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double u, x0;
            double.TryParse(textu.Text, out u);
            double.TryParse(textX0.Text, out x0);

            if (u < 3.57 || u > 4)
            {
                MessageBox.Show("参数u应大于等于3.57且小于等于4。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (x0 <= 0 || x0 >= 1)
            {
                MessageBox.Show("参数x应大于0且小于1。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                byte[] data = Convert.FromBase64String(textDest.Text);
                byte[] dest = Chaos.Encrypt(data, u, x0);
                textSource2.Text = Encoding.UTF8.GetString(dest);
            }
            catch (Exception)
            {
                MessageBox.Show("不合法的加密数据，解密失败。\n\n请检查参数是否设置正确或者加密内容是否完整。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textSource.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textSource.Text != "")
                Clipboard.SetDataObject(textSource.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textDest.Text = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textDest.Text != "")
                Clipboard.SetDataObject(textDest.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textSource2.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textSource2.Text != "")
                Clipboard.SetDataObject(textSource2.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textu.Text = "3.7";
            textX0.Text = "0.123";
        }

        private void 重启应用程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void 退出应用程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/KormiMeiko/OpenCommonTextSharing");
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OpenCommonTextSharing\n版本：0.1.0\n编译日期：20200623\n\n作者：KormiMeiko\nQQ：1070050130\nE-Mail：KormiMeiko@gmail.com\n\n*本项目使用GPLv3协议开源");
        }
    }
}

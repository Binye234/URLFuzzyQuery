using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using URLVariant;
using System.IO;

namespace UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private int num = 0;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text == "")
            {
                ShowNull();
                return;
            }
            string urlString = txtQuery.Text;
            num = 0;
            labNum.Text = num.ToString();
            if (!URLtool.IsURLString(urlString))
            {
                ShowUrlError();
                txtQuery.Text = "";
                return;
            }
            urlString = URLtool.GetURLInnerString(urlString);
            URLVariantClass uRLVariantClass = new URLVariantClass(new string[] { @"http://www.", @"https://www." }, new string[] { ".net", ".com", ".cn" });
            var list = uRLVariantClass.URLstringCreate(urlString);
            labCount.Text = list.Count.ToString();
            URLClient uRLClient = new URLClient(AddUrlList);
            uRLClient.UrlListQuery(list, () =>
             {
                 num++;
                 labNum.Text = num.ToString();
             });
        }

        private void ShowNull()
        {
            MessageBox.Show("域名不能为空");
        }

        private void ShowUrlError()
        {
            MessageBox.Show("域名格式不对");
        }

        private void AddUrlList(string urlSstring)
        {

            listQuery.Items.Add(urlSstring);
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "保存txt文件";
            saveFile.Filter = "文本文件|txt";
            saveFile.ShowDialog();
            var path = saveFile.FileName + ".txt";
            if (path == "")
            {
                MessageBox.Show("路径不能为空");
                return;
            }
            if (listQuery.Items.Count == 0)
            {
                MessageBox.Show("内容不能为空");
                return;
            }
            using (StreamWriter fs = new StreamWriter(path))
            {
                
                foreach (var item in listQuery.Items)
                {
                    fs.WriteLine(item);
                }
            }
            MessageBox.Show("成功");
        }
    }
}

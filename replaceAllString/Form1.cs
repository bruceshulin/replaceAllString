using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace replaceAllString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strKey = this.textBox1.Text;
            String strValue = this.textBox2.Text;
            string strSource = this.textBox3.Text;
            string strResult = this.textBox4.Text;
            //组合数据
            groupKeyValue(strKey, strValue);
            //替换数据
            strResult = ReplaceSource(strSource);
            this.textBox4.Text = strResult;
            
        }

        private string ReplaceSource(string strSource)
        {
            foreach (var item in G_dirReplace)
            {
                if (strSource.Contains(item.Key))
                {
                    strSource = strSource.Replace(item.Key, item.Value);
                }
            }
            return strSource;
        }
        Dictionary<string, string> G_dirReplace = new Dictionary<string, string>();

        private void groupKeyValue(string strKey, string strValue)
        {
            G_dirReplace.Clear();
            string[] key = strKey.Split('\n');
            string[] value = strValue.Split('\n');
            if (key.Length == value.Length)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    string tempkey = key[i].Trim('\r');
                    string tempValue = value[i].Trim('\r');
                    if (G_dirReplace.ContainsKey(tempkey))
                    {
                        ReprotError("重复关键值错误：" + tempkey);
                    }
                    G_dirReplace.Add(tempkey, tempValue);
                }

            }
            else 
            {
                ReprotError("KEY VALUE不对应");
            }
        }

        private void ReprotError(string p)
        {
            MessageBox.Show(p);
        }
    }
}

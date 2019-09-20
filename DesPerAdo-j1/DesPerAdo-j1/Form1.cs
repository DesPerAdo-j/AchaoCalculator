using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesPerAdo_j1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int test = 0;
            Guid t = Guid.NewGuid();
            int g = BitConverter.ToInt32(t.ToByteArray(), 0);
            Random shu = new Random(g);//用于产生数字
            Random fuhao = new Random(g);//用于产生运算符号
            int num = int.Parse(textBox1.Text);
            for(int i = 0; i < num;)
            {
                int shuzi1 = shu.Next(1, 101);//取0-100的随机数

                int fuhao1 = fuhao.Next(1, 5);//取1-4的随机数用来对应运算符号
                string jsysf1 = "";//用于接受运算符号
                switch (fuhao1)//判断运算符号
                {
                    case 1:
                        jsysf1 = "+";
                        break;
                    case 2:
                        jsysf1 = "-";
                        break;
                    case 3:
                        jsysf1 = "*";
                        break;
                    case 4:
                        jsysf1 = "/";
                        break;
                }


                int shuzi2 = shu.Next(1, 101);//取0-100的随机数


                if (jsysf1 == "/" && shuzi2 == 0)//除数为零的操作
                {
                    jsysf1 = "+";
                }
                if (jsysf1 == "/" && shuzi1 % shuzi2 != 0)//不能整除的操作
                {
                    jsysf1 = "-";
                }

                int fuhao2 = fuhao.Next(1, 5);//取1-4的随机数用来对应运算符号
                string jsysf2 = "";//用于接受运算符号
                switch (fuhao2)//判断运算符号
                {
                    case 1:
                        jsysf2 = "+";
                        break;
                    case 2:
                        jsysf2 = "-";
                        break;
                    case 3:
                        jsysf2 = "*";
                        break;
                    case 4:
                        jsysf2 = "/";
                        break;
                }

                int shuzi3 = shu.Next(1, 101);//取0-100的随机数

                if (jsysf2 == "/" && shuzi3 == 0)//除数为零的操作
                {
                    jsysf2 = "+";
                }
                Dictionary<int, string> hash = new Dictionary<int, string> { { 1, "+" }, { 2, "-" }, { 3, "*" }, { 4, "/" } };
                string js = NewMethod(shuzi1, fuhao1, shuzi2, fuhao2, shuzi3, hash);
                DataTable dataTable = new DataTable();
                object result = NewMethod1(js, dataTable);
                int t1;
                if (int.TryParse(result.ToString(), out t1))
                {
                    string re = js + "=" + result.ToString();
                    richTextBox1.AppendText(re + "\n");
                    i++;
                    test++;
                }
            }
        }

        public object NewMethod1(string js, DataTable dataTable)
        {
            return dataTable.Compute(js, null);
        }

        public string NewMethod(int shuzi1, int fuhao1, int shuzi2, int fuhao2, int shuzi3, Dictionary<int, string> hash)
        {
            return shuzi1.ToString() + hash[fuhao1] + shuzi2.ToString() + hash[fuhao2] + shuzi3.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
   
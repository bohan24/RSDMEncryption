using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rsacharge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PlainText = textBox1.Text;
            using (Aes aesAlg = Aes.Create())
            {
                //加密金鑰(32 Byte)
                aesAlg.Key = Encoding.Unicode.GetBytes("gitlabtestMarks6");
                //初始向量(Initial Vector, iv) 類似雜湊演算法中的加密鹽(16 Byte)
                aesAlg.IV = Encoding.Unicode.GetBytes("gitlab61");
                //加密器
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                //執行加密
                byte[] encrypted = encryptor.TransformFinalBlock(Encoding.Unicode.GetBytes(PlainText), 0,
                Encoding.Unicode.GetBytes(PlainText).Length);

                textBox2.Text=Convert.ToBase64String(encrypted);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

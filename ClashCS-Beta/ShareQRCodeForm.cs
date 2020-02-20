using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClashCS
{
    public partial class Share : Form
    {
        public Share()
        {
            InitializeComponent();
        }

        private void Share_QRCode_Load(object sender, EventArgs e)
        {
            string link = "vmess://qwertyuiopasdfghjklzxcvbnmaaaaaaaaaaaaaaaaaaa1111111==";
            Bitmap bmp = QrEncoder.code(link, 5, 7, false);
            pictureBox1.Image = bmp;
            textBox1.Text = link;
        }
    }
}

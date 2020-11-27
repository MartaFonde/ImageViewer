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

namespace ImageViewer
{
    public partial class Form2 : Form
    {
        public string Path { set; get; }
        public Form2(string path)
        {
            InitializeComponent();
            this.Path = path;
            pictureBox1.Image = new Bitmap(Path);
            this.ClientSize = new System.Drawing.Size(pictureBox1.Image.Size.Width, pictureBox1.Image.Size.Height);
            FileInfo file = new FileInfo(Path);
            this.Text = file.Name;
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = this.ClientSize.Width;
            pictureBox1.Height = this.ClientSize.Height;

        }
    }
}

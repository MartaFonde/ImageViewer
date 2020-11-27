using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quieres salir", "ImageVisor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath;

            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Title = "Select image";
                op.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE");
                op.Filter = "jpg (*.jpg)|*.jpg|png (*.png)|*.png|All files (*.*)|*.*";

                if (op.ShowDialog() == DialogResult.OK)
                {
                    filePath = op.FileName;
                    if (filePath.EndsWith(".jpg") || filePath.EndsWith(".png"))
                    {
                        if (abrirImagen(filePath))
                        {
                            Form2 f2 = new Form2(filePath);
                            if (checkBox1.Checked)
                            {
                                f2.ShowDialog();     //modal
                            }
                            else
                            {
                                f2.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Archivo no válido. Selecciona una imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool abrirImagen(string path)
        {
            try
            {
                Image i = Image.FromFile(path);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is OutOfMemoryException)
            {
                MessageBox.Show("Archivo no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}

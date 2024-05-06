using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navigator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*
            
            //
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select file";
            openFileDialog1.InitialDirectory = @"E:\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                MessageBox.Show("test");
            }
            //
            string[] filePaths = System.IO.Directory.GetFiles(@"E:\camerastuff\");
            string path = filePaths[0];
            System.Diagnostics.Process photoViewer = new System.Diagnostics.Process();
            photoViewer.StartInfo.FileName = $@"{path}";
            photoViewer.StartInfo.Arguments = $@"{path}";
            photoViewer.Start();

            for (int i = 0; i < filePaths.Length; i++)
            {
                path = filePaths[i];
                //MessageBox.Show(System.IO.Path.GetFileName(path));
            }
            */

            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}

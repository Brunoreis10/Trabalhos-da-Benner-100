using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace votando
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idade = 16;
            bool brasileira = true;

            bool podeVotar = (brasileira) && (idade >= 16);

            if (podeVotar)
            {
                MessageBox.Show("Esta pessoa está apta para voto.");
            }
            else
            {
                MessageBox.Show("Esta pessoa não pode votar.");
            }
        }
    }
}

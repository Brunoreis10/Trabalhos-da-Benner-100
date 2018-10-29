using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculoImposto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double valorDaNotaFiscal = 1000;

            if (valorDaNotaFiscal < 1000) MessageBox.Show("Imposto de 2%. Valor final = " + (valorDaNotaFiscal * 1.02));
            else if ((valorDaNotaFiscal >= 1000) && (valorDaNotaFiscal < 3000)) MessageBox.Show("Imposto de 2,5%. Valor final = " + (valorDaNotaFiscal * 1.025));
            else if ((valorDaNotaFiscal >= 3000) && (valorDaNotaFiscal < 7000)) MessageBox.Show("Imposto de 2,8%. Valor final = " + (valorDaNotaFiscal * 1.028));
            else if (valorDaNotaFiscal >= 7000) MessageBox.Show("Imposto de 3%. Valor final = " + (valorDaNotaFiscal * 1.03));
        }
    }
}

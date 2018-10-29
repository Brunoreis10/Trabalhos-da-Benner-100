using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula5MaoNaMassa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 15;
            bool portresouquatro = (n % 3 == 0) || (n % 4 == 0);
            string mensagem = portresouquatro ? n+" é divisível por 3 ou 4. " : n+" não é divisível por 3 ou 4. ";
            MessageBox.Show(mensagem);

            mensagem = "Divisíveis por 3 ou 4: ";
            for (int i = 0; i <= 30; i++)
            {
                portresouquatro = (i % 3 == 0) || (i % 4 == 0);
                if (portresouquatro) mensagem += i+" ";
            }
            MessageBox.Show(mensagem + ".");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int soma = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0) continue;
                else soma += i;

                //Solução professor - mais eficiente:
                //if (i % 3 != 0) soma += i;
            }

            MessageBox.Show("Soma = " + soma);
        }
    }
}

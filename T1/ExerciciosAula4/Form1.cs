using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciciosAula4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1, soma = 0;
            do
            {
                soma += i;
                i++;
            } while (i <= 1000);
            MessageBox.Show("soma = " + soma);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string m3 = "Múltiplos de 3 entre 1 e 100: ";
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    m3 += i+" ";
                }
            }
            MessageBox.Show(m3+".");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int fatorial;
            for (int n = 1; n <= 10; n++)
            {
                fatorial = 1;
                for (int i = n; i >= 1; i--)
                {
                    fatorial *= i;
                }
                MessageBox.Show(n + "! = " + fatorial);
            }

            //Solução professor:

            //int fatorial = 1;
            //for (int n = 1; n <= 10; n++)
            //{
            //    fatorial = fatorial * n;
            //    MessageBox.Show("fatorial(" + n + ") = " + fatorial);
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = 1, n_1 = 0, temp; string fibonacci = null;
            while (n <= 100)
            {
                fibonacci += n + " ";
                temp = n;
                n += n_1;
                n_1 = temp;
            }
            MessageBox.Show(fibonacci + ".");

            //Obs.: Professor usou exatamente a mesma lógica, porém atentar aos nomes de variáveis.
            //No meu caso, ficaram pouco claros.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = 10; string tabela = null;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    tabela += i*j + " ";
                }
                tabela += "\n";
            }
            MessageBox.Show(tabela);

            //Novamente, a lógica de resolução foi a mesma, porém os nomes de variáveis não são claros.
        }

        
    }
}

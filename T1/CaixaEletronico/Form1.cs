using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numeroDaConta = 1101;
            double saldo = 100.0;
            double valor = 10.0;

            bool podeSacar = (valor <= saldo) && (valor > 0);

            if (podeSacar)
            {
                saldo -= valor;
                MessageBox.Show("Saque realizado.");
                MessageBox.Show("O saldo atual da conta " + numeroDaConta + " é: R$" + saldo);
            }
            else
            {
                MessageBox.Show("Saldo insuficiente.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idadeJao = 22;
            int idadeMae = 44;
            int idadeNana = 25;
            /*
             * Idade do João;
             * idade da Mãe e
             * idade da Nana.
             */
            MessageBox.Show("Média = " + (float)(idadeJao + idadeMae + idadeNana) / 3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string H = "hello";
            string W = "world";
            //Concatena Strings
            string HW = H + " " + W + "!!";
            MessageBox.Show(HW);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double pi = 3.14;
            int piQuebrado = (int)pi;
            MessageBox.Show("piQuebrado = " + piQuebrado);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = 12;
            int c = -13;
            double delta, a1, a2;

            delta = (b * b) - (4 * a * c);
            a1 = (-b + Math.Sqrt(delta)) / (2 * a);
            a2 = (-b - Math.Sqrt(delta)) / (2 * a);

            MessageBox.Show("a1 = " + a1 + " | a2 = " + a2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double valorInvestido = 2000.0;
            /* ESTRUTURA FOR:
            for (int i = 1; i <= 12; i++)
            {
                valorInvestido *= 1.01;
            }
            MessageBox.Show("Seu investimento vale atualmente: R$" + valorInvestido);*/
            int i = 1;
            //ESTRUTURA WHILE:
            while (i <= 12)
            {
                valorInvestido *= 1.01;
                i++;
            }
            MessageBox.Show("Seu investimento vale atualmente: R$" + valorInvestido);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Conta Conta1 = new Conta();
            Conta1.numero = 1;
            Conta1.saldo = 1500.0;
            Conta1.titular = "José da Silva";

            Conta Conta2 = new Conta();
            Conta2.numero = 2;
            Conta2.saldo = 2000.0;
            Conta2.titular = "Fulano de Tal";

            MessageBox.Show("Titular = " + Conta2.titular);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Conta contanova = new Conta();
            contanova.titular = "Dylan Rodrigues";
            contanova.saldo = 10000.5;
            contanova.numero = 3;
            contanova.cpf = "096.387.469-12";
            contanova.agencia = 12345;

            MessageBox.Show("CPF = "+ contanova.cpf + "\nAgência = " + contanova.agencia);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Conta joaozinho = new Conta();
            Conta maria = new Conta();

            joaozinho.titular = "Joãozinho";
            joaozinho.saldo = 1300;
            
            maria.titular = "Maria";
            maria.saldo = 1700;
            
            maria.Transfere(200, joaozinho);

            MessageBox.Show("Novo saldo de " + maria.titular + ": R$" + maria.saldo + ".\nNovo saldo de " + joaozinho.titular + ": R$" + joaozinho.saldo + ".");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Conta mariainvestidora = new Conta();
            mariainvestidora.titular = "Maria Aparecida";
            mariainvestidora.saldo = 1000;
            //ToString("n2") = Método double para formatar com 2 casas decimais e separador de milhar.
            MessageBox.Show("Saldo atual de " + mariainvestidora.titular + ": R$" + mariainvestidora.saldo.ToString("n2") 
                + ".\nRendimento anual previsto: R$" + mariainvestidora.RendimentoAnual().ToString("n2") + ".");
        }
    }
}

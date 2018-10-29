using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronicoV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta novaconta = new Conta();
            Cliente novocliente = new Cliente();

            novaconta.Titular = novocliente;

            novocliente.Rg = "6653359";

            novaconta.Titular.Cpf = "096.387.469-12";

            novaconta.Deposita(10000.0);

            MessageBox.Show("RG: " + novocliente.Rg + "\nCPF: " + novaconta.Titular.Cpf);
            //Tanto novaconta.cliente.<campo> quanto cliente.<campo> referenciam o MESMO objeto.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente("Cliente Genérico");
            cliente.Idade = 17;
            MessageBox.Show(cliente.MaiordeIdade ? "É maior de idade." : "É menor de idade."); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cliente umCliente = new Cliente("Cliente Genérico");
            umCliente.Idade = 18;

            Conta umaConta = new Conta();
            umaConta.Titular = umCliente;
            umaConta.Deposita(1000.0);

            MessageBox.Show(umaConta.Saca(350.0) ? "Saque realizado com sucesso.\nNovo saldo: R$" 
                + umaConta.Saldo.ToString("n2") 
                : "Saldo insuficiente para o saque.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cliente maisUmCliente = new Cliente() { Rg = "6653359", Cpf = "096.387.469-12" };
            MessageBox.Show("RG: " + maisUmCliente.Rg + "\nCPF: " + maisUmCliente.Cpf);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Benner.AplicacaoCaixaEletronico.Contas;
using Benner.AplicacaoCaixaEletronico.Processamento;
using Benner.AplicacaoCaixaEletronico.Usuario;
using Benner.AplicacaoCaixaEletronico.Excecoes;

namespace Benner.AplicacaoCaixaEletronico
{
    public partial class AppCaixaEletronico : Form
    {
        //Conta conta = new Conta();
        //Cliente cliente = new Cliente("Victor");
        //Correção professor - só precisa declarar o atributo, não é necessário inicializá-lo:
        private Banco banco;
        private Cliente cliente;
        private Conta conta;
        private ContaPoupanca contaPoupanca;

        //Correção professor, para evitar repetição de códigos, cria-se o método AtualizaTexto()
        private void AtualizaTexto()
        {
            textoTitular.Text = banco.Contas[comboContas.SelectedIndex].Titular.ToString();
            textoNumero.Text = banco.Contas[comboContas.SelectedIndex].Numero.ToString();
            textoSaldo.Text = "R$" + banco.Contas[comboContas.SelectedIndex].Saldo.ToString("n2");

            //Deprecado - Código de exercícios anteriores:
            //textoTitular.Text = conta.Titular.Nome;
            //textoSaldo.Text = conta.Saldo.ToString("n2");
            //textoNumero.Text = conta.Numero.ToString();
        }

        public AppCaixaEletronico()
        {
            InitializeComponent();
        }

        private void AppCaixaEletronico_Load(object sender, EventArgs e)
        {
            cliente = new Cliente("Padrão");
            cliente.Idade = 17;
            conta = new ContaCorrente(cliente);

            conta.Titular.Idade = 15;
            conta.Deposita(250.0);
            conta.Numero = 1;

            banco = new Banco();
            banco.Contas.Add(conta);

            comboContas.Items.Add(banco.Contas[0].Titular.Nome);
            destinoDaTransferencia.Hide();
            button7.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                banco.Contas[comboContas.SelectedIndex].Deposita(Convert.ToDouble(textoValor.Text));
                //textoSaldo.Text = conta.Saldo.ToString("n2");
                this.AtualizaTexto();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show("Selecione uma conta!");
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Informe o valor.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                banco.Contas[comboContas.SelectedIndex].Saca(Convert.ToDouble(textoValor.Text));
                this.AtualizaTexto();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show("Valor inválido.");
            }
            catch (SaldoInsuficienteException exception)
            {
                MessageBox.Show("Saldo insuficiente.");
            }
            catch (SaqueMenorDeIdadeException exception)
            {
                MessageBox.Show("Valor acima do limite para menores de idade.");
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Informe um valor.");
            }
            finally
            {
                textoValor.Text = null;
            }
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AtualizaTexto();
            if (banco.Contas.Count > 1)
            {
                destinoDaTransferencia.Show();
                button7.Show();
                destinoDaTransferencia.Items.Clear();
                for (int i = 0; i < banco.Contas.Count; i++)
                {
                    if (!banco.Contas[i].Equals(banco.Contas[comboContas.SelectedIndex]))
                    {
                        destinoDaTransferencia.Items.Add(banco.Contas[i].Titular.Nome);
                    }
                }
            }
            else if (banco.Contas.Count <= 1)
            {
                destinoDaTransferencia.Hide();
                button7.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                bool temalvo = false; int i;
                for (i = 0; i < banco.Contas.Count; i++)
                {
                    if (banco.Contas[i].Titular.Nome.Equals(destinoDaTransferencia.Text))
                    {
                        temalvo = true;
                        break;
                    }
                }
                if (temalvo)
                {
                    banco.Contas[comboContas.SelectedIndex].Transfere(Convert.ToDouble(textoValor.Text), banco.Contas[i]);
                    AtualizaTexto();
                }
                else MessageBox.Show("Selecione uma conta alvo!");
                
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Informe um valor.");
            }
            catch (SaldoInsuficienteException exception)
            {
                MessageBox.Show("Saldo insuficiente.");
            }
        }

        private void botaoTotalContas_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Conta.TotalDeContas + " contas criadas. \nPróxima conta: " + Conta.ProximaConta() + ".");
        }

        private void botaoToString_Click(object sender, EventArgs e)
        {
            foreach (Conta conta in banco.Contas)
            {
                MessageBox.Show(conta.ToString());
            }
        }

        public void AdicionaConta(Conta conta)
        {
            //DEPRECADO - Antiga rotina para arrays:
            //if (banco.Contas.Length <= Conta.TotalDeContas)
            //{
            //    Banco novo = new Banco(Conta.TotalDeContas * 3);
            //    for (int i = 0; i < banco.Contas.Length; i++) novo.Contas[i] = this.banco.Contas[i];
            //    banco = novo;
            //}
            //banco.Contas[Conta.TotalDeContas-1] = conta;
            banco.Adiciona(conta);
            comboContas.Items.Add(conta.Titular.Nome);
            destinoDaTransferencia.Items.Add(conta.Titular.Nome);
            comboContas.SelectedIndex = comboContas.Items.Count - 1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CadastroDeContas cadastro = new CadastroDeContas(this);
            cadastro.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                banco.Remove(banco.Contas[comboContas.SelectedIndex]);
                comboContas.Items.Remove(comboContas.SelectedItem);
                this.LimpaTextos();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show("Selecione uma conta!");
            }
        }

        private void LimpaTextos()
        {
            this.comboContas.SelectedIndex = -1;
            this.destinoDaTransferencia.SelectedIndex = -1;
            this.textoNumero.ResetText();
            this.textoSaldo.ResetText();
            this.textoTitular.ResetText();
            this.textoValor.ResetText();
        }

        private void botaoExemplos_Click(object sender, EventArgs e)
        {
            ExemplosAula exemplos = new ExemplosAula();
            exemplos.ShowDialog();
        }
    }
}

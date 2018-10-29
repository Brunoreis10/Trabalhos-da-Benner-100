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

namespace Benner.AplicacaoCaixaEletronico
{
    public partial class ExemplosAula : Form
    {
        //Conta conta = new Conta();
        //Cliente cliente = new Cliente("Victor");
        //Correção professor - só precisa declarar o atributo, não é necessário inicializá-lo:
        private Banco banco;
        private Cliente cliente;
        private Conta conta;
        private ContaPoupanca contaPoupanca;

        public ExemplosAula()
        {
            InitializeComponent();
        }

        private void botaoHashSet_Click(object sender, EventArgs e)
        {
            //Exemplo HashSet - Lista sem valores repetidos e sem índices:
            var hashset = new HashSet<Conta>();

            hashset.Add(this.conta);
            hashset.Add(this.conta);
            hashset.Add(this.conta);
            hashset.Add(this.conta);
            hashset.Add(this.conta);
            //Verifica a igualdade de cada novo elemento usando o método Equals();

            foreach (var conta in hashset)
            {
                MessageBox.Show(hashset.Count + " item: \n" + conta.ToString());
            }
        }

        private void botaoSortedSet_Click(object sender, EventArgs e)
        {
            //Listas (HashSets) ordenadas:
            var sortedlist = new SortedSet<int>() { 5, 3, 7, 9, 4 };

            foreach (int numero in sortedlist)
            {
                MessageBox.Show(numero.ToString());
            }
        }

        private void botaoDicionario_Click(object sender, EventArgs e)
        {
            //Dicionários, associam CHAVE com VALOR:
            Dictionary<string, int> dicio = new Dictionary<string, int>();
            dicio.Add("Exemplo", 13);

            int numero = dicio["Exemplo"];

            MessageBox.Show(numero.ToString());

            foreach (KeyValuePair<string, int> i in dicio)
            {
                MessageBox.Show(i.Key + "->" + i.Value);
            }
        }

        private void botaoSortedDicio_Click(object sender, EventArgs e)
        {
            //Dicionário ordenado:
            SortedDictionary<string, string> dicio_ordenado = new SortedDictionary<string, string>();
            dicio_ordenado.Add("Maria", "João");
            dicio_ordenado.Add("Afonso", "Rosângela");
            dicio_ordenado.Add("Adilson", "Letícia");

            foreach (var i in dicio_ordenado)
            {
                MessageBox.Show(i.Key + " " + i.Value);
            }
        }

        private void botaoEquals_Click(object sender, EventArgs e)
        {
            Cliente cliente1 = new Cliente("João");
            cliente1.Rg = "1.234.568";
            Cliente cliente2 = new Cliente("Maria");
            cliente2.Rg = "1.234.567";
            MessageBox.Show(cliente1.Equals(cliente2) ? "Clientes iguais!" : "Clientes diferentes.");
        }

        private void botaoInterfaces_Click(object sender, EventArgs e)
        {
            ContaPoupanca cp = new ContaPoupanca(new Cliente());
            cp.Deposita(100);
            ContaInvestimento ci = new ContaInvestimento(new Cliente());
            ci.Deposita(203);
            SeguroDeVida sv = new SeguroDeVida();

            GerenciadorDeImposto gerenciador = new GerenciadorDeImposto();
            gerenciador.Adiciona(cp);
            gerenciador.Adiciona(ci);
            gerenciador.Adiciona(sv);

            //gerenciador.Adiciona(new ContaCorrente(new Cliente())); 
            //^ Não compila, pois ContaCorrente não é ITributavel!

            MessageBox.Show("Total de impostos: R$" + gerenciador.Total.ToString("n2") + ".");
        }

        private void botaoBanco_Click(object sender, EventArgs e)
        {
            Banco banco = new Banco();

            for (int i = 0; i < 10; i++)
            {
                banco.Adiciona(new ContaCorrente(new Cliente()));
                banco.Contas[i].Deposita((i + 1) * 1000);
            }

            foreach (Conta conta in banco.Contas) MessageBox.Show(conta.Saldo.ToString("n2"));
        }

        private void botaoSaqueCP_Click(object sender, EventArgs e)
        {
            this.contaPoupanca.Titular.Idade = 20;
            this.contaPoupanca.Deposita(100);
            MessageBox.Show("Saldo após depósito: R$" + contaPoupanca.Saldo.ToString("n2"));
            this.contaPoupanca.Saca(10);
            MessageBox.Show("Saldo após saque: R$" + contaPoupanca.Saldo.ToString("n2"));
        }

        private void botaoPolim_Click(object sender, EventArgs e)
        {
            //POLIMORFISMO: Método Adiciona da classe TotalizadorDeContas recebe uma Conta de referência
            //Porém aceita também ContaPoupanca e ContaCorrente, por serem filhas de Conta.

            TotalizadorDeContas totalizador = new TotalizadorDeContas();

            Conta c = new ContaCorrente(this.cliente);
            c.Deposita(100);
            totalizador.Adiciona(c);
            ContaPoupanca cp = new ContaPoupanca(this.cliente);
            cp.Deposita(200);
            totalizador.Adiciona(cp);
            ContaCorrente cc = new ContaCorrente(this.cliente);
            cc.Deposita(300);
            totalizador.Adiciona(cc);

            MessageBox.Show("Saldo total: R$" + totalizador.SaldoTotal.ToString("n2"));

        }

        private void botaoArrays_Click(object sender, EventArgs e)
        {
            Cliente generico = new Cliente("Genérico");
            Conta[] contas = new Conta[10]; // <- Arrays em C# - Sintaxe.

            contas[0] = new ContaCorrente(generico);            //
            contas[1] = new ContaPoupanca(generico);    // POLIMORFISMO se aplica.
            contas[2] = new ContaCorrente(generico);    //

            int i;

            for (i = 3; i < 10; i++) contas[i] = new ContaCorrente(generico); // <- Populando array automaticamente.

            //MÉTODOS PARA PERCORRER:

            for (i = 0; i < contas.Length; i++) // <- .Length retorna o tamanho da array.
            {
                contas[i].Deposita((i + 1) * 100);
            }

            //ou FOREACH:
            i = 0;
            foreach (Conta conta in contas)
            {
                i++;
                MessageBox.Show("Saldo da conta " + i + ": R$" + conta.Saldo.ToString("n2"));
            }

            int[] listadeInteiros = new int[] { 1, 2, 3, 4, 5, 6, 7 }; // Auto implementa uma array!!! Atalho C#
        }

        private void ExemplosAula_Load(object sender, EventArgs e)
        {
            //VARIÁVEIS IMPLÍCITAS - Tipo "var":
            var tamanho = 5; // <- Inteira;
            var nome = "teste"; // <- String;
            var umcliente = new Cliente(); // <- Funciona com objetos
                                           //var qualquer;    <- NÃO COMPILA | Pois a variável implícita requer atribuição de valor 
                                           //var nula = null; <- NÃO COMPILA | na declaração.

            cliente = new Cliente("Padrão");
            cliente.Idade = 17;
            conta = new ContaCorrente(cliente);

            this.contaPoupanca = new ContaPoupanca(new Cliente("Cliente Poupança"));
            

            conta.Titular.Idade = 15;
            conta.Deposita(250.0);
            conta.Numero = 1;

            //comboContas.DisplayMember = "Nome";
            //destinoDaTransferencia.DisplayMember = "Nome";

            banco = new Banco();
            banco.Contas.Add(conta);
            banco.Contas.Add(contaPoupanca);
        }

        private void botaoToString_Click(object sender, EventArgs e)
        {
            foreach (Conta conta in banco.Contas)
            {
                MessageBox.Show(conta.ToString());
            }
        }

        private void buttonStrings_Click(object sender, EventArgs e)
        {
            string exemplo = "Esta é " + "uma frase";
            exemplo += "! ";
            int nro = 22;
            exemplo += nro;

            MessageBox.Show(exemplo);

            string nome = "Dylan";
            exemplo = String.Format("{0} tem {1} anos de idade.", nome, nro);

            MessageBox.Show(exemplo);

            string cidade = "Blu,me,nau";

            string[] silabas = cidade.Split(',');

            foreach (string silaba in silabas)
            {
                MessageBox.Show(silaba);
            }

            exemplo = "maiúsculas!!11!!";

            exemplo = exemplo.ToUpper();

            MessageBox.Show(exemplo);

            exemplo = exemplo.Replace("1", "2");

            MessageBox.Show(exemplo);

            exemplo = "Fulano de Tal";

            nome = exemplo.Substring(0, 6);

            MessageBox.Show(nome + "\nEspaço na posição: " + exemplo.IndexOf(" ").ToString());

            string sobrenome = exemplo.Substring(exemplo.IndexOf("d"));

            MessageBox.Show(sobrenome);
        }

        private Conta ContaComSaldo(double saldo)
        {
            Conta c = new ContaCorrente(new Cliente("Genérico"));
            c.Deposita(saldo);
            return c;
        }

        private void buttonLinqLambda_Click(object sender, EventArgs e)
        {
            var contas = new List<Conta>();

            contas.Add(ContaComSaldo(2001));
            contas.Add(ContaComSaldo(2800));
            contas.Add(ContaComSaldo(1800));
            contas.Add(ContaComSaldo(4000));
            contas.Add(ContaComSaldo(200));

            var filtradas = from c in contas
                            where c.Saldo > 2000
                            select c;
            //               ^ LINQ = Uma espécie de comando de banco dentro de listas diretamente no código.
            foreach (Conta c in filtradas)
            {
                MessageBox.Show("R$" + c.Saldo.ToString("n2"));
            }

            double somaSaldo = filtradas.Sum(c => c.Saldo);
            //                               ^ LAMBDA = Função que aponta (=>) um atributo de um elemento.
            MessageBox.Show("Total: R$" + somaSaldo.ToString("n2"));

            MessageBox.Show("Menor: R$" + contas.Min(c => c.Saldo).ToString("n2"));

            MessageBox.Show("Maior: R$" + contas.Max(c => c.Saldo).ToString("n2"));

            //var filtrados = lista.Where(c => c.Numero < 1000 && c.Saldo > 5000.0);
            //                     ^ Método que seleciona listas        ^ Exemplo de Lambda.

            MessageBox.Show(contas.Count(c => c.Saldo > 2000) + " contas com saldo maior que R$2000,00.");

            //PROJEÇÃO - Criando novo objeto na seleção apenas com atributos que queremos:
            var nomeagenciafiltro = from c in contas
                                    where c.Saldo > 2000
            /* Cria novo objeto:*/  select new { c.Titular.Nome, c.Agencia };

            foreach (var c in nomeagenciafiltro)
            {
                MessageBox.Show("Nome: " + c.Nome + "\nAgência: " + c.Agencia);
            }

            //LINQ + Arrays:
            int[] nros = { 1, 20, 3, 87, 4, 9, 11 };

            MessageBox.Show(nros.Where(x => x > 10).Count() + " números maiores que 10 nesta array."
                            + "\nSoma: " + nros.Where(x => x > 10).Sum());

            //orderby em LINQ:
            var ordenadasPorSaldoDesc = from c in contas
                                         where c.Saldo > 2000//, c.Numero <- Se adicionarmos outros critérios por virgula, 
                                                                           //serão utilizados em caso de igualdade no primeiro.
                                                            // ^ Alternativa em método: contas.Orderby(crit1).ThenBy(crit2);
                                         orderby c.Saldo descending
                                         select c;
            //Alternativa - WHERE e ORDERBY em Métodos:
            ordenadasPorSaldoDesc = contas.Where(c => c.Saldo > 2000).OrderByDescending(c => c.Saldo);

            foreach (var c in ordenadasPorSaldoDesc)
            {
                MessageBox.Show(c.Saldo.ToString("n2"));
            }
        }

        private void buttonExtMethods_Click(object sender, EventArgs e)
        {
            MessageBox.Show("palavra".Pluralizar() + " " + "testes".Pluralizar());
            //                          ^ Criado na classe StringUtils.cs!

            MessageBox.Show(2.Somar(3).ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Builder.Exemplo___Nota_Fiscal
{
    public class NotaFiscal
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataDeEmissao { get; private set; }
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public IList<ItemDaNota> Itens { get; private set; }
        public String Observavoes { get; private set; }

        public NotaFiscal(string razaoSocial, 
            string cnpj, 
            DateTime dataDeEmissao, 
            double valorBruto, 
            double impostos, 
            IList<ItemDaNota> itens, 
            string observavoes)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            DataDeEmissao = dataDeEmissao;
            ValorBruto = valorBruto;
            Impostos = impostos;
            Itens = itens;
            Observavoes = observavoes;
        }
    }
}

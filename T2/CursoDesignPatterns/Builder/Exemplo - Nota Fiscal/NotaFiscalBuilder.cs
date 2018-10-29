using CursoDesignPatterns.Observer.Exemplo___Ações_Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Builder.Exemplo___Nota_Fiscal
{
    public class NotaFiscalBuilder
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public double ValorTotal { get; private set; }
        public double Impostos { get; private set; }
        public String Observavoes { get; private set; }

        private IList<ItemDaNota> itens = new List<ItemDaNota>();
        private DateTime DataDeEmissao = DateTime.Now;
        private IList<IAcaoAposGerarNota> acoes = new List<IAcaoAposGerarNota>();

        public NotaFiscalBuilder() { }

        public NotaFiscalBuilder(IList<IAcaoAposGerarNota> acoes)
        {
            this.acoes = acoes;
        }

        public NotaFiscalBuilder ParaEmpresa(string razaoSocial)
        {
            RazaoSocial = razaoSocial;
            return this;
        }
        public NotaFiscalBuilder ComCnpj(string cnpj)
        {
            Cnpj = cnpj;
            return this;
        }
        public NotaFiscalBuilder NaData(DateTime data)
        {
            DataDeEmissao = data;
            return this;
        }
        public NotaFiscalBuilder Com(ItemDaNota item)
        {
            itens.Add(item);
            ValorTotal += item.Valor;
            Impostos += item.Valor * 0.05;
            return this;
        }
        public NotaFiscalBuilder ComObservacao(string observacao)
        {
            Observavoes = observacao;
            return this;
        }
        public NotaFiscalBuilder ComAcaoPosterior(IAcaoAposGerarNota acao)
        {
            acoes.Add(acao);
            return this;
        }
        public NotaFiscal Constroi()
        {
            var nf = new NotaFiscal(RazaoSocial, Cnpj, DataDeEmissao, ValorTotal, Impostos, itens, Observavoes);
            foreach (var acao in acoes)
            {
                acao.Executa(nf);
            }
            return nf;
        }
    }
}

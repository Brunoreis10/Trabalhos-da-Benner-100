using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public IList<ProdutosDaVenda> Produtos { get; set; }

        public FormaDePagamento FormaDePagamento { get; set; }
        public int? FormaDePagamentoId { get; set; }

        public Pessoa Pessoa { get; set; }
        public int? PessoaId { get; set; }

        public Usuario Usuario { get; set; }
        public int? UsuarioId { get; set; }

        [Range(1,int.MaxValue)]
        public double ValorTotal { get; set; }

        public DateTime Data { get; set; }

        public int Parcelas { get; set; }

        public DateTime Previsao { get; set; }

        public string Observacao { get; set; }

        public DateTime DataEntregaRecarga { get; set; }

        public int TipoVenda { get; set; }

        public int? DescontoPorcento { get; set; }
        public double DescontoValorFixo { get; set; }

        public Venda()
        {
            Produtos = new List<ProdutosDaVenda>();
        }

        public Venda ProcessaDesconto()
        {
            if (DescontoPorcento > 0)
                ValorTotal -= (ValorTotal * (int)DescontoPorcento) / 100;
            else if (DescontoValorFixo > 0)
                ValorTotal -= DescontoValorFixo;
            return this;
        }
    }
}
using CursoDesignPatterns2.Adapter.Exemplo___XML_Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Facades_e_Singletons.Exemplo___Fachada_Empresa
{
    public class EmpresaFacade
    {
        //Simulação de regras de negócio de um sistema (métodos fake)
        //A classe Facade isola as lógicas, métodos e classes específicas.
        public void BuscaCliente(string cpf)
        {
            //return new ClienteDAO().BuscaPorCpf(cpf);
        }

        public void CriaFatura(Cliente cliente, double valor)
        {
            //Fatura fatura = new Fatura(cliente, valor);
            //return fatura;
        }

        public void GeraCobranca()
        {
            //Cobranca cobranca = new Cobranca(Tipo.Boleto, fatura);
            //cobranca.Emite();
            //return cobranca;
        }

        public void FazContato()
        {
            //ContatoCliente contato = new ContatoCliente(cliente, cobranca);
            //contato.Dispara();
            //return contato;
        }
    }
}

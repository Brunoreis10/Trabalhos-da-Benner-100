using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Memento.Exemplo___Contratos
{
    public class Contrato
    {
        public DateTime Data { get; private set; }
        public string Cliente { get; private set; }
        public TipoContrato Tipo { get; private set; }

        public Contrato(DateTime data, string cliente, TipoContrato tipo)
        {
            Data = data;
            Cliente = cliente;
            Tipo = tipo;
        }

        public void Avanca()
        {
            if (Tipo == TipoContrato.Novo) Tipo = TipoContrato.EmAndamento;
            else if (Tipo == TipoContrato.EmAndamento) Tipo = TipoContrato.Acertado;
            else if (Tipo == TipoContrato.Acertado) Tipo = TipoContrato.Concluido;
        }

        public Estado SalvaEstado()
        {
            return new Estado(new Contrato(Data, Cliente, Tipo));
        }
    }
}

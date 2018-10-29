namespace Alura.Loja.Testes.ConsoleApp
{
    public class Endereco
    {
        public string Logradouro { get; internal set; }
        public string Numero { get; internal set; }
        public string Complemento { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public Cliente Cliente { get; internal set; }
        public override string ToString()
        {
            return $"{Logradouro}, {Numero}. ({Complemento}) - {Bairro} - {Cidade}";
        }
    }
}
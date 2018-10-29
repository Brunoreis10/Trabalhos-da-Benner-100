<Query Kind="Program" />

void Main()
{
	var controller = new CambioController();

	var bindingFlags = 	BindingFlags.Instance | 
						BindingFlags.Static | 
						BindingFlags.Public | 
						BindingFlags.DeclaredOnly;
	
	var metodos = controller.GetType().GetMethods(bindingFlags);
	var argumentos = new string[] { "moedaOrigem", "moedaDestino", "valor" };
	var argumentosCount = argumentos.Length;
	var nomeAction = "Calculo";
	var sobrecargas = metodos.Where(m => m.Name.Equals(nomeAction));
	
	sobrecargas.Dump();
	
	foreach (var sobrecarga in sobrecargas)
	{
		var parametros = sobrecarga.GetParameters();
		
		if (argumentosCount != parametros.Length) continue;
		
		var argumentosBatem = parametros.All(p => argumentos.Contains(p.Name));
		
		if (argumentosBatem)
		{
			sobrecarga.Dump();
			break;
		}
	}
}

// Define other methods and classes here
public class CambioController 
{
    public string MXN() => null;

    public string USD() => null;
		
    public string Calculo() => null;
	
	public string Calculo(string moedaOrigem, string moedaDestino, decimal valor) => null;

    public string Calculo(string moedaDestino, decimal valor) => Calculo("BRL", moedaDestino, valor);
}
namespace FastFood.Atendimento.Domain.Pedidos.ValueObjects;

public sealed record Dinheiro
{
    private const string MoedaBrasileira = "BRL";
    
    private Dinheiro(decimal valor, string moeda)
    {
        Valor = valor;
        Moeda = moeda;
    }

    public decimal Valor { get; }
    public string Moeda { get; }

    public static Dinheiro Criar(decimal valor)
    {
        return new(valor, MoedaBrasileira);
    }
}
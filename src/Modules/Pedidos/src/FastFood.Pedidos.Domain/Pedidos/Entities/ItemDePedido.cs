using FastFood.Contracts.Abstractions;
using FastFood.Pedidos.Domain.Pedidos.Exceptions;
using FastFood.Pedidos.Domain.Pedidos.ValueObjects;

namespace FastFood.Pedidos.Domain.Pedidos.Entities;

public class ItemDePedido : AuditableEntity
{
    private ItemDePedido()
    {
    }
    
    private ItemDePedido(string nome, string descricao, Dinheiro preco, int quantidade, string? observacao)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Quantidade = quantidade;
        Observacao = observacao;
    }

    public Pedido Pedido { get; private set; }
    public Ulid PedidoId { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public Dinheiro Preco { get; private set; }
    public int Quantidade { get; private set; }
    public string? Observacao { get; private set; }

    public void SetPedido(Pedido pedido)
    {
        Pedido = pedido;
        PedidoId = pedido.Id;
    }
    
    public static ItemDePedido Criar(string nome, string descricao, Dinheiro preco, int quantidade, string? observacao = null)
    {
        if (quantidade <= 0)
            throw new ItemDePedidoDeveTerQuantidadeMaiorQueZeroDomainException();
        
        if(preco <= 0)
            throw new ItemDePedidoDeveTerPrecoMaiorQueZeroDomainException();
        
        return new ItemDePedido(nome, descricao, preco, quantidade, observacao);
    }
}
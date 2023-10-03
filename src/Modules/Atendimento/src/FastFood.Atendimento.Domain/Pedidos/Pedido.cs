using FastFood.Atendimento.Domain.Pedidos.Entities;
using FastFood.Atendimento.Domain.Pedidos.Events;
using FastFood.Atendimento.Domain.Pedidos.ValueObjects;
using FastFood.Atendimento.Domain.Pedidos.ValueObjects.Status;
using FastFood.SharedKernel;

namespace FastFood.Atendimento.Domain.Pedidos;

public sealed class Pedido : AggregateRoot
{
    private List<ItemDePedido> _itens = new();

    private Pedido()
    {
        Status = new PedidoCriado();
        RaiseDomainEvent(new PedidoCriadoDomainEvent(Id));
    }

    public StatusDePedido Status { get; private set; }
    public IReadOnlyCollection<ItemDePedido> Itens => _itens.ToList();
    public Cliente? Cliente { get; private set; } = null;
    public Cpf? Cpf { get; private set; } = null;

    public Pedido AdicionarItem(ItemDePedido item)
    {   
        _itens.Add(item);
        RaiseDomainEvent(new ItemDePedidoAdicionadoDomainEvent(Id, item.Id));
        
        return this;
    }

    public Pedido RemoverItem(ItemDePedido item)
    {
        _itens.Remove(item);
        RaiseDomainEvent(new ItemDePedidoRemovidoDomainEvent(Id, item.Id));

        return this;
    }

    public Pedido Cancelar()
    {
        Status.Cancelar(this);
        RaiseDomainEvent(new PedidoCanceladoDomainEvent(Id));
        
        return this;
    }
    
    public Pedido Confirmar()
    {
        Status.Confirmar(this);
        RaiseDomainEvent(new PedidoConfirmadoDomainEvent(Id));
        
        return this;
    }
    
    public Pedido Receber()
    {
        Status.Receber(this);
        return this;
    }
    
    public Pedido Preparar()
    {
        Status.Preparar(this);
        return this;
    }
    
    public Pedido MarcarComoPronto()
    {
        Status.Pronto(this);
        return this;
    }
    
    public Pedido Finalizar()
    {
        Status.Finalizar(this);
        RaiseDomainEvent(new PedidoFinalizadoDomainEvent(Id));
        
        return this;
    }

    internal void SetStatus(StatusDePedido status)
    {
        Status = status;
    }

    public Pedido SetCliente(Cliente cliente)
    {
        Cliente = cliente;
        return this;
    }
    
    public Pedido SetCpf(Cpf cpf)
    {
        Cpf = cpf;
        return this;
    }

    public static Pedido Criar() => new();
}
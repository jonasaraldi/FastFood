using FastFood.Contracts.Pedidos;
using FastFood.Pedidos.Domain.Pedidos;
using FastFood.Pedidos.Domain.Pedidos.Entities;
using FastFood.Pedidos.Domain.Pedidos.Exceptions;
using FastFood.Pedidos.Domain.Pedidos.ValueObjects;
using FastFood.Pedidos.Domain.Pedidos.ValueObjects.Status;

namespace FastFood.Pedidos.Tests.Domain.Status;

public class PedidoProntoTests
{
    [Fact]
    public void Cancelar_StatusPronto_NaoDeveMudarParaCancelado()
    {
        var pedido = PedidoPronto();
        Assert.Throws<TrocaDeStatusInvalidaDomainException>(() => pedido.Cancelar());
    }
    
    [Fact]
    public void Confirmar_StatusPronto_NaoDeveMudarParaConfirmado()
    {
        var pedido = PedidoPronto();
        Assert.Throws<TrocaDeStatusInvalidaDomainException>(() => pedido.Confirmar());
    }
    
    [Fact]
    public void Receber_StatusPronto_NaoDeveMudarParaRecebido()
    {
        var pedido = PedidoPronto();
        Assert.Throws<TrocaDeStatusInvalidaDomainException>(() => pedido.Receber());
    }
    
    [Fact]
    public void Preparar_StatusPronto_NaoDeveMudarParaEmPreparacao()
    {
        var pedido = PedidoPronto();
        Assert.Throws<TrocaDeStatusInvalidaDomainException>(() => pedido.Preparar());
    }
    
    [Fact]
    public void MarcarComoPronto_StatusPronto_NaoDeveMudarParaPronto()
    {   
        var pedido = PedidoPronto();
        Assert.Throws<TrocaDeStatusInvalidaDomainException>(() => pedido.MarcarComoPronto());
    }
    
    [Fact]
    public void Finalizar_StatusPronto_DeveMudarParaFinalizado()
    {
        var pedido = PedidoPronto();
        
        pedido.Finalizar();
        
        Assert.IsType<PedidoFinalizado>(pedido.Status);
        Assert.IsType<DomainEvents.PedidoFinalizado>(pedido.GetDomainEvents().LastOrDefault());
    }
    
    private Pedido PedidoPronto()
    {
        Pedido pedido = Pedido.Criar();
        ItemDePedido itemDePedido = ItemDePedido.Criar("Coca-cola", "Bebida", Dinheiro.Criar(5), 1);
        pedido.AdicionarItem(itemDePedido);

        return pedido.Confirmar().Receber().Preparar().MarcarComoPronto();
    }
}
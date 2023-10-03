using FastFood.SharedKernel;

namespace FastFood.Atendimento.Domain.Pedidos.Events;

public record ItemDePedidoRemovidoDomainEvent(Ulid PedidoId, Ulid ItemDePedidoId) : DomainEvent
{
}
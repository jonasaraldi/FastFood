﻿// <auto-generated />
using System;
using FastFood.Atendimento.Infrastructure.Persistence.Postgres.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FastFood.Atendimento.Infrastructure.Migrations
{
    [DbContext(typeof(AtendimentoDbContext))]
    partial class AtendimentoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Entities.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Entities.ItemDePedido", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PedidoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("ItemDePedido", (string)null);
                });

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Pedido", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ClienteId")
                        .HasColumnType("text");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Entities.Cliente", b =>
                {
                    b.OwnsOne("FastFood.Atendimento.Domain.Pedidos.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<string>("ClienteId")
                                .HasColumnType("text");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Entities.ItemDePedido", b =>
                {
                    b.HasOne("FastFood.Atendimento.Domain.Pedidos.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FastFood.Atendimento.Domain.Pedidos.ValueObjects.Dinheiro", "Preco", b1 =>
                        {
                            b1.Property<string>("ItemDePedidoId")
                                .HasColumnType("text");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("numeric")
                                .HasColumnName("Preco");

                            b1.HasKey("ItemDePedidoId");

                            b1.ToTable("ItemDePedido");

                            b1.WithOwner()
                                .HasForeignKey("ItemDePedidoId");
                        });

                    b.Navigation("Pedido");

                    b.Navigation("Preco")
                        .IsRequired();
                });

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Pedido", b =>
                {
                    b.HasOne("FastFood.Atendimento.Domain.Pedidos.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FastFood.Atendimento.Domain.Pedidos.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<string>("PedidoId")
                                .HasColumnType("text");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Cpf");

                            b1.HasKey("PedidoId");

                            b1.ToTable("Pedido");

                            b1.WithOwner()
                                .HasForeignKey("PedidoId");
                        });

                    b.Navigation("Cliente");

                    b.Navigation("Cpf");
                });

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("FastFood.Atendimento.Domain.Pedidos.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿using System.Data.Entity.ModelConfiguration;
using SampleLoja.Domain.Entidades;

namespace SampleLoja.Infra.Data.Map
{
   public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.Id);
           
            //Nome dos produtos
            Property(p => p.Nomeproduto)
                .IsRequired()
                .HasMaxLength(250);

            // passando os valores do produto
            Property(p => p.Valorproduto)
                .IsRequired();

            // referencia com o cliente, com varios produtos
            HasRequired(p => p.Cliente)
           .WithMany(c => c.Produtos) // tem muitos produtos
           .HasForeignKey(p => p.ClienteId);

            ToTable("produtos");
        }
    }
}

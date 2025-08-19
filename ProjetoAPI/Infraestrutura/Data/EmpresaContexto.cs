using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data
{
    public class EmpresaContexto: DbContext
    {
        public EmpresaContexto(DbContextOptions<EmpresaContexto> opcoes): base(opcoes) {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(builder =>
            {
                builder.Property(p => p.descricao).IsRequired().HasMaxLength(150);
                builder.ToTable("Categoria"); //Nome da tabela
                builder.HasKey(p => p.id); //Chave Primária
            });

            modelBuilder.Entity<Produto>(builder =>
            {
                builder.ToTable("Produto");
                builder.HasKey(p => p.id);
                builder.Property(p => p.descricao).IsRequired().HasMaxLength(150);
                builder.Property(p => p.valor).IsRequired().HasPrecision(8, 2);
                builder.Property(p => p.quantidade).IsRequired();
                builder.HasOne(p => p.Categoria).WithMany(p => p.produtos).HasForeignKey(p => p.idCategoria).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

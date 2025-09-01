using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data
{
    public class ContextoGerenciador: DbContext
    {
        public ContextoGerenciador(DbContextOptions options) : base(options) {
        }

        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<TipoTarefa> TipoTarefa { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>(builder =>
            {
                builder.Property(p => p.titulo).IsRequired().HasMaxLength(50);
                builder.Property(p => p.descricao).IsRequired().HasMaxLength(500);
                builder.ToTable("Tarefa");
                builder.HasKey(p => p.id);
                builder.HasOne(p => p.tipotarefa).WithMany(p => p.tarefas).HasForeignKey(p => p.idTipoTarefa).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TipoTarefa>(builder =>
            {
                builder.Property(p => p.nome).IsRequired().HasMaxLength(50);
                builder.ToTable("TipoTarefa");
                builder.HasKey(p => p.id);
            });

            modelBuilder.Entity<Login>(builder =>
            {
                builder.Property(p => p.usuario).IsRequired().HasMaxLength(50);
                builder.Property(p => p.senha).IsRequired().HasMaxLength(50);
                builder.ToTable("Usuarios");
                builder.HasKey(p => p.id);
            });
        }
    }
}

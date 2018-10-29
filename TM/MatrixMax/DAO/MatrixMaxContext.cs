using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MatrixMax.DAO
{
    public class MatrixMaxContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
        public DbSet<ProdutosDaVenda> ProdutosDaVenda { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProdutosDaVenda>()
                .HasKey(vp => new { vp.VendaId, vp.ProdutoId });

            modelBuilder
                .Entity<Endereco>()
                .Property<int>("PessoaId");

            modelBuilder
                .Entity<Endereco>()
                .HasKey("PessoaId");

            modelBuilder.Entity<Categoria>().HasOne(c => c.CategoriaDaSubcategoria)
                                   .WithMany()
                                   .HasForeignKey(c => c.CategoriaId);

            modelBuilder
                .Entity<Usuario>()
                .Property(u => u.Ativo)
                .HasDefaultValue(true);

            modelBuilder
                .Entity<Produto>()
                .Property(p => p.Ativo)
                .HasDefaultValue(true);

            modelBuilder
                .Entity<Categoria>()
                .Property(c => c.Ativo)
                .HasDefaultValue(true);

            modelBuilder
                .Entity<Marca>()
                .Property(m => m.Ativo)
                .HasDefaultValue(true);
        }

        public MatrixMaxContext()
        { }

        public MatrixMaxContext(DbContextOptions<MatrixMaxContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MMDB.mdf;Integrated Security=True");
        }

    }
}
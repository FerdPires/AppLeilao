using Leilao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leilao.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ItemLeilao> Leiloes { get; set; }
        public DbSet<UserAccount> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemLeilao>().ToTable("Leiloes");
            modelBuilder.Entity<ItemLeilao>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemLeilao>().Property(x => x.User).HasMaxLength(200).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<ItemLeilao>().Property(x => x.nome_leilao).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<ItemLeilao>().Property(x => x.valor_inicial).IsRequired();
            modelBuilder.Entity<ItemLeilao>().Property(x => x.item_usado).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<ItemLeilao>().Property(x => x.data_inicio).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<ItemLeilao>().Property(x => x.data_fim).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<ItemLeilao>().Property(x => x.nome_usuario).HasMaxLength(200).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<ItemLeilao>().HasIndex(b => b.User);

            modelBuilder.Entity<UserAccount>().ToTable("Users");
            modelBuilder.Entity<UserAccount>().HasKey(x => x.Id);
            modelBuilder.Entity<UserAccount>().Property(x => x.User).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<UserAccount>().Property(x => x.usuario_ativo).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<UserAccount>().HasIndex(b => b.User);
        }

    }
}
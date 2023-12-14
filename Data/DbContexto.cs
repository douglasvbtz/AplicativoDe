using Microsoft.EntityFrameworkCore;
using AplicativoDeComida.Modelos;
using AplicativoDeComida.Models;

namespace AplicativoDeComida.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemMenu> ItensMenu { get; set; }
        public DbSet<PedidoItemMenu> PedidosItensMenu { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar a conexão com o banco de dados
            optionsBuilder.UseMySql("server=localhost;user=root;password=DougVBTZ28@;database=appcomidabd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoItemMenu>()
                .HasKey(pi => new { pi.PedidoId, pi.ItemMenuId });

            modelBuilder.Entity<PedidoItemMenu>()
                .HasOne(pi => pi.Pedido)
                .WithMany(p => p.PedidosItensMenu)
                .HasForeignKey(pi => pi.PedidoId);

            modelBuilder.Entity<PedidoItemMenu>()
                .HasOne(pi => pi.ItemMenu)
                .WithMany(i => i.Pedidos)
                .HasForeignKey(pi => pi.ItemMenuId);
        }
    }
}

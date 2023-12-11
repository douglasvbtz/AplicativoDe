using Microsoft.EntityFrameworkCore;
using AplicativoDeComida.Modelos;

namespace AplicativoDeComida.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemMenu> ItensMenu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar a conexão com o banco de dados
            optionsBuilder.UseMySql("server=localhost;user=root;password=DougVBTZ28@;database=appcomidabd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));
        
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Pedido>()
         //       .HasMany(pedido => pedido.ItensMenu)
         //       .WithOne(item => item.Pedido)
           //     .HasForeignKey(pedido => pedido.ItemMenuId);

//            modelBuilder.Entity<ItemMenu>()
  //              .HasOne(item => item.Pedido)
    //            .WithMany()
      //          .HasForeignKey(item => item.ItemMenuId);
        //}
    }
}

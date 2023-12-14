using AplicativoDeComida.Models;

namespace AplicativoDeComida.Modelos
{
    public class ItemMenu
    {
        public int ItemMenuId { get; set; }
        public string Nome {  get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        // Outros atributos do item de menu, se necessário

        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set;}
        public List<PedidoItemMenu> Pedidos { get; set; } // Alterada de PedidosItensMenu para Pedidos

    }

}

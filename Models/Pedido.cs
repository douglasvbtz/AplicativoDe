using AplicativoDeComida.Models;

namespace AplicativoDeComida.Modelos
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public string Endereco { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        // Outros atributos do pedido, se necessário

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }

        public List<ItemMenu> Menu { get; set; }
        public List<PedidoItemMenu> PedidosItensMenu { get; set; } // Alterada de Menu para PedidosItensMenu


    }

}

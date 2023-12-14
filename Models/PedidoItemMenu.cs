using AplicativoDeComida.Modelos;

namespace AplicativoDeComida.Models
{
    public class PedidoItemMenu
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ItemMenuId { get; set; }
        public ItemMenu ItemMenu { get; set; }
    }
}

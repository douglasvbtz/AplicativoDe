namespace AplicativoDeComida.Modelos
{
    public class Cliente
    {
        public int? ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        // Atributos de endereço, se necessário

        public ICollection<Pedido> Pedidos { get; set; }

    }
}

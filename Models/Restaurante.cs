namespace AplicativoDeComida.Modelos
{
    public class Restaurante
    {
        public int RestauranteId { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        // Outros atributos do restaurante, se necessário

        public ICollection<ItemMenu> ItensMenu { get; set; }
    }

}

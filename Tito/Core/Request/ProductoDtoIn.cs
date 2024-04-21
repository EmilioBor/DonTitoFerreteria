namespace Core.Request
{
    public class ProductoDtoIn
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int IdMarca { get; set; }

        public int IdModelo { get; set; }

        public decimal Precio { get; set; }
        public float Peso { get; set; }
    }
}

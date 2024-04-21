using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class ProductoDtoOut
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? NombreMarca { get; set; }

        public string? NombreModelo { get; set; }

        public decimal Precio { get; set; }
        public float Peso { get; set; }
    }
}

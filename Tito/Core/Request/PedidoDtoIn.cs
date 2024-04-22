using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class PedidoDtoIn
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public float Precio { get; set; }
    }
}

﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class PedidoDetalle
{
    public int Id { get; set; }

    public float Precio { get; set; }

    public int Cantidad { get; set; }

    public int IdProducto { get; set; }

    public int IdPedido { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; }
}
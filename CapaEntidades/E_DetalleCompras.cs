using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_DetalleCompras
    {
        private int Id_DetalleCompra;
        private int Cantidad_Recibida;
        private int Id_Compra_Detalle;
        private int Id_Producto_Detalle;

        public int Id_DetalleCompra1 { get => Id_DetalleCompra; set => Id_DetalleCompra = value; }
        public int Cantidad_Recibida1 { get => Cantidad_Recibida; set => Cantidad_Recibida = value; }
        public int Id_Compra_Detalle1 { get => Id_Compra_Detalle; set => Id_Compra_Detalle = value; }
        public int Id_Producto_Detalle1 { get => Id_Producto_Detalle; set => Id_Producto_Detalle = value; }
    }
}

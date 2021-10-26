using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_DetalleCompras
    {
        E_DetalleCompras ObjEDC = new E_DetalleCompras();
        D_DetalleCompras ObjDDC = new D_DetalleCompras();

        public void InsertandoDetalleCompra(E_DetalleCompras DCompras)
        {
            ObjDDC.InsertarDetalleCompra(DCompras);
        }

        public void AnularDetalleCompra(E_DetalleCompras DCompras)
        {
            ObjDDC.AnularDetalleCompra(DCompras);
        }

        public DataTable MostrarDetalleCompra(int Id_Compra)
        {
            return ObjDDC.MostrarDetalleCompra(Id_Compra);
        }
    }
}

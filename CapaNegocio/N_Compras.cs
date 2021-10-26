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
    public class N_Compras
    {
        E_Compras ObjEC = new E_Compras();
        D_Compras ObjDC = new D_Compras();

        //list compra
        public DataTable listandoCompras()
        {
            return ObjDC.ListarCompras();
        }

        //insert compras
        public void InsertandoCompras(E_Compras compras)
        {
            ObjDC.InsertarCompra(compras);
        }

        public void AnularCompra(E_Compras compras)
        {
            ObjDC.AnularCompra(compras);
        }

    }
}

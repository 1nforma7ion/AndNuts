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
    public class N_Productos
    {
        D_Productos ObjDato = new D_Productos();
        E_Productos ObjEntidad = new E_Productos();
        E_Compras ObjC = new E_Compras();

        public DataTable ListandoProductos()
        {
            return ObjDato.ListarProductos();
        }

        public DataTable BuscandoProductos(string buscar)
        {
            ObjEntidad.Buscar1 = buscar;
            return ObjDato.BuscarProductos(ObjEntidad);
        }

        public DataTable BuscandoProductosxProv(string proveedor)
        {
            ObjEntidad.Proveedor1 = proveedor;
            return ObjDato.BuscarProductosxProv(ObjEntidad);
        }

        public void InsertandoProductos(E_Productos Productos)
        {
            ObjDato.InsertarProducto(Productos);
        }

        public void EditandoProductos(E_Productos Productos)
        {
            ObjDato.EditarProducto(Productos);
        }

        public void MostrandoTotales(E_Productos Productos)
        {
            ObjDato.MostrarTotales(Productos);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Proveedores
    {
        D_Proveedores ObjDato = new D_Proveedores();

        public List<E_Proveedores> BuscandoProveedores(string buscar)
        {
            return ObjDato.BuscarProveedores(buscar);
        }

        public DataTable ListandoProveedores()
        {
            return ObjDato.ListarProveedores();
        }

        public void InsertandoProveedor(E_Proveedores Proveedor)
        {
            ObjDato.InsertarProveedor(Proveedor);
        }

        public void EditandoProveedor(E_Proveedores Proveedor)
        {
            ObjDato.EditarProveedor(Proveedor);
        }

        public DataTable listandoNameProv()
        {
            return ObjDato.ListarNameProv();
        }
    }
}

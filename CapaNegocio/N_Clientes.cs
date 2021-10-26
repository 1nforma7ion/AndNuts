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
    public class N_Clientes
    {
        D_Clientes ObjDato = new D_Clientes();
        E_Clientes ObjEntidad = new E_Clientes();

        public DataTable ListandoClientes()
        {
            return ObjDato.ListarClientes();
        }

        public DataTable BuscandoClientes(string buscar)
        {
            ObjEntidad.Buscar1 = buscar;
            return ObjDato.BuscarClientes(ObjEntidad);
        }

        public void InsertandoClientes(E_Clientes clientes)
        {
            ObjDato.InsertarCliente(clientes);
        }

        public void EditandoClientes(E_Clientes Clientes)
        {
            ObjDato.EditarCliente(Clientes);
        }

        public void MostrandoTotales(E_Clientes clientes)
        {
            ObjDato.TotalClientes(clientes);
        }

        public DataTable ListandoTipoCliente()
        {
            return ObjDato.ListarTipo();
        }
    }
}

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
    public class N_Categoria
    {
        D_Categoria ObjDato = new D_Categoria();

        public List<E_Categoria> ListandoCategoria(string buscar)
        {
            return ObjDato.ListarCategoria(buscar);
        }

        public void InsertandoCategoria(E_Categoria Categoria)
        {
            ObjDato.InsertarCategoria(Categoria);
        }

        public void EditandoCategoria(E_Categoria Categoria)
        {
            ObjDato.EditarCategoria(Categoria);
        }

        public DataTable listandoNameCat()
        {
            return ObjDato.ListarNameCat();
        }
    }
}

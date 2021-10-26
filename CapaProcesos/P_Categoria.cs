using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaDatos;

namespace CapaProcesos
{
    public class P_Categoria
    {
        D_Categoria ObjDato = new D_Categoria();

        public List<E_Categoria>ListandoCategoria(string buscar)
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

        public void EliminandoCategoria(E_Categoria Categoria)
        {
            ObjDato.EliminarCategoria(Categoria);
        }
    }
}

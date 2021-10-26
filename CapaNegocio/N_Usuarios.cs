using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidades;
using CapaDatos;
using CapaEntidades.Cache;

namespace CapaNegocio
{
    public class N_Usuarios
    {
        D_Usuarios ObjDato = new D_Usuarios();
        E_Usuarios ObjEntidad = new E_Usuarios();

        //logueando usuario
        public bool LogeandoUser(string User, string Pass)
        {
            return ObjDato.Login(User, Pass);
        }

        public DataTable ListandoUsuarios()
        {
            return ObjDato.ListarUsuarios();
        }

        public void InsertandoUsuarios(E_Usuarios usuarios)
        {
            ObjDato.InsertarUsuario(usuarios);
        }

        public void EditandoUsuarios(E_Usuarios usuarios)
        {
            ObjDato.EditarUsuario(usuarios);
        }

        public DataTable ListandoRoles()
        {
            return ObjDato.ListarRoles();
        }

        public DataTable CbxTrabajadores()
        {
            return ObjDato.CbxTrabajadores();
        }

        public string RecuperandoContraseña(string userRequesting)
        {
            return ObjDato.RecuperarPass(userRequesting);
        }
    }
}

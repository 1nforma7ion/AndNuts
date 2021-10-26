using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Usuarios
    {
        //Usuario
        private int Id_User;
        private string Nombre_User;
        private string Apellido_User;
        private string Email_User;
        private string Telefono_User;
        private byte[] Foto_User;
        private string Contraseña_User;
        private string UserName;
        private int Id_Rol_User;
        //ROLES
        private int Id_Rol;
        private string Permiso;
        private string Descripcion_Permiso;

        public int Id_User1 { get => Id_User; set => Id_User = value; }
        public string Nombre_User1 { get => Nombre_User; set => Nombre_User = value; }
        public string Apellido_User1 { get => Apellido_User; set => Apellido_User = value; }
        public string Email_User1 { get => Email_User; set => Email_User = value; }
        public string Telefono_User1 { get => Telefono_User; set => Telefono_User = value; }
        public byte[] Foto_User1 { get => Foto_User; set => Foto_User = value; }
        public string Contraseña_User1 { get => Contraseña_User; set => Contraseña_User = value; }
        public string UserName1 { get => UserName; set => UserName = value; }
        public int Id_Rol_User1 { get => Id_Rol_User; set => Id_Rol_User = value; }
        public int Id_Rol1 { get => Id_Rol; set => Id_Rol = value; }
        public string Permiso1 { get => Permiso; set => Permiso = value; }
        public string Descripcion_Permiso1 { get => Descripcion_Permiso; set => Descripcion_Permiso = value; }
    }
}

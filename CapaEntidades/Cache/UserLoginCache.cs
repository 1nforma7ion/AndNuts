using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Cache
{
    public static class UserLoginCache
    {
        public static int Id_User { get; set; }
        public static string Contraseña_User { get; set; }
        public static string UserName { get; set; }
        public static string Nombre_User { get; set; }
        public static string Apellido_User { get; set; }
        public static string Email_User { get; set; }
        public static string Telefono_User { get; set; }
        public static byte[] Foto_User { get; set; }
        public static string Permiso { get; set; }
    }
}

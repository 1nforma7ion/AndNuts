using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Clientes
    {
        private int Id_Cliente;
        private string Nombre_Cliente;
        private string Apellido_Cliente;
        private string Sexo_Cliente;
        private string Dni_Cliente;
        private string Email_Cliente;
        private string Telefono_Cliente;
        private int Id_TipoCliente;
        private string TotalClientes;
        private string Buscar;

        public int Id_Cliente1 { get => Id_Cliente; set => Id_Cliente = value; }
        public string Nombre_Cliente1 { get => Nombre_Cliente; set => Nombre_Cliente = value; }
        public string Apellido_Cliente1 { get => Apellido_Cliente; set => Apellido_Cliente = value; }
        public string Sexo_Cliente1 { get => Sexo_Cliente; set => Sexo_Cliente = value; }
        public string Dni_Cliente1 { get => Dni_Cliente; set => Dni_Cliente = value; }
        public string Email_Cliente1 { get => Email_Cliente; set => Email_Cliente = value; }
        public string Telefono_Cliente1 { get => Telefono_Cliente; set => Telefono_Cliente = value; }
        public int Id_TipoCliente1 { get => Id_TipoCliente; set => Id_TipoCliente = value; }
        public string TotalClientes1 { get => TotalClientes; set => TotalClientes = value; }
        public string Buscar1 { get => Buscar; set => Buscar = value; }
    }
}

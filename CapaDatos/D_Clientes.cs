using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Conectar base de datos
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_Clientes
    {
        SqlConnection conexion = new SqlConnection("server=PC-FACU; database=AndNuts; integrated security=true");

        //LISTAR CLIENTES
        public DataTable ListarClientes()
        {
            //instanciamos objeto datatable
            DataTable Tabla = new DataTable();
            //cramos variable que leera las filas
            SqlDataReader LeerFilas;
            //instanciamos procedimiento almacenado (store procedure)
            SqlCommand cmd = new SqlCommand("SP_ListarClientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            //le decimos que lea nuestras columnas con execute reader
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return Tabla;
        }

        //METODO BUSCAR CLIENTES
        public DataTable BuscarClientes(E_Clientes Nombre_Cliente)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BuscarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", Nombre_Cliente.Buscar1);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        //METODO INSERTAR PRODUCTO
        public void InsertarCliente(E_Clientes Clientes)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre_Cliente",Clientes.Nombre_Cliente1);
            cmd.Parameters.AddWithValue("@Apellido_Cliente",Clientes.Apellido_Cliente1);
            cmd.Parameters.AddWithValue("@Sexo_Cliente",Clientes.Sexo_Cliente1);
            cmd.Parameters.AddWithValue("@Dni_Cliente",Clientes.Dni_Cliente1);
            cmd.Parameters.AddWithValue("@Email_Cliente",Clientes.Email_Cliente1);
            cmd.Parameters.AddWithValue("@Telefono_Cliente", Clientes.Telefono_Cliente1);
            cmd.Parameters.AddWithValue("@Id_TipoCliente",Clientes.Id_TipoCliente1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //METODO EDITAR ClIENTE
        public void EditarCliente(E_Clientes clientes)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Id_Cliente", clientes.Id_Cliente1);
            cmd.Parameters.AddWithValue("@Nombre_Cliente", clientes.Nombre_Cliente1);
            cmd.Parameters.AddWithValue("@Apellido_Cliente", clientes.Apellido_Cliente1);
            cmd.Parameters.AddWithValue("@Sexo_Cliente", clientes.Sexo_Cliente1);
            cmd.Parameters.AddWithValue("@Dni_Cliente", clientes.Dni_Cliente1);
            cmd.Parameters.AddWithValue("@Email_Cliente", clientes.Email_Cliente1);
            cmd.Parameters.AddWithValue("@Telefono_Cliente", clientes.Telefono_Cliente1);
            cmd.Parameters.AddWithValue("@Id_TipoCliente", clientes.Id_TipoCliente1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //MOSTRAR TOTALES
        public void TotalClientes(E_Clientes Clientes)
        {
            SqlCommand cmd = new SqlCommand("SP_CountClientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter TotalCliente = new SqlParameter("@TotalCliente", 0);
            TotalCliente.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(TotalCliente);

            conexion.Open();

            cmd.ExecuteNonQuery();

            Clientes.TotalClientes1 = cmd.Parameters["@TotalCliente"].Value.ToString();

            conexion.Close();
        }

        //LLENAR COMBOBOX Tipo cliente
        public DataTable ListarTipo()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("select Id_Tipo_Cliente, Tipo from Tipo_Cliente Order by Id_Tipo_Cliente asc", conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.Close();
            return tabla;
        }
    }
}

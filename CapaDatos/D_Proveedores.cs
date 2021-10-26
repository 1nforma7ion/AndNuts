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
    public class D_Proveedores
    {
        SqlConnection conexion = new SqlConnection("server=PC-FACU; database=AndNuts; integrated security=true");

        //BUSCAR PROVEEDOR
        public List<E_Proveedores> BuscarProveedores(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarProveedor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Proveedores> listar = new List<E_Proveedores>();

            while (LeerFilas.Read())
            {
                listar.Add(new E_Proveedores
                {
                    Id_Prov1 = LeerFilas.GetInt32(0),
                    Razon_Social1 = LeerFilas.GetString(1),
                    Nombre_Prov1 = LeerFilas.GetString(2),
                    Email_Prov1 = LeerFilas.GetString(3),
                    Telefono_Prov1 = LeerFilas.GetString(4),
                    Calle_Prov1 = LeerFilas.GetString(5),
                    Numero_Prov1 = LeerFilas.GetInt32(6),
                    Departamento_Prov1 = LeerFilas.GetString(7),
                    Piso_Prov1 = LeerFilas.GetString(8),
                    Codigo_Postal_Prov1 = LeerFilas.GetInt32(9),
                    Provincia_Prov1 = LeerFilas.GetString(10),
                    Ciudad_Prov1 = LeerFilas.GetString(11),
                    CUIT_Prov1 = LeerFilas.GetString(12)

                });
            }

            conexion.Close();
            LeerFilas.Close();
            return listar;
        }

        //LISTAR PROVEEDOR
        public DataTable ListarProveedores()
        {
            //instanciamos objeto datatable
            DataTable Tabla = new DataTable();
            //cramos variable que leera las filas
            SqlDataReader LeerFilas;
            //instanciamos procedimiento almacenado (store procedure)
            SqlCommand cmd = new SqlCommand("SP_ListarProveedor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            //le decimos que lea nuestras columnas con execute reader
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return Tabla;
        }

        //INSERTAR PROVEEDOR
        public void InsertarProveedor(E_Proveedores Proveedor)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarProveedor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Razon_Social", Proveedor.Razon_Social1);
            cmd.Parameters.AddWithValue("@Nombre_Prov", Proveedor.Nombre_Prov1);
            cmd.Parameters.AddWithValue("@Email_Prov", Proveedor.Email_Prov1);
            cmd.Parameters.AddWithValue("@Telefono_Prov", Proveedor.Telefono_Prov1);
            cmd.Parameters.AddWithValue("@Calle_Prov", Proveedor.Calle_Prov1);
            cmd.Parameters.AddWithValue("@Numero_Prov", Proveedor.Numero_Prov1);
            cmd.Parameters.AddWithValue("@Departamento_Prov", Proveedor.Departamento_Prov1);
            cmd.Parameters.AddWithValue("@Piso_Prov", Proveedor.Piso_Prov1);
            cmd.Parameters.AddWithValue("@Codigo_Postal_Prov", Proveedor.Codigo_Postal_Prov1);
            cmd.Parameters.AddWithValue("@Provincia_Prov", Proveedor.Provincia_Prov1);
            cmd.Parameters.AddWithValue("@Ciudad_Prov", Proveedor.Ciudad_Prov1);
            cmd.Parameters.AddWithValue("@CUIT_Prov", Proveedor.CUIT_Prov1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //EDITAR PROVEEDOR
        public void EditarProveedor(E_Proveedores Proveedor)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarProveedor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Id_Prov", Proveedor.Id_Prov1);
            cmd.Parameters.AddWithValue("@Razon_Social", Proveedor.Razon_Social1);
            cmd.Parameters.AddWithValue("@Nombre_Prov", Proveedor.Nombre_Prov1);
            cmd.Parameters.AddWithValue("@Email_Prov", Proveedor.Email_Prov1);
            cmd.Parameters.AddWithValue("@Telefono_Prov", Proveedor.Telefono_Prov1);
            cmd.Parameters.AddWithValue("@Calle_Prov", Proveedor.Calle_Prov1);
            cmd.Parameters.AddWithValue("@Numero_Prov", Proveedor.Numero_Prov1);
            cmd.Parameters.AddWithValue("@Departamento_Prov", Proveedor.Departamento_Prov1);
            cmd.Parameters.AddWithValue("@Piso_Prov", Proveedor.Piso_Prov1);
            cmd.Parameters.AddWithValue("@Codigo_Postal_Prov", Proveedor.Codigo_Postal_Prov1);
            cmd.Parameters.AddWithValue("@Provincia_Prov", Proveedor.Provincia_Prov1);
            cmd.Parameters.AddWithValue("@Ciudad_Prov", Proveedor.Ciudad_Prov1);
            cmd.Parameters.AddWithValue("@CUIT_Prov", Proveedor.CUIT_Prov1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //LLENAR COMBOBOX PROVEEDORES
        public DataTable ListarNameProv()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_ListNameProv", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.Close();
            return tabla;
        }
    }
}

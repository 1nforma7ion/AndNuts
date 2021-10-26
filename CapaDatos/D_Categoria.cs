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
    public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection("server=PC-FACU; database=AndNuts; integrated security=true");

        //BUSCAR Y LISTAR CATEGORIA
        public List<E_Categoria> ListarCategoria(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarCategoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    Id_Categoria1 = LeerFilas.GetInt32(0),
                    Nombre_Cat1 = LeerFilas.GetString(1),
                    Descripcion1 = LeerFilas.GetString(2)
                });
            }

            conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        //INSERTAR CATEGORIA
        public void InsertarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarCategoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre_Cat", Categoria.Nombre_Cat1);
            cmd.Parameters.AddWithValue("@Descripcion", Categoria.Descripcion1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //EDITAR CATEOGIRA
        public void EditarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarCategoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Id_Categoria", Categoria.Id_Categoria1);
            cmd.Parameters.AddWithValue("@Nombre_Cat", Categoria.Nombre_Cat1);
            cmd.Parameters.AddWithValue("@Descripcion", Categoria.Descripcion1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //LLENAR COMBOBOX CATEGORIA
        public DataTable ListarNameCat()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_ListNameCat", conexion);
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

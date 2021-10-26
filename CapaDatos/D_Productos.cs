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
    public class D_Productos
    {
        SqlConnection conexion = new SqlConnection("server=PC-FACU; database=AndNuts; integrated security=true");

        //METODO LISTAR PRODUCTOS
        public DataTable ListarProductos()
        {
            //instanciamos objeto datatable
            DataTable Tabla = new DataTable();
            //cramos variable que leera las filas
            SqlDataReader LeerFilas;
            //instanciamos procedimiento almacenado (store procedure)
            SqlCommand cmd = new SqlCommand("SP_ListarProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            //le decimos que lea nuestras columnas con execute reader
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return Tabla;
        }

        //METODO BUSCAR PRODUCTOS
        public DataTable BuscarProductos(E_Productos Nombre_Producto)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BuscarProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", Nombre_Producto.Buscar1);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        //METODO BUSCAR PRODUCTOS X PROV
        public DataTable BuscarProductosxProv(E_Productos Proveedor)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BuscarProductosxProv", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Proveedor", Proveedor.Proveedor1);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        //METODO INSERTAR PRODUCTO
        public void InsertarProducto(E_Productos Productos)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre_Producto", Productos.Nombre_Producto1);
            cmd.Parameters.AddWithValue("@Stock", Productos.Stock1);
            cmd.Parameters.AddWithValue("@Id_Categoria_Producto", Productos.Id_Categoria_Producto1);
            cmd.Parameters.AddWithValue("@Id_Prov_Producto", Productos.Id_Prov_Producto1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //METODO EDITAR PRODUCTO
        public void EditarProducto(E_Productos Productos)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Id_Producto", Productos.Id_Prducto1);
            cmd.Parameters.AddWithValue("@Cod_Producto", Productos.Cod_Producto1);
            cmd.Parameters.AddWithValue("@Nombre_Producto", Productos.Nombre_Producto1);
            cmd.Parameters.AddWithValue("@Stock", Productos.Stock1);
            cmd.Parameters.AddWithValue("@Id_Categoria_Producto", Productos.Id_Categoria_Producto1);
            cmd.Parameters.AddWithValue("@Id_Prov_Producto", Productos.Id_Prov_Producto1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //MOSTRAR TOTALES
        public void MostrarTotales(E_Productos producto)
        {
            SqlCommand cmd = new SqlCommand("SP_CountProducts", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter TotalCategoria = new SqlParameter("@TotalCategoria", 0);
            TotalCategoria.Direction = ParameterDirection.Output;

            SqlParameter TotalProv = new SqlParameter("@TotalProv", 0);
            TotalProv.Direction = ParameterDirection.Output;

            SqlParameter TotalProductos = new SqlParameter("@TotalProductos", 0);
            TotalProductos.Direction = ParameterDirection.Output;

            SqlParameter SumStock = new SqlParameter("@SumStock", 0);
            SumStock.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(TotalCategoria);
            cmd.Parameters.Add(TotalProv);
            cmd.Parameters.Add(TotalProductos);
            cmd.Parameters.Add(SumStock);
            conexion.Open();

            cmd.ExecuteNonQuery();

            producto.TotalCategoria1 = cmd.Parameters["@TotalCategoria"].Value.ToString();
            producto.TotalProv1 = cmd.Parameters["@TotalProv"].Value.ToString();
            producto.TotalProductos1 = cmd.Parameters["@TotalProductos"].Value.ToString();
            producto.SumStock1 = cmd.Parameters["@SumStock"].Value.ToString();

            conexion.Close();
        }


    }
}

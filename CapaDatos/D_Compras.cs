using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Conectar base de datos
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Compras
    {
        D_Conexion Con = new D_Conexion();
        private SqlCommand Cmd;

        //Insertar Compra
        public void InsertarCompra(E_Compras compras)
        {
            Cmd = new SqlCommand("SP_InsertarCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@No_Ingreso", compras.No_Ingreso1);
            Cmd.Parameters.AddWithValue("@Nro_Remito", compras.Nro_Remito1);
            Cmd.Parameters.AddWithValue("@Fecha_Compra", compras.Fecha_Compra1);
            Cmd.Parameters.AddWithValue("@Estado_Compras", compras.Estado_Compras1);
            Cmd.Parameters.AddWithValue("@Id_User_Compras", compras.Id_User_Compras1);
            Cmd.Parameters.AddWithValue("@Id_Prov_Compras", compras.Id_Prov_Compras1);

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //ANULAR COMPRA
        public void AnularCompra(E_Compras compras)
        {
            Cmd = new SqlCommand("SP_AnularCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Id_Compra", compras.Id_Compra1);
            Cmd.Parameters.AddWithValue("@No_Ingreso", compras.No_Ingreso1);
            Cmd.Parameters.AddWithValue("@Nro_Remito", compras.Nro_Remito1);
            Cmd.Parameters.AddWithValue("@Fecha_Compra", compras.Fecha_Compra1);
            Cmd.Parameters.AddWithValue("@Estado_Compras", compras.Estado_Compras1);
            Cmd.Parameters.AddWithValue("@Id_User_Compras", compras.Id_User_Compras1);
            Cmd.Parameters.AddWithValue("@Id_Prov_Compras", compras.Id_Prov_Compras1);

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //MEOTOD LISTAR COMPRAS
        public DataTable ListarCompras()
        {
            DataTable Dt = new DataTable("Ingreso Compras");
            Cmd = new SqlCommand("SP_ListarCompras", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Dr.Close();
            Con.Cerrar();

            return Dt;
        }


    }
}

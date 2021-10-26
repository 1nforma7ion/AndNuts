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
    public class D_DetalleCompras
    {
        D_Conexion Con = new D_Conexion();
        private SqlCommand Cmd;

        //Insertar DetalleCompra
        public void InsertarDetalleCompra(E_DetalleCompras DCompras)
        {
            Cmd = new SqlCommand("SP_InsertarDetalleCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Cantidad_Recibida", DCompras.Cantidad_Recibida1);
            Cmd.Parameters.AddWithValue("@Id_Compra_Detalle", DCompras.Id_Compra_Detalle1);
            Cmd.Parameters.AddWithValue("@Id_Producto_Detalle", DCompras.Id_Producto_Detalle1);

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //ANULAR DetalleCOMPRA
        public void AnularDetalleCompra(E_DetalleCompras DCompras)
        {
            Cmd = new SqlCommand("SP_AnularDetalleCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Id_DetalleCompra", DCompras.Id_DetalleCompra1);
            Cmd.Parameters.AddWithValue("@Cantidad_Recibida", DCompras.Cantidad_Recibida1);
            Cmd.Parameters.AddWithValue("@Id_Compra_Detalle", DCompras.Id_Compra_Detalle1);
            Cmd.Parameters.AddWithValue("@Id_Producto_Detalle", DCompras.Id_Producto_Detalle1);

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //MOSTRAR DETALLE COMPRAS
        public DataTable MostrarDetalleCompra(int Id_Compra)
        {
            DataTable Dt = new DataTable("Detalle Compra");
            Cmd = new SqlCommand("SP_MostrarDetalleCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Id_Compra_Detalle", Id_Compra);
            Cmd.ExecuteNonQuery();

            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);
            Con.Cerrar();
            return Dt;
        }

    }
    
}

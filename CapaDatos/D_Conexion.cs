using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CapaDatos
{
    public class D_Conexion
    {
        private SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_DB"].ConnectionString);

        //METODO QUE PERMITE ABRIR LA CONEXION AL A BASE DE DATOS
        public SqlConnection Abrir()
        {
            if(Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        //METODO QUE PERMITE CERRAR LA CONEXION AL A BASE DE DATOS
        public SqlConnection Cerrar()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}

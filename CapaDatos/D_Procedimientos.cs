using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaDatos
{
    public class D_Procedimientos
    {
        D_Conexion Con = new D_Conexion();

        SqlCommand Cmd;
        SqlDataReader Dr;
        DataTable Dt;

        //METODO QUE PERMITE CARGAR LOS DATOS DE UNA TABLA A UN DGV
        public DataTable CargarDatos(string Tabla)
        {
            Dt = new DataTable("Cargar Datos");
            Cmd = new SqlCommand("Select * from "+Tabla, Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();

            Con.Cerrar();
            return Dt;
        }

        //METODO QUE PERMITE ALTERNAR LOS COLORES EN LAS FILAS DE UN DGV
        public void AlternarColorFilaDataGridView(DataGridView Dgv)
        {
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            Dgv.DefaultCellStyle.BackColor = Color.White;
        }

        //METODO QUE PERMITE CARGAR LOS DATOS DE UNA TABLA A UN DGV
        public string GenerarCodigo(string Tabla)
        {
            string Codigo = string.Empty;
            int Total = 0;
            Cmd = new SqlCommand("Select count(*) as TotalRegistro From "+ Tabla, Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();
            
            if(Dr.Read())
            {
                Total = Convert.ToInt32(Dr["TotalRegistro"]) + 1;
            }
            Dr.Close();

            if(Total < 10)
            {
                Codigo = "0000000" + Total;
            }
            else if (Total < 100)
            {
                Codigo = "000000" + Total;
            }
            else if (Total < 1000)
            {
                Codigo = "00000" + Total;
            }
            else if (Total < 10000)
            {
                Codigo = "0000" + Total;
            }
            else if (Total < 100000)
            {
                Codigo = "000" + Total;
            }
            else if (Total < 1000000)
            {
                Codigo = "00" + Total;
            }
            else if (Total < 10000000)
            {
                Codigo = "0" + Total;
            }

            Con.Cerrar();
            return Codigo;
        }

        public string GenerarCodigoId(string Tabla)
        {
            string Codigo = string.Empty;
            int Total = 0;
            Cmd = new SqlCommand("Select count(*) as TotalRegistro From " + Tabla , Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                Total = Convert.ToInt32(Dr["TotalRegistro"]) + 1;
                Codigo = Total.ToString();
            }
            Dr.Close();

            Con.Cerrar();
            return Codigo;
        }

        //METODO QUE PERMITE DAR FORMATO MONEDA A UN TEXTBOX o caja de texto
        public void FormatoMoneda(TextBox xTBox)
        {
            if(xTBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                decimal Monto;

                Monto = Convert.ToDecimal(xTBox.Text);
                xTBox.Text = Monto.ToString("N2");
            }
        }

        //METODO QUE PERMITE Limpiar Controles
        public void LimpiarControles(Form xForm)
        {
            foreach(var xCtrl in xForm.Controls)
            {
                if(xCtrl is TextBox)
                {
                    ((TextBox)xCtrl).Text = string.Empty;
                }
                else if (xCtrl is ComboBox)
                {
                    ((ComboBox)xCtrl).Text = string.Empty;
                }
            }
        }

        //METODO QUE PERMITE LLLENAR COMBOBOX
        public void LlenarComboBox(string Tabla, string Nombre, ComboBox xCBox)
        {
            Cmd = new SqlCommand("Select * from "+ Tabla,Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            while(Dr.Read())
            {
                xCBox.Items.Add(Dr[Nombre].ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Compras
    {
        private int Id_Compra;
        private string No_Ingreso;
        private int Nro_Remito;
        private DateTime Fecha_Compra;
        private string Estado_Compras;
        private int Id_User_Compras;
        private int Id_Prov_Compras;
        private string Buscar;
        private string Buscar2;

        public int Id_Compra1 { get => Id_Compra; set => Id_Compra = value; }
        public string No_Ingreso1 { get => No_Ingreso; set => No_Ingreso = value; }
        public int Nro_Remito1 { get => Nro_Remito; set => Nro_Remito = value; }
        public DateTime Fecha_Compra1 { get => Fecha_Compra; set => Fecha_Compra = value; }
        public string Estado_Compras1 { get => Estado_Compras; set => Estado_Compras = value; }
        public int Id_User_Compras1 { get => Id_User_Compras; set => Id_User_Compras = value; }
        public int Id_Prov_Compras1 { get => Id_Prov_Compras; set => Id_Prov_Compras = value; }
        public string Buscar1 { get => Buscar; set => Buscar = value; }
        public string Buscar21 { get => Buscar2; set => Buscar2 = value; }
    }
}

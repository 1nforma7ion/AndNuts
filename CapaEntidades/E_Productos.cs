using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Productos
    {
        private int Id_Prducto;
        private string Cod_Producto;
        private string Nombre_Producto;
        private int Stock;
        private int Id_Categoria_Producto;
        private int Id_Prov_Producto;
        private string Buscar;
        private string Proveedor;

        private string TotalCategoria;
        private string TotalProv;
        private string TotalProductos;
        private string SumStock;

        public int Id_Prducto1 { get => Id_Prducto; set => Id_Prducto = value; }
        public string Cod_Producto1 { get => Cod_Producto; set => Cod_Producto = value; }
        public string Nombre_Producto1 { get => Nombre_Producto; set => Nombre_Producto = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public int Id_Categoria_Producto1 { get => Id_Categoria_Producto; set => Id_Categoria_Producto = value; }
        public int Id_Prov_Producto1 { get => Id_Prov_Producto; set => Id_Prov_Producto = value; }
        public string Buscar1 { get => Buscar; set => Buscar = value; }
        public string TotalCategoria1 { get => TotalCategoria; set => TotalCategoria = value; }
        public string TotalProv1 { get => TotalProv; set => TotalProv = value; }
        public string TotalProductos1 { get => TotalProductos; set => TotalProductos = value; }
        public string SumStock1 { get => SumStock; set => SumStock = value; }
        public string Proveedor1 { get => Proveedor; set => Proveedor = value; }
    }
}

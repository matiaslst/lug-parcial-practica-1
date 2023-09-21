using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DLL
{
    public class MapperProducto
    {
        Acceso ac = new Acceso();

        public List<Producto> Listar() 
        {
            List<Producto> productos = new List<Producto>();
            ac.AbrirConn();
            DataTable tabla = ac.Leer("producto_listar");
            ac.CerrarConn();
            foreach (DataRow dr in tabla.Rows) 
            {
                Producto p = new Producto();
                p.ID = int.Parse(dr["Id_Producto"].ToString());
                p.Precio = float.Parse(dr["Precio"].ToString());
                p.Nombre = dr["Producto"].ToString();
                productos.Add(p);
            }
            return productos;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL
{
    public class Producto
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private float precio;

		public float Precio
		{
			get { return precio; }
			set { precio = value; }
		}

        public override string ToString()
        {
			return nombre;
        }

		// BLL

		private MapperProducto mapper =	new MapperProducto();

		public List<Producto> Listar() 
		{
			return mapper.Listar();
		}
    }
}
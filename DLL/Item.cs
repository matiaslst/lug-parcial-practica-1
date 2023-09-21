using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL
{
    public class Item
    {
		private Producto producto;

		public Producto Producto
		{
			get { return producto; }
			set { producto = value; }
		}

		private int cantidad;

		public int Cantidad
		{
			get { return cantidad; }
			set { cantidad = value; }
		}



	}
}
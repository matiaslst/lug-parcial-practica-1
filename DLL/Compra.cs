using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL
{
    public class Compra
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private List<Item> detalle = new List<Item>();

		public List<Item> Detalle
		{
			get { return detalle; }
		}

		private Cliente cliente;

		public Cliente Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}

		private float total;

		public float Total
		{
			get { return total; }
			set { total = value; }
		}

		// BLL

		private MapperCompra mapper = new MapperCompra();

		public void Insertar(Compra com) 
		{
			mapper.EstablecerID(com);
			mapper.Insertar(com);
		}

		public void InsertarItem(Item item, Compra compra) 
		{
			Item i = (from Item detalle in compra.Detalle where detalle.Producto == item.Producto
					  select detalle).FirstOrDefault();

			if (i == null)
			{
				compra.Detalle.Add(item);
			}
			else 
			{
				i.Cantidad += item.Cantidad;
			}
		}

	}
}
using DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Cliente cliente = new Cliente();
        Cliente gestor = new Cliente();
        Compra compra;
        Compra gestorCompra = new Compra();
        Producto gestorProducto = new Producto();
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_nuevoCliente_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            bt_BorrarCliente.Enabled = false;
            bt_GuardarCliente.Enabled = true;
            Cliente cliente = new Cliente();
        }

        void Enlazar() 
        { 
            dataGridView1.DataSource = null;
            comboBox1.DataSource = null;
            List<Cliente> clientes = gestor.Listar();
            dataGridView1.DataSource = clientes;
            comboBox1.DataSource = clientes;
        }

        private void bt_GuardarCliente_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Completar Datos");
            }
            else 
            {
                cliente.Nombre = textBox1.Text;
                cliente.Apellido = textBox2.Text;
                gestor.Grabar(cliente);
                cliente = null;
                bt_BorrarCliente.Enabled = false;
                bt_GuardarCliente.Enabled = false;
                Enlazar();
            }
        }

        private void bt_BorrarCliente_Click(object sender, EventArgs e)
        {
            cliente.Borrado = 1;
            gestor.Grabar(cliente);
            cliente = null;
            bt_BorrarCliente.Enabled = false;
            bt_GuardarCliente.Enabled = false;
            Enlazar();
        }

        private void bt_IniciarCompra_Click(object sender, EventArgs e)
        {
            bt_Carrito.Enabled = true;
            bt_Finalizar.Enabled = false;
            compra = new Compra();
        }

        private void bt_Carrito_Click(object sender, EventArgs e)
        {
            bt_Finalizar.Enabled = true;
            Item item = new Item();
            item.Cantidad = int.Parse(maskedTextBox1.Text);
            item.Producto = (Producto)comboBox2.SelectedItem;
            gestorCompra.InsertarItem(item, compra);

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = compra.Detalle;
        }

        private void bt_Finalizar_Click(object sender, EventArgs e)
        {
            bt_Carrito.Enabled = false;
            bt_Finalizar.Enabled = false;
            compra.Cliente = (Cliente)comboBox1.SelectedItem;
            gestorCompra.Insertar(compra);
            compra = null;
            dataGridView2.DataSource = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox2.DataSource = gestorProducto.Listar();
            Enlazar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente = (Cliente)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            textBox1.Text = cliente.Nombre;
            textBox2.Text = cliente.Apellido;
            bt_BorrarCliente.Enabled = true;
            bt_GuardarCliente.Enabled = true;
            textBox1.Focus();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

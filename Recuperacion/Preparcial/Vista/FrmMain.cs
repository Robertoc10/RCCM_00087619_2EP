using Preparcial.Modelo;
using Preparcial.Controlador;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Preparcial.Vista
{
    public partial class FrmMain : Form
    {
        private Usuario u;

        public FrmMain(Usuario u)
        {
            InitializeComponent();
            this.u = u;
        }

        private void bttnCreateUser_Click(object sender, EventArgs e)
        {
            if (!txtNewUser.Text.Equals(""))
            {
                ControladorUsuario.CrearUsuario(txtNewUser.Text);
                ActualizarCrearUsuario();
            }
            //Corrección: Se agregó un mensaje que muestre error si hay campos vacios en el textBox
            else
                MessageBox.Show("No se pueden dejar campos vacíos.");
        }

        private void ActualizarCrearUsuario()
        {
            dgvCreateUser.DataSource = ControladorUsuario.GetUsuariosTable();
        }

        private void ActualizarInventario()
        {
            dgvInventary.DataSource = ControladorInventario.GetProductosTable();
        }

        private void ActualizarOrdenes()
        {
            dgvAllOrders.DataSource = ControladorPedido.GetPedidosTable();
        }

        private void ActualizarOrdenesUsuario()
        {
            dgvMyOrders.DataSource = ControladorPedido.GetPedidosUsuarioTable(u.IdUsuario);
            cmbProductMakeOrder.ValueMember = "idarticulo";
            cmbProductMakeOrder.DisplayMember = "producto";
            cmbProductMakeOrder.DataSource = ControladorInventario.GetProductos();
        }
        //Correción: Se cambiaron los operadores && por ||, porque si no, solo se cumpliria la condicion cuando todos estan vacios.
        private void bttnAddInventary_Click(object sender, EventArgs e)
        {
            if (txtProductNameInventary.Text.Equals("") ||
                txtDescriptionInventary.Text.Equals("") ||
                txtPriceInventary.Text.Equals("") ||
                txtStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {   //Corrección: Se detecto una mala practica de programacion sobrepasandose la linea.
                ControladorInventario.AnadirProducto(txtProductNameInventary.Text,
                    txtDescriptionInventary.Text,
                    txtPriceInventary.Text, txtStockInventary.Text);

                ActualizarInventario();
            }
        }

        private void bttnDeleteInventary_Click(object sender, EventArgs e)
        {
            if(txtDeleteInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorInventario.EliminarProducto(txtDeleteInventary.Text);
                ActualizarInventario();
            }
        }

        private void bttnUpdateStockInventary_Click(object sender, EventArgs e)
        {     //Corrección: Se cambió el operador lógico && a || para que se cumpla la condicion correctamente
            if (txtUpdateStockIdInventary.Text.Equals("") || txtUpdateStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorInventario.ActualizarProducto(txtUpdateStockIdInventary.Text, txtUpdateStockInventary.Text);
                ActualizarInventario();
            }
        }

        private void bttnMakeOrder_Click(object sender, EventArgs e)
        {
            if (txtMakeOrderQuantity.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {  //Corrección: Validación para comprobar que la cantidad de productos ordenados no sea mayor que el stock actual del producto
                Inventario inv = (Inventario) cmbProductMakeOrder.SelectedItem;
                if (Convert.ToInt32(inv.stock)>=Convert.ToInt32(txtMakeOrderQuantity.Text))
                {
                    //Corrección: Se detecto una mala practica de programacion sobrepasandose la linea.
                    
                    ControladorPedido.HacerPedido(u.IdUsuario, cmbProductMakeOrder.SelectedValue.ToString(),
                        txtMakeOrderQuantity.Text);
                    ActualizarOrdenesUsuario();
                }
                else
                    MessageBox.Show("No hay suficientes productos para completar su orden.");
              
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {    
            //Correción: validación de generalTab para mostrar mensaje de permisos solo una vez
            if(tabControl1.SelectedTab.Name.Equals("generalTab"))
                ActualizarCrearUsuario();
           else if (tabControl1.SelectedTab.Name.Equals("createNewUserTab") && u.Admin)
                ActualizarCrearUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("inventaryTab") && u.Admin)
                ActualizarInventario();

            else if (tabControl1.SelectedTab.Name.Equals("createOrderTab") && !u.Admin)
                ActualizarOrdenesUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("viewOrdersTab") && u.Admin)
                ActualizarOrdenes();
            
            else
            {
                MessageBox.Show("No tiene permisos para ver esta pestana");
                tabControl1.SelectedTab = tabControl1.TabPages[0];
            }

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
    Application.Exit();
        }
    }
}

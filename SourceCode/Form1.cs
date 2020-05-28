using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class Form1 : Form
    {
        private AppUser appUser;
        public Form1( AppUser pAppUser)
        {
            InitializeComponent();
            appUser= pAppUser;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (appUser.usertype)
            {
                tabAddAdress.Parent = null;
                tabModifyAdress.Parent = null;
                tabAddOrder.Parent = null;
                tabDeleteOrder.Parent = null;
                            
                actualizarControlesAdmin();
            }
            else
            {
                tabAddUsu.Parent = null;
                tabDeleteUsu.Parent =null;
                tabAddBussines.Parent = null;
                tabDeleteBussines.Parent = null;
                tabAddProduct.Parent = null;
                tabDeleteProduct.Parent = null;
                tabSeeOrders.Parent = null;
                actualizarControlesUsu();
            }
        }

        private void actualizarControlesAdmin()
        {
            List<AppUser> listau = AppUserDao.getListaUsu();
            cmbEliminarUsu.DataSource = null;
            cmbEliminarUsu.DisplayMember = "iduser";
            cmbEliminarUsu.DataSource = listau;
            dgvVerUsuarios.DataSource = listau;
            List<Business> listab = BusinessDAO.getListaBusiness();
            cmbEliminarNegocio.DataSource = null;
            cmbEliminarNegocio.DisplayMember = "idbusiness";
            cmbEliminarNegocio.DataSource = listab;
            dataGridView1.DataSource = listab;
            cmbAddProduct.DataSource = null;
            cmbAddProduct.DisplayMember = "idbusiness";
            cmbAddProduct.DataSource = listab;
            List<Product> listap = ProductDAO.GetListaProducts();
            combEliminarProd.DataSource = null;
            combEliminarProd.DisplayMember = "idproduct";
            combEliminarProd.DataSource = listap;
            dgvVerProductos.DataSource = listap;
            List<AppOrder> listao = AppOrderDAO.getListaOrders();
            dgvVerOrdenes.DataSource = listao;
            
        }

        private void actualizarControlesUsu()
        {   
            dgvVerDirecciones.DataSource = AdressDAO.getListaAdress(appUser.iduser); 
            
            
            List<Product> listap = ProductDAO.GetListaProducts();
            cmbAgregarProd.DataSource = null;
                       cmbAgregarProd.DisplayMember = "idproduct";
                       cmbAgregarProd.DataSource = listap;
                       
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
                {
                    if (MessageBox.Show("¿Seguro que desea salir, " + appUser.username + "?", 
                        "SourceCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        try
                        {
                            
                            e.Cancel = false;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ha sucedido un error, favor intente dentro de un minuto.", 
                                "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                 private void Form1_FormClosed(object sender, FormClosedEventArgs e)
                        {
                            
                            Application.Exit();
                        }


                 private void btnAgregarUsu_Click(object sender, EventArgs e)
                 {
                     try
                     {
                         if (txtFullname.Text.Length > 5 && txtUserName.Text.Length > 5)
                         {
                             AppUserDao.crearNuevo(txtFullname.Text, txtUserName.Text, txtUserName.Text,
                                 rdbAdmin.Checked);
                             MessageBox.Show("¡Usuario agregado exitosamente! contraseña igual a nombre de usuario.",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             actualizarControlesAdmin();

                         }
                         else
                             MessageBox.Show("Favor digite un usuario (longitud minima, 5 caracteres)",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("El usuario que ha digitado, no se encuentra disponible.", 
                             "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }

                 }

                 private void btnEliminarUsu_Click(object sender, EventArgs e)
                 { 
                     try
                     {
                         if (cmbEliminarUsu.Text.Length > 0)
                         {
                             AppUserDao.eliminar(Convert.ToInt32(cmbEliminarUsu.Text));
                             MessageBox.Show("¡Usuario eliminado exitosamente!",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             actualizarControlesAdmin();

                         }
                         else
                             MessageBox.Show("Favor seleccione un usuario ",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("El usuario que ha seleccionado, no se encuentra disponible.", 
                             "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

                 private void btnAgregarNegocio_Click(object sender, EventArgs e)
                 {
                     try
                     {
                         if (txtNegocio.Text.Length > 5 && txtDescripcion.Text.Length > 5)
                         {
                             BusinessDAO.insertarNegocio(txtNegocio.Text, txtDescripcion.Text);
                             MessageBox.Show("¡Negocio agregado exitosamente!.",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             actualizarControlesAdmin();

                         }
                         else
                             MessageBox.Show("Favor digite un negocio (longitud minima, 5 caracteres)",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("El negocio que ha digitado, no se encuentra disponible.", 
                             "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }

                 }

                 private void btnEliminarNegocio_Click(object sender, EventArgs e)
                 {
                     try
                     {
                         if (cmbEliminarNegocio.Text.Length > 0)
                         {
                             BusinessDAO.eliminarNegocio(Convert.ToInt32(cmbEliminarNegocio.Text));
                             MessageBox.Show("¡Negocio eliminado exitosamente!",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             actualizarControlesAdmin();

                         }
                         else
                             MessageBox.Show("Favor seleccione un negocio ",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("El negocio que ha seleccionado, no se encuentra disponible.", 
                             "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

                 


                 private void btnAgreagarProducto_Click_1(object sender, EventArgs e)
                 {
                      try
                      {
                          if (cmbAddProduct.Text.Length > 0 && txtNombreProducto.Text.Length > 3)
                          {
                              ProductDAO.insertarProducto(Convert.ToInt32(cmbAddProduct.Text), txtNombreProducto.Text);
                              MessageBox.Show("¡Producto agregado exitosamente!.",
                                  "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              actualizarControlesAdmin();
                     
                          }
                          else
                              MessageBox.Show("Favor digite un producto (longitud minima, 3 caracteres)",
                                  "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      }
                      catch (Exception)
                      {
                          MessageBox.Show("El producto, no se encuentra disponible.", 
                              "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                 }

                 private void btnEliminarProducto_Click(object sender, EventArgs e)
                 {
                      try
                      {
                          if (combEliminarProd.Text.Length > 0)
                          {
                              ProductDAO.eliminarProducto(Convert.ToInt32(combEliminarProd.Text));
                              MessageBox.Show("¡Producto eliminado exitosamente!",
                                  "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              actualizarControlesAdmin();
                     
                          }
                          else
                              MessageBox.Show("Favor seleccione un Producto ",
                                  "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      }
                      catch (Exception)
                      {
                          MessageBox.Show("El Producto que ha seleccionado, no se encuentra disponible.", 
                              "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                 }

                 private void btnAgregarDireccion_Click(object sender, EventArgs e)
                 {
                     try
                     {
                         if (txtDireccion.Text.Length>10)
                         {
                             AdressDAO.insertarDireccion(appUser.iduser, txtDireccion.Text);
                             MessageBox.Show("¡Direccion agregada exitosamente!.",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             actualizarControlesUsu();
                             
                         }
                         else
                             MessageBox.Show("Favor digite una direccion (longitud minima, 10 caracteres)",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("La direccion, no se encuentra disponible.", 
                             "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

                 private void btnMofificarDirec_Click(object sender, EventArgs e)
                 {
                     try
                     {
                         if (txtNuevaDirec.Text.Length>10 && txtModificarDireccion.Text.Length>0)
                         {
                             AdressDAO.modificarDireccion( txtNuevaDirec.Text, Convert.ToInt32(txtModificarDireccion.Text));
                             MessageBox.Show("¡Direccion modificada exitosamente!.",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             actualizarControlesUsu();
                             
                                          
                         }
                         else
                             MessageBox.Show("Favor digite una direccion (longitud minima, 10 caracteres)",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("La direccion, no se encuentra disponible.", 
                             "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

                 private void btnEliminarDirec_Click(object sender, EventArgs e)
                 {
                     try
                     {
                         if (txtEliminarDirec.Text.Length>0)
                         {
                             AdressDAO.eliminarDireccion( Convert.ToInt32(txtEliminarDirec.Text));
                             MessageBox.Show("¡Direccion eliminada exitosamente!.",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             actualizarControlesUsu();
                             
                                          
                         }
                         else
                             MessageBox.Show("Favor digite un id",
                                 "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("El id no se encuentra disponible.", 
                             "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

                 private void btnAgregarOrden_Click(object sender, EventArgs e)
                 {
                      try
                      {
                          if (txtAgregarOrden.Text.Length>0 && cmbAgregarProd.Text.Length>0)
                              
                          {    
                              AppOrderDAO.insertarOrden(DateTime.Now , Convert.ToInt32(cmbAgregarProd.Text), Convert.ToInt32(txtAgregarOrden.Text));
                              MessageBox.Show("¡Orden agregada exitosamente!.",
                                  "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              actualizarControlesUsu();
                              
                                                  
                          }
                          else
                              MessageBox.Show("Favor digite un id ",
                                  "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      }
                      catch (Exception)
                      {
                          MessageBox.Show("EL id no se encuentra disponible.", 
                              "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                 }

                 private void btnEliminarOrden_Click(object sender, EventArgs e)
                 {   try
                                          {
                                              if (textBox1.Text.Length>0)
                                                  
                                              {    
                                                  AppOrderDAO.eliminarOrden(Convert.ToInt32(textBox1.Text));
                                                  MessageBox.Show("¡Orden eliminada exitosamente!.",
                                                      "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                  actualizarControlesUsu();
                                                                      
                                              }
                                              else
                                                  MessageBox.Show("Favor digite un id ",
                                                      "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                          }
                                          catch (Exception)
                                          {
                                              MessageBox.Show("EL id no se encuentra disponible.", 
                                                  "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                          }
                     



                 }
    }
}
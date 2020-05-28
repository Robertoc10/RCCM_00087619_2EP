using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class fmrInicioSesion : Form
    {
        public fmrInicioSesion()
        {
            InitializeComponent();
        }
        private void fmrInicioSesion_Load(object sender, EventArgs e)
        {
            poblarControles();
        }
        
        private void poblarControles()
        {
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "password";
            cmbUsuario.DisplayMember = "username";
            cmbUsuario.DataSource = AppUserDao.getListaUsu();
        }


        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            if (txtCambiarcontra.Text.Equals(cmbUsuario.SelectedValue.ToString()) )
            {
                AppUser u = (AppUser) cmbUsuario.SelectedItem;

                
                    
                    
                    MessageBox.Show("¡Bienvenido!", 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Form1 ventana = new Form1(u);
                    ventana.Show();
                    this.Hide();
               
            }
            else
                MessageBox.Show("¡Contraseña incorrecta!", "SourceCode",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void txtCambiarcontra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnInicioSesion_Click(sender, e);

        }

        
        private void btnCambiarContra_Click_1(object sender, EventArgs e)
        {
            
            fmrCambiarContra unaVentana = new fmrCambiarContra();
            unaVentana.ShowDialog();
            poblarControles();
        }
    }
}
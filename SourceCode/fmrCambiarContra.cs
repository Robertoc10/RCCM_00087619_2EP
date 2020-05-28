using System;
using System.Data;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class fmrCambiarContra : Form
    {
        public fmrCambiarContra()
        {
            InitializeComponent();
        }
        
        private void fmrCambiarContra_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "iduser";
            comboBox1.DataSource = AppUserDao.getListaUsu();
        }

        public bool comparar(string actual, string correcta)
        {
            if (actual.Equals(correcta)) return true;
            return false;
        }
        


        private void btnActContra_Click(object sender, EventArgs e)
        {
            bool actualIgual = comparar(txtContraActual.Text, comboBox1.SelectedValue.ToString());
            bool nuevaIgual = txtNuevaContra.Text.Equals(txtNuevaContraRep.Text);
            bool nuevaValida = txtNuevaContra.Text.Length > 0;

            if (actualIgual && nuevaIgual && nuevaValida)
            {
                try
                {
                    AppUserDao.actualizarContra(txtNuevaContra.Text, Convert.ToInt32(comboBox1.Text));
                    
                    MessageBox.Show("¡Contraseña actualizada exitosamente!", 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Contraseña no actualizada! Favor intente mas tarde.", 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("¡¡Favor verifique que los datos sean correctos!", 
                    "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
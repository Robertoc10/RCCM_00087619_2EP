using Preparcial.Controlador;
using Preparcial.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preparcial.Vista
{
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("../../Recursos/UCA.png");
pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

ActualizarControlers();
}

private void ActualizarControlers()
{ //Correccion: Se cambio el orden al poblar el comboBox
comboBox1.ValueMember = "Contrasena";
comboBox1.DisplayMember = "NombreUsuario";
comboBox1.DataSource = ControladorUsuario.GetUsuarios();

}

private void Button1_Click(object sender, EventArgs e)
{
    //Corrección: se agregó validación para que la contraseña no este vacia.
    if (txtOldPassword.Text.Equals(comboBox1.SelectedValue.ToString()) && txtNewPassword.Text.Length>0)
    {       
        var obtenerUsuario = (Usuario)comboBox1.SelectedItem;

        ActualizarControlers();
        ControladorUsuario.ActualizarContrasena(obtenerUsuario.IdUsuario,
            txtNewPassword.Text);
    
    }
    else
        //Corrección: Cambio del mensaje acorde a la nueva validación.
        MessageBox.Show("Ocurrió un error. Verifique su contraseña actual o la longitud de la nueva.");
}
    }
}

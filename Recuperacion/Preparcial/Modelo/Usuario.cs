namespace Preparcial.Modelo
{
    public class Usuario
    {  //Corrección: Se eliminaron las propiedades setters por ser innecesarias
        public string IdUsuario { get;  }

        public string NombreUsuario { get;  }

        public string Contrasena { get;  }

        public bool Admin { get;  }

        public Usuario(string idUsuario, string nombreUsuario, string contrasenia, bool admin)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasenia;
            Admin = admin;
        }
    }
}

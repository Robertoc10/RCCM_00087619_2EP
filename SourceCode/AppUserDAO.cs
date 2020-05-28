using System;
using System.Collections.Generic;
using System.Data;


namespace SourceCode
{
    public static class AppUserDao
    {
        public static List<AppUser> getListaUsu()
        {
            string sql = "select * from appuser";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<AppUser> listausu = new List<AppUser>();
            foreach (DataRow fila in dt.Rows)
            {
                AppUser u = new AppUser();
                u.iduser = Convert.ToInt32(fila[0].ToString());
                u.fullname = fila[1].ToString();
                u.username = fila[2].ToString();
                u.password = fila[3].ToString();
                u.usertype = Convert.ToBoolean(fila[4].ToString());

                listausu.Add(u);
            }
            return listausu;
        }

        public static void actualizarContra(string nueva, int idusuario)
        {
            string sql = String.Format(
                "UPDATE APPUSER SET password = '{0}' WHERE idUser = {1};",
                nueva, idusuario);
            
            Conexion.realizarAccion(sql);
        }

        public static void crearNuevo(string fullname, string username, string password, bool usertype)
        {
            string sql = String.Format(
                "INSERT INTO APPUSER(fullname, username, password, userType) " +
                "VALUES('{0}', '{1}', '{2}', {3});",
                fullname, username, password, usertype);
                
            
            Conexion.realizarAccion(sql);
        }

        
        public static void eliminar(int iduser)
        {
            string sql = String.Format(
                "DELETE FROM APPUSER WHERE idUser = {0};",
               
                 iduser);
            
            Conexion.realizarAccion(sql);
        }
        
      
    }
}
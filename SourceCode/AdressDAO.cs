using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode
{
    public static class AdressDAO
    {
        public static DataTable getListaAdress(int idusuario)
        {
            string sql = String.Format(
                "SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE idUser = {0};",
                idusuario);

            DataTable dt = Conexion.realizarConsulta(sql);

            return dt;
        }

        public static void modificarDireccion(string nuevad, int idaddress)
        {
            string sql = String.Format(
                "UPDATE ADDRESS SET address = '{0}' WHERE idAddress = {1};",
                nuevad, idaddress);
            
            Conexion.realizarAccion(sql);
        }

        public static void insertarDireccion(int idUser,string address)
        {
            string sql = String.Format(
                "INSERT INTO ADDRESS(idUser, address) " +
                "VALUES({0}, '{1}');",
                idUser, address);
                
            
            Conexion.realizarAccion(sql);
        }

        
        public static void eliminarDireccion(int idaddress)
        {
            string sql = String.Format(
                "DELETE FROM ADDRESS WHERE idAddress = {0};",
               
                idaddress);
            
            Conexion.realizarAccion(sql);
        }
    }
}
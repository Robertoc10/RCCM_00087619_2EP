using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode
{
    public static class BusinessDAO
    {
        public static List<Business> getListaBusiness()
        {
            string sql = "SELECT * FROM business";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Business> listaBusiness = new List<Business>();
            foreach (DataRow fila in dt.Rows)
            {
                Business u = new Business();
                u.idbusiness = Convert.ToInt32(fila[0].ToString());
                u.name = fila[1].ToString();
                u.description = fila[2].ToString();
                listaBusiness.Add(u);
            }
            return listaBusiness;
        }

       

        public static void insertarNegocio(string nombre, string descripcion)
        {
            string sql = String.Format(
                "INSERT INTO BUSINESS(name, description) " +
                "VALUES('{0}', '{1}');",
                nombre, descripcion);
                
            
            Conexion.realizarAccion(sql);
        }

        
        public static void eliminarNegocio(int idnegocio)
        {
            string sql = String.Format(
                "DELETE FROM BUSINESS WHERE idBusiness = {0};",
               
                idnegocio);
            
            Conexion.realizarAccion(sql);
        }
    }
}
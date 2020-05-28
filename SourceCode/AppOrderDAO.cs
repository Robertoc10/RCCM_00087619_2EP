using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode
{
    public static class AppOrderDAO
    {  
         public static List<AppOrder> getListaOrders()
        {
            string sql = "SELECT * FROM apporder";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<AppOrder> listaOrders = new List<AppOrder>();
            foreach (DataRow fila in dt.Rows)
            {
                AppOrder u = new AppOrder();
                u.idorder = Convert.ToInt32(fila[0].ToString());
                u.createdate = Convert.ToDateTime(fila[1].ToString());
                u.idproduct = Convert.ToInt32(fila[2].ToString());
                u.idaddress = Convert.ToInt32(fila[3].ToString());
               
                listaOrders.Add(u);
            }
            return listaOrders;
        }
         
            


        public static void insertarOrden(DateTime date, int idproducto, int idaddress)
        {
            string sql = String.Format(
                "INSERT INTO APPORDER(createDate, idProduct, idAddress) " +
                "VALUES('{0}', {1}, {2});",
                date, idproducto, idaddress);
                
            
            Conexion.realizarAccion(sql);
        }

        
        public static void eliminarOrden(int idorder)
        {
            string sql = String.Format(
                "DELETE FROM APPORDER WHERE idOrder = {0};",
               
                idorder);
            
            Conexion.realizarAccion(sql);
        }
        
    }
}
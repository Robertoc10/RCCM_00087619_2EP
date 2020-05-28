using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode
{
    public static class ProductDAO
    {
        public static List<Product> GetListaProducts()
        {
            string sql = "SELECT * FROM product";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Product> listaProducts = new List<Product>();
            foreach (DataRow fila in dt.Rows)
            {
                Product u = new Product();
                u.idproduct = Convert.ToInt32(fila[0].ToString());
                u.idbusiness = Convert.ToInt32(fila[1].ToString());
                u.name = fila[2].ToString();
                listaProducts.Add(u);
            }
            return listaProducts;
        }

       

        public static void insertarProducto(int idnegocio, string nombre)
        {
            string sql = String.Format(
                "INSERT INTO PRODUCT(idBusiness, name) " +
                "VALUES({0}, '{1}');",
                idnegocio, nombre);
                
            
            Conexion.realizarAccion(sql);
        }

        
        public static void eliminarProducto(int idproducto)
        {
            string sql = String.Format(
                "DELETE FROM PRODUCT WHERE idProduct = {0};",
               
                idproducto);
            
            Conexion.realizarAccion(sql);
        }
    }
}
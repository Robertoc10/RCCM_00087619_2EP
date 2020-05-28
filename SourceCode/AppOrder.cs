using System;

namespace SourceCode
{
    public class AppOrder
    {
        public int idorder { get; set; }
        public DateTime createdate { get; set; }
        public int idproduct { get; set; }
        public int idaddress { get; set; }
        
                                            

        public AppOrder()
        {
            idorder = 0;
            createdate = DateTime.Now;
            idproduct = 0;
            idaddress = 0;


        }
    }
}
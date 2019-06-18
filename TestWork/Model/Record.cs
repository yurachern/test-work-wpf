using System;

namespace TestWork.Model
{
    public class Record
    {       
        public int OrderNumber { get; set; }                    
        public string User { get; set; }     
        public int LineQuantity { get; set; }                     
        public decimal Sum { get; set; }                 
        public DateTime Created { get; set; }                  
        public DateTime Modified { get; set; }            
    }
}

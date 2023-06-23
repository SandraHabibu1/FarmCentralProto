using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmCentralProto.Models
{
    public class Product
    {
        public Product() { }
        [Key] public int ProductID { get; set; }

        // Foreign key 
        [Display(Name = "Farmer")]
        public int FarmerID { get; set; }
       
        
        [ForeignKey("FarmerID")]
        public virtual Farmer Farmers { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public double Price { get; set; }

        



    }

}

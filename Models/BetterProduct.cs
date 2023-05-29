using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmCentralProto.Models
{
    public class BetterProduct
    {
        public BetterProduct() 
        { 

        }
        [Key] public int ProductID { get; set; }

        // Foreign key 
        [Display(Name = "Farmer")]
        public int FarmerID { get; set; }
        [ForeignKey("FarmerID")]
        public virtual Farmer Farmer { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public double? Price { get; set; }
    }
}

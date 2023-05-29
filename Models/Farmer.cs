using System.ComponentModel.DataAnnotations;

namespace FarmCentralProto.Models
{
    public class Farmer
    {
        [Key] public int FarmerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

    }
}

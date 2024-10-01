using System.ComponentModel.DataAnnotations;

namespace Test.October.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public List<Item> Items { get; set; }
        public DateTime AssemblyDate { get; set; } 
        public int Number { get; set; }
        public DateTime ComplitedDate { get; set; }
        public string Status { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Test.October.Data
{
    public class AssemblySite
    {
        [Key]
        public long AssemblySiteId { get; set; }
        public List<Order> Orders { get; set; }
        public List<Item> Leftovers { get; set; }
        public List<Item> ItemCatalogue { get; set; }
    }
}

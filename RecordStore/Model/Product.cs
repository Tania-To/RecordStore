using System.ComponentModel.DataAnnotations;

namespace RecordStore.Model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        public int StoreId { get; set; }
    }
}

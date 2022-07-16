using System.ComponentModel.DataAnnotations;

namespace RecordStore.Model
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }

    }
}

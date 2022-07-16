using System.ComponentModel.DataAnnotations;

namespace RecordStore.Model
{
    public class Associate
    {
        [Key]
        public int AssociateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HourlyRate { get; set; } 
        public int SSN { get; set; }
        public string DoB { get; set; }
        public int StoreID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

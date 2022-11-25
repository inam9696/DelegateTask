using System.ComponentModel.DataAnnotations;

namespace Task_3_Delegates.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public int GrantTotal { get; set; }
    }
}

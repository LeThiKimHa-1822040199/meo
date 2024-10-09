using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_03.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        [Required]
        public string Customer_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone_Number { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Contract> Contracts { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_03.Models
{
    public class Contract
    {
        [Key]
        public int Contract_Id { get; set; }
        [Required(ErrorMessage = "Không được để trống Id!")]
        [Display(Name = "Contract")]

        public string Contract_Name { get; set; }
        [Required(ErrorMessage = "Không được để trống Name!")]
        [Display(Name = "Contract")]
        public string Signing_Date { get; set; }
        [Required(ErrorMessage = "Không đúng định dạng ngày!")]
        [Display(Name = "Ngày tạo")]

        public string Customer { get; set; }

        public double Contract_Value { get; set; }

        public int CustomerId { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}

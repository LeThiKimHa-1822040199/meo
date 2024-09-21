using System.ComponentModel.DataAnnotations;

namespace BaiTap07.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống Tên thể loại!")]
        [Display(Name = "Thể loại")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Không đúng định dạng ngày!")]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

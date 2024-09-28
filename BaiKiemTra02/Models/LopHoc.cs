using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống Tên id!")]
        [Display(Name = "id ")]
        public string TenLopHoc { get; set; }
        [Required(ErrorMessage = "không được để trống lớp")]
        [Display(Name = "tên lớp học")]
        public string SoLuongSinhVien { get; set; }
        [Required(ErrorMessage = "Không đúng định dạng ngày!")]
        [Display(Name = "Ngày tạo")]
        public DateTime NamNhapHoc { get; set; } = DateTime.Now;
        public DateTime NamRaTruong { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;

namespace EState.UI.Areas.User.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Boş geçilemez!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        public string NewPassword { get; set; }
    }
}

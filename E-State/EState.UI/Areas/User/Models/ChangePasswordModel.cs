using System.ComponentModel.DataAnnotations;

namespace EState.UI.Areas.User.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Boş geçilemez!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        public string ConfirmedPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EState.UI.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EState.UI.Areas.User.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Boş geçilemez")]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        [Required(ErrorMessage = "Boş geçilemez")]
        public string Password { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil!")]
        [Required(ErrorMessage = "Boş geçilemez")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public string FullName { get; set; }

    }
}

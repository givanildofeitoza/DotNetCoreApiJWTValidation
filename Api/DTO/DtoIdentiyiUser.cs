using System.ComponentModel.DataAnnotations;

namespace Api.DTO
{
    public class DtoRegister
    {
        [Required(ErrorMessage ="Email é Rquired")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name é Rquired")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password é Rquired")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password and Confirme Password is not equal")]
        public string ConfirmPassword { get; set; }
        public string StatusRegistro { get; set; }
    }

    public class DtoLogin
    {
        [Required(ErrorMessage = "Email é Rquired")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password é Rquired")]
        public string Password { get; set; }
        public string StatusRegistro { get; set; }
        public string TokenJWT { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models.View
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Вкажіть ім'я")]
        [MaxLength(30, ErrorMessage = "Ім'я не може перевищувати 30 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вкажіть прізвисько")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Вкажіть адресу електроної пошти")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вкажіть логін")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Вкажіть пароль")]
        [MinLength(6, ErrorMessage = "Пароль повинен мати довжину більше, ніж 6 символів")]
        public string Password{ get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Необхідно підтвердити пароль")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string PasswordConfirm { get; set; }
    }
}

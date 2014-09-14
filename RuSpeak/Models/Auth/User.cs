using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RuSpeak.Models.Auth
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            return rolesArray.Select(role => UserRoles.Any(p => string.Compare(p.Code, role, StringComparison.OrdinalIgnoreCase) == 0)).Any(hasRole => hasRole);
        }

        public virtual ICollection<Role> UserRoles { get; set; }

        public User()
        {
            UserRoles = new HashSet<Role>();
        }
    }

    public class RegisterInfo
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Не корректный почтовый адрес")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

    }

    public class UserProfile
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Не корректный почтовый адрес")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(25, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
    }

    public class LoginView
    {
        [Required(ErrorMessage = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Не корректный почтовый адрес")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Запомнить")]
        public bool IsPersistent { get; set; }
    }
}
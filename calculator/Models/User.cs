using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }
       [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }
         [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя пользователя")]
         [Display(Name = "Логин")]
        public string UserName { get; set; } 
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Пароль должен содержать как минимум 6 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string Mobile { get; set; }

        public int IsAdmin { get; set; }
      
    }
  

}
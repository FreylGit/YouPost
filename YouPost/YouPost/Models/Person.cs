using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouPost.Models
{
    public class Person
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        [Display(Name ="Имя")]
        public string FirstName { get; set; }
       
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(11)")]
        [Display(Name = "Номер телефона")]
        public string NumberPhone { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(18)")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Фото")]
        public string Photo { get; set; }
        [Display(Name = "Дата регистрации")]
        
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string Url { get; set; }

    }
}

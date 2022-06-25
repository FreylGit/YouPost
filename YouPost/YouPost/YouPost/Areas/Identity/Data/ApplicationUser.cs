using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YouPost.Models;

namespace YouPost.Areas.Identity.Data;

public class ApplicationUser : IdentityUser<Guid>
{

    [Column(TypeName = "nvarchar(100)")]
    [Display(Name = "Имя")]
    public string FirstName { get; set; }//Имя

    [Column(TypeName = "nvarchar(100)")]
    [Display(Name = "Фамилия")]
    public string LastName { get; set; }//Фамилия

    public string Photo { get; set; }//Аватар

    [Display(Name = "Дата регистрации")]

    public DateTime DateCreation { get; set; } = DateTime.Now;
    [MaxLength(50)]
    public string Url { get; set; }//Ссылка

    public string CoverPath { get; set; } = "";//Путь до шапки
    public string Description { get; set; } = "";//Описание

    public string Direction { get; set; } = "";//Направление

    public ICollection<Post> Posts { get; set; }//Посты
    public ICollection<Subscription> Subscriptions { get; set; }

    public ApplicationUser()
    {
        Posts = new List<Post>();
        Subscriptions = new List<Subscription>();
    }
}


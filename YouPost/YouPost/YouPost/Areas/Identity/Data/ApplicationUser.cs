using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace YouPost.Areas.Identity.Data;


public class ApplicationUser : IdentityUser<Guid>
{
    
    
    [Column(TypeName = "nvarchar(100)")]
    [Display(Name = "Имя")]
    public string FirstName { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    [Display(Name = "Фамилия")]
    public string LastName { get; set; }

    public string Photo { get; set; }

    [Display(Name = "Дата регистрации")]

    public DateTime DateCreation { get; set; } = DateTime.Now;
    [MaxLength(50)]
    public string Url { get; set; }
   
}


using YouPost.Areas.Identity.Data;

namespace YouPost.Models
{
    public class Subscription
    {
        public Guid Id { get;set; }
        public string Name { get;set; }
        public DateTime CreatedDate { get;set; } = DateTime.Now;
        public ICollection<ApplicationUser> Users { get; set; }
        public Subscription()
        {
            Users = new List<ApplicationUser>();
        }
        
    }
}

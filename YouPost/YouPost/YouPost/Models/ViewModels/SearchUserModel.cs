using YouPost.Areas.Identity.Data;

namespace YouPost.Models.ViewModels
{
    public class SearchUserModel
    {
        public string UserName { get; set; }
        public string PhotoPath {get;set;}

        public void ToModel(ApplicationUser user)
        {
            UserName = user.UserName;
            PhotoPath = user.Photo;
        }
    }
}

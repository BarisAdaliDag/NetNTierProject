using Project.Entities.Enums;

namespace Project.WebApi.Models.ResponseModels.AppUser
{
    public class AppUserResponseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DataStatus Status { get; set; }
        
    }
}

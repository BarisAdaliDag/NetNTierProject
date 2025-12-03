using Project.Entities.Enums;

namespace Project.WebApi.Models.ResponseModels.AppUserProfile
{
    public class AppUserProfileResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DataStatus Status { get; set; }
    }
}

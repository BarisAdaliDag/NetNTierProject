namespace Project.WebApi.Models.RequestModels.AppUser
{
    public class UpdateAppUserRequestModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

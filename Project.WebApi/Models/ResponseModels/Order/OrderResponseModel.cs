using Project.Entities.Enums;


namespace Project.WebApi.Models.ResponseModels.Order
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
        public DataStatus Status { get; set; }
    }
}
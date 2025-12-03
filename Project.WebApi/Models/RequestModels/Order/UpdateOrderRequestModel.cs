namespace Project.WebApi.Models.RequestModels.Order
{
    public class UpdateOrderRequestModel
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}



namespace Project.WebApi.Models.RequestModels.Order
{
    public class CreateOrderRequestModel
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}



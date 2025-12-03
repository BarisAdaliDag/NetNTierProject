using Project.Entities.Enums;

// RESPONSE MODELS
namespace Project.WebApi.Models.ResponseModels.OrderDetail
{
    public class OrderDetailResponseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DataStatus Status { get; set; }
    }
}

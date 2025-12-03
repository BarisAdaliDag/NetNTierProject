using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.WebApi.Models.RequestModels.OrderDetail;
using Project.WebApi.Models.ResponseModels.OrderDetail;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager _orderDetailManager;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailManager orderDetailManager, IMapper mapper)
        {
            _orderDetailManager = orderDetailManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailsList()
        {
            List<OrderDetailDto> values = await _orderDetailManager.GetAllAsync();
            List<OrderDetailResponseModel> responseModel = _mapper.Map<List<OrderDetailResponseModel>>(values);
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailRequestModel model)
        {
            OrderDetailDto orderDetail = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.CreateAsync(orderDetail);
            return Ok("Veri ekleme başarılıdır");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailRequestModel model)
        {
            OrderDetailDto orderDetail = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.UpdateAsync(orderDetail);
            return Ok("Veri güncelleme başarılıdır");
        }
        //TODO :FIX later PUT AND DELETE
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PacifyOrderDetail([FromRoute] int id)
        //{
        //    string message = await _orderDetailManager.SoftDeleteAsync(id);
        //    return Ok(message);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrderDetail([FromRoute] int id)
        //{
        //    string message = await _orderDetailManager.HardDeleteAsync(id);
        //    return Ok(message);
        //}
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.WebApi.Models.RequestModels.Order;
using Project.WebApi.Models.RequestModels.OrderDetail;
using Project.WebApi.Models.ResponseModels.Order;
using Project.WebApi.Models.ResponseModels.OrderDetail;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public OrderController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrdersList()
        {
            List<OrderDto> values = await _orderManager.GetAllAsync();
            List<OrderResponseModel> responseModel = _mapper.Map<List<OrderResponseModel>>(values);
            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            OrderDto value = await _orderManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestModel model)
        {
            OrderDto order = _mapper.Map<OrderDto>(model);
            await _orderManager.CreateAsync(order);
            return Ok("Veri ekleme başarılıdır");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequestModel model)
        {
            OrderDto order = _mapper.Map<OrderDto>(model);
            await _orderManager.UpdateAsync(order);
            return Ok("Veri güncelleme başarılıdır");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyOrder(int id)
        {
            string mesaj = await _orderManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            string mesaj = await _orderManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}


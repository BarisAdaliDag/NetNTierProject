using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.WebApi.Models.RequestModels.AppUser;
using Project.WebApi.Models.ResponseModels.AppUser;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserManager appUserManager, IMapper mapper)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<AppUserDto> values = await _appUserManager.GetAllAsync();
            List<AppUserResponseModel> response = _mapper.Map<List<AppUserResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            AppUserDto value = await _appUserManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserRequestModel model)
        {
            AppUserDto user = _mapper.Map<AppUserDto>(model);
            await _appUserManager.CreateAsync(user);
            return Ok("Kullanıcı eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateAppUserRequestModel model)
        {
            AppUserDto user = _mapper.Map<AppUserDto>(model);
            await _appUserManager.UpdateAsync(user);
            return Ok("Kullanıcı güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            string mesaj = await _appUserManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> HardDeleteUser(int id)
        {
            string mesaj = await _appUserManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemindX.Application.Abstractions.Services;
using RemindX.Application.Repositories.Remind;
using RemindX.Domain.Entities;

namespace RemindX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindController : ControllerBase
    {
        private readonly IRemindWriteRepository _remindWriteRepository;
        private readonly IRemindReadRepository _remindReadRepository;
        public RemindController(IRemindWriteRepository remindWriteRepository, IRemindReadRepository remindReadRepository)
        {
            _remindWriteRepository = remindWriteRepository;
            _remindReadRepository = remindReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRemind()
        {

            return Ok(_remindReadRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreateRemind(Remind model)
        {
            _remindWriteRepository.AddAsync(model);
            _remindWriteRepository.SaveChangeAsync();

            return Ok();
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(Remind model)
        {
            Remind data = await _remindReadRepository.GetByIdAsync(model.Id);
            _remindWriteRepository.Update(model);
            _remindWriteRepository.SaveChangeAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _remindWriteRepository.RemoveAsync(id);
            return Ok();
        }

    }
}

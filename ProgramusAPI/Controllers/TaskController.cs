using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramusAPI.Core;
using ProgramusAPI.Data;
using ProgramusAPI.Models;

namespace ProgramusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Tasks.All());
        }

        [HttpGet]
        [Route(template:"GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _unitOfWork.Tasks.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody]Tasks tasks)
        {
            await _unitOfWork.Tasks.Add(tasks);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _unitOfWork.Tasks.GetById(id);

            if (task == null) return NotFound();
            await _unitOfWork.Tasks.Delete(task);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPut]       
        public async Task<IActionResult> UpdateTask( Tasks tasks)
        {
            var task = await _unitOfWork.Tasks.GetById(tasks.Id);

            if (task == null) return NotFound();

            task.Title = tasks.Title;
            task.Description = tasks.Description;
            task.DueDate = tasks.DueDate;

            await _unitOfWork.Tasks.Update(task);
            await _unitOfWork.CompleteAsync();
            return Ok(task);
        }
    }
}

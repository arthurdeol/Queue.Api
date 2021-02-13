using System;
using API.Biennale.Queue.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Biennale.Queue.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _queryService;
        public QueueController(IQueueService queueService)
        {
            _queryService = queueService;
        }

        [HttpPost("enqueue")]
        public ActionResult Enqueue(int id)
        {
            try
            {
                _queryService.Enqueue(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("dequeue")]
        public ActionResult<int> Dequeue()
        {
            try
            {
               return _queryService.Dequeue();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("peek")]
        public ActionResult<int> Peek()
        {
            try
            {
              return _queryService.Peek();
            }
            catch(Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }
        [HttpDelete("clear")]
        public ActionResult Clear()
        {
            try
            {
                _queryService.Clear();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
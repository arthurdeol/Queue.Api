using System;
using System.Collections.Generic;
using System.Linq;
using API.Biennale.Queue.Api.Interfaces;
using Biennale.Queue.Api;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("dequeue")]
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
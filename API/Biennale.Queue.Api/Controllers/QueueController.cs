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

        [HttpGet("enqueue")]
        public ActionResult Enqueue(int id)
        {
            _queryService.Enqueue(id);
            return Ok();
        }
        [HttpGet("dequeue")]
        public ActionResult<int> Dequeue()
        {
            return _queryService.Dequeue();
        }
        [HttpGet("peek")]
        public ActionResult<int> Peek()
        {
            return _queryService.Peek();
        }
        [HttpGet("clear")]
        public ActionResult Clear()
        {
            _queryService.Clear();
            return Ok();
        }
    }
}
using API.Biennale.Queue.Api.Services;
using System;
using Xunit;

namespace Queue.Tests
{
    public class QueueTest
    {
        [Fact]
        public void TestPeek()
        {
            var _queryService = new QueueService();
            _queryService.Clear();
            _queryService.Enqueue(1);
            var id = _queryService.Peek();
            Assert.Equal(1, id);
        }
        [Fact]
        public void TestEnqueue()
        {
            var _queryService = new QueueService();
            _queryService.Clear();
            _queryService.Enqueue(1);
            var id = _queryService.Peek();
            Assert.NotEqual(2, id);
        }
         [Fact]
        public void TestDequeue()
        {
            var _queryService = new QueueService();
            _queryService.Clear();
            _queryService.Enqueue(1);
            _queryService.Enqueue(2);
            var idNotSame = _queryService.Dequeue();
            var id = _queryService.Peek();
            Assert.NotEqual(idNotSame, id);
        }

        [Fact]
        public void TestClearThenEnqueue()
        {
            var _queryService = new QueueService();
            _queryService.Clear();
            _queryService.Enqueue(1);
            _queryService.Enqueue(2);
            _queryService.Enqueue(44);
            _queryService.Clear();
            _queryService.Enqueue(22);
            var id = _queryService.Peek();
            Assert.NotEqual(1, id);
        }
        [Fact]
        public void TestPeekAfterDequeue()
        {
            var _queryService = new QueueService();
            _queryService.Clear();
            _queryService.Enqueue(1);
            _queryService.Enqueue(347);
            var dequeueId = _queryService.Dequeue();
            var id = _queryService.Peek();
            Assert.Equal(347, id);
        }
        [Fact]
         public void TestDequeueAfterPeek()
        {
            var _queryService = new QueueService();
            _queryService.Clear();
            _queryService.Enqueue(111);
            _queryService.Enqueue(34);
            var peekId = _queryService.Peek();
            var dequeueId = _queryService.Dequeue();
            Assert.Equal(dequeueId, peekId);
        }
    }
}

namespace API.Biennale.Queue.Api.Interfaces
{
    public interface IQueueService
    {
        void Enqueue(int id);
        int Dequeue();
        int Peek();
        void Clear();
    }
}
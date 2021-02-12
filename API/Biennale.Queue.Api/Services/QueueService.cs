using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using API.Biennale.Queue.Api.Interfaces;

namespace API.Biennale.Queue.Api.Services
{
    public class QueueService : IQueueService
    {
        public QueueService()
        {
        }

        public void Enqueue(int id)
        {
            var queue = ReadFile();
            queue.Enqueue(id);
            WriteFile(queue);
        }
        public int Dequeue()
        {
            var queue = ReadFile();
            var id = queue.Dequeue();
            WriteFile(queue);
            return id;
        }
        public int Peek()
        {
            var queue = ReadFile();
            var id = queue.Peek();
            return id;
        }
        public void Clear()
        {
            var queue = new Queue<int>();
            WriteFile(queue);
        }

        private Queue<int> ReadFile()
        {
            var readQueue = File.ReadAllText("queue.txt");
            var sliceQueue = StringToIntList(readQueue);
            var queue = new Queue<int>();
            foreach (var id in sliceQueue)
            {
                queue.Enqueue(id);
            }
            return queue;
        }

        private void WriteFile(Queue<int> queue)
        {
            var numbers = new StringBuilder("");
            foreach(int id in queue)
            {
                numbers.Append(id.ToString());
                numbers.Append(",");
            }
            using (StreamWriter file = new StreamWriter("queue.txt"))
            {
                file.WriteLine(numbers);
            }
        }

        public static IEnumerable<int> StringToIntList(string str) 
        {
            if (String.IsNullOrEmpty(str))
                 yield break;

            foreach(var s in str.Split(',')) {
                int num;
                if (int.TryParse(s, out num))
                    yield return num;
            }
        }
    }
}
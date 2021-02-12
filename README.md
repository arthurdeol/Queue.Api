# queue.api
#Simple .NET Core swagger API that will expose a simple queue system

#/api/queue/enqueue?id= <-- Enqueue adds an integer to the end of the queue 
#/api/queue/dequeue <-- Dequeue removes the oldest integer from the start of the queue and returns it 
#/api/queue/peek <-- peek returns the oldest integer that is at the start of the queue but does not remove it from the queue 
#/api/queue/clear <-- Clears the queue
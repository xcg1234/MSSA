namespace Assignments6_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // demonstrate the use of the CallQueue class
            CallQueue callQueue = new CallQueue();
            callQueue.Enqueue(new Customer("Alice", "555-1234"));
            callQueue.Enqueue(new Customer("Bob", "555-5678"));
            Console.WriteLine("Adding Alice and Bob to the call queue, now the Queue has:");
            callQueue.PrintQueue();
            Console.WriteLine("======================");
            Console.WriteLine("Dequeueing the next customer...");
            Customer nextCustomer = callQueue.Dequeue();
            Console.WriteLine("Now displaying the current remaining customer:");
            callQueue.PrintQueue();
        }
    }
}

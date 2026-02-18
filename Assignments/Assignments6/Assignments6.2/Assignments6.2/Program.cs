namespace Assignments6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //do demosntrating the stack class I wrote
            Console.WriteLine("Creating a stack of size 5...");
            MyStack stack = new MyStack(5);
            Console.WriteLine("Pushing values 1, 2, 3 onto the stack...");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Peeking top value: " + stack.Peek());
            Console.WriteLine("Popping top value: " + stack.Pop());
            Console.WriteLine("Peeking top value after pop: " + stack.Peek());
        }
    }
}

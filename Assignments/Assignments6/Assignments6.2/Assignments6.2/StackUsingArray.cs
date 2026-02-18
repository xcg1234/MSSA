namespace Assignments6._2
{
    public class MyStack
    {
        private int[] stackArray;
        private int top;

        public MyStack(int size)
        {
            stackArray = new int[size];
            top = -1;
        }
        public void Push(int value)
        {
            if (top < stackArray.Length - 1)
            {
                top++;
                stackArray[top] = value;
            }
            else
            {
                Console.WriteLine("Stack overflow!");
            }
        }
        public int Peek()
        {
            if (top >= 0)
            {
                return stackArray[top];
            }
            else
            {
                Console.WriteLine("Stack is empty!");
                return -1; // Return -1 to indicate stack is empty
            }
        }
        public int Pop()
        {
            if (top >= 0)
            {
                int value = stackArray[top];
                top--;
                return value;
            }
            else
            {
                Console.WriteLine("Stack is empty!");
                return -1; // Return -1 to indicate stack is empty
            }
        }


    }
}

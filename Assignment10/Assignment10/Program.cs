namespace Assignment10
{
    using System;

    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public class StackUsingLinkedList
    {
        private Node top;

        public StackUsingLinkedList()
        {
            top = null;
        }


        public void Push(int data)
        {
            Node newNode = new Node(data);
            newNode.next = top; 
            top = newNode;       
            Console.WriteLine($"{data} pushed onto stack.");
        }


        public int Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty. Nothing to pop.");
                return -1;
            }

            int poppedData = top.data;
            top = top.next;  
            Console.WriteLine($"{poppedData} popped from stack.");
            return poppedData;
        }


        public void Display()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            Console.Write("Stack elements (top to bottom): ");
            Node temp = top;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        public int Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty. No top element.");
                return -1;
            }
            Console.WriteLine($"Top element: {top.data}");
            return top.data;
        }
    }

    class Program
    {
        static void Main()
        {
            StackUsingLinkedList stack = new StackUsingLinkedList();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Display();

            stack.Peek();

            stack.Pop();
            stack.Display();

            stack.Pop();
            stack.Pop();

            stack.Pop();
        }
    }

}

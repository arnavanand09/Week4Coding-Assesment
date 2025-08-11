using System;
namespace Assignment6;
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

public class QueueUsingLinkedList
{
    private Node front;
    private Node rear;

    public QueueUsingLinkedList()
    {
        front = null;
        rear = null;
    }

    public void Insert(int data)
    {
        Node newNode = new Node(data);

        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.next = newNode;
            rear = newNode;
        }
        Console.WriteLine($"{data} inserted into queue.");
    }

    public int Delete()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty. Nothing to delete.");
            return -1;
        }

        int deletedData = front.data;
        front = front.next;

        if (front == null)
        {
            rear = null;
        }

        Console.WriteLine($"{deletedData} deleted from queue.");
        return deletedData;
    }


    public void Display()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Node temp = front;
        Console.Write("Queue elements: ");
        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }


    public int PeekFront()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty. No front element.");
            return -1;
        }
        Console.WriteLine($"Front element: {front.data}");
        return front.data;
    }

    public int PeekRear()
    {
        if (rear == null)
        {
            Console.WriteLine("Queue is empty. No rear element.");
            return -1;
        }
        Console.WriteLine($"Rear element: {rear.data}");
        return rear.data;
    }
}

class Program
{
    static void Main()
    {
        QueueUsingLinkedList queue = new QueueUsingLinkedList();

        queue.Insert(10);
        queue.Insert(20);
        queue.Insert(30);

        queue.Display();

        queue.PeekFront();
        queue.PeekRear();

        queue.Delete();
        queue.Display();

        queue.Delete();
        queue.Delete();
        queue.Delete(); 
    }
}

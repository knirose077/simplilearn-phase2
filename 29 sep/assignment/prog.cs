using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aug_29_assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinearQueue Q = new LinearQueue(5);

            Q.insert(10);
            Q.insert(20);
            Q.insert(30);
            Q.insert(40);
            Q.insert(50);

            Console.WriteLine("Items are : ");
            Q.printQueue();

            Q.delete();
            Q.delete();

            Console.WriteLine("Items are : ");
            Q.printQueue();
        }
    }
    class LinearQueue
    {
        private int[] ele;
        private int front;
        private int rear;
        private int max;

        public LinearQueue(int size)
        {
            ele = new int[size];
            front = 0;
            rear = -1;
            max = size;
        }

        public void insert(int item)
        {
            if (rear == max - 1)
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            else
            {
                ele[++rear] = item;
            }
        }

        public int delete()
        {
            if (front == rear + 1)
            {
                Console.WriteLine("Queue is Empty");
                return -1;
            }
            else
            {
                Console.WriteLine("deleted element is: " + ele[front]);
                return ele[front++];
            }
        }

        public void printQueue()
        {
            if (front == rear + 1)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            else
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine("Item[" + (i + 1) + "]: " + ele[i]);
                }
            }
        }

    }
}

using System;

namespace Queue
{
    public class Queue
    {
        public Node Head { get; private set; }
        Node tail;
        int maxLength;
        public int Count { get; private set; }

        public void EnQueue(Node node)
        {
            if(Count==0)
            {
                Head = node;
                tail = node;
                Head.Next = tail;
                tail.Next = Head;
            }
            else if (Count == maxLength)
            {
                throw new Exception("мест нет");
            }
            else
            {
                tail.Next = node;
                tail = node;
                tail.Next = Head;
            }
            Count++;
        }

        public Node Step()
        {
            Head.Time--;
            if (Head.Time == 0)
            {
                Head = Head.Next;
                tail.Next = Head;
                Count--;
                return Head;
            }
            return null;
        }

        public void Clear()
        {
            Head = null;
            tail = null;
            Count = 0;
        }

        public Queue(int max)
        {
            maxLength = max;
        }
    }
}
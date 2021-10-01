using System;

namespace Queue
{
    public class Node
    {
        public string Data { get; set; }
        public int Time { get; set; }
        public Node Next { get; set; }
        public Node(string data, int time)
        {
            if (data.Length == 4)
            {
                Data = data;
                Time = time;
                Next = null;
            }
            else
            {
                throw new IndexOutOfRangeException("Не из 4");
            }
        }
    }
}

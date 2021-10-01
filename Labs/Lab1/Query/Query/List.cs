namespace Queue
{
    public class ListOur
    {
        public Node Head { get; private set; }
        Node tail;

        public void Add(Node node)
        {
            if (Head == null)
            {
                Head = node;
                tail = Head;
            }
            else 
            {
                tail.Next = node;
                tail = node;
            }
        }

        public Node Step()
        {
            Head.Time--;
            if (Head.Time == 0)
            {
                Head = Head.Next;
                return Head;
            }
            return null;
        }

        public void Clear()
        {
            Head = null;
            tail = null;
        }
    }
}

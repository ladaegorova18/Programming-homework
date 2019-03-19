namespace Lists
{
    /// <summary>
    /// List - a structure to collect data
    /// </summary>
    public class List
    {
        protected class Node
        {
            public string Value { get; set; } = "";
            public Node Next { get; set; } = null;
            public Node(string value)
            {
                Value = value;
            }
        }

        public int Count() => size;

        public bool IsEmpty() => size == 0;

        public virtual bool Add(string data)
        {
            var newElement = new Node(data);
            if (IsEmpty())
            {
                head = newElement;
                tail = newElement;
            }
            else 
            {
                tail.Next = newElement;
                tail = newElement;
            }
            ++size;
            return true;
        }

        public virtual bool Remove(string data)
        {
            if (IsEmpty() || !IsValue(data)) return false;
            --size;
            if (data == head.Value)
            {
                head = head.Next;
                return true;
            }
            var temp = head;
            Node prev = null;
            while (temp != null)
            {
                prev = temp;
                temp = temp.Next;
                if (data == temp.Value)
                {
                    if (temp == tail)
                    {
                        prev.Next = null;
                        tail = prev;
                        return true;
                    }
                    prev.Next = temp.Next;
                    return true;
                }
            }
            return true;
        }

        public bool IsValue(string data)
        {
            var temp = head;
            while (temp != null)
            {
                if (temp.Value == data) return true;
                temp = temp.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        protected int size = 0;
        protected Node head = null;
        protected Node tail = null;
    }
}



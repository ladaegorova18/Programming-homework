namespace Lists
{
    /// <summary>
    /// List - a structure to collect data
    /// </summary>
    public class List
    {
        public int Size { get; set; }
        protected Node Head { get; set; }
        protected Node Tail { get; set; }

        /// <summary>
        /// Element in list
        /// </summary>
        public class Node
        {
            public string Value { get; set; }
            public Node Next { get; set; }
            public Node(string value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns> true, if size = 0 </returns>
        public bool IsEmpty() => Size == 0;

        /// <summary>
        /// Adds data to list
        /// </summary>
        /// <param name="data"> Data to add </param>
        /// <returns> If adding was successful </returns>
        public virtual bool Add(string data)
        {
            var newElement = new Node(data);
            if (IsEmpty())
            {
                Head = newElement;
                Tail = newElement;
            }
            else 
            {
                Tail.Next = newElement;
                Tail = newElement;
            }
            ++Size;
            return true;
        }

        /// <summary>
        /// Removes data from list
        /// </summary>
        /// <param name="data"> What to remove </param>
        /// <returns> If removing was successful </returns>
        public virtual bool Remove(string data)
        {
            if (IsEmpty() || !IsValue(data))
            {
                return false;
            }
            --Size;
            if (data == Head.Value)
            {
                Head = Head.Next;
                return true;
            }
            var temp = Head;
            Node prev = null;
            while (temp != null)
            {
                prev = temp;
                temp = temp.Next;
                if (data == temp.Value)
                {
                    if (temp == Tail)
                    {
                        prev.Next = null;
                        Tail = prev;
                        return true;
                    }
                    prev.Next = temp.Next;
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if this data is in list
        /// </summary>
        /// <param name="data"> data to find </param>
        /// <returns> true, if data is in list </returns>
        public bool IsValue(string data)
        {
            var temp = Head;
            while (temp != null)
            {
                if (temp.Value == data)
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }
    }
}



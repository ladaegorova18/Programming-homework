namespace Lists
{
    /// <summary>
    /// List - a structure to collect data
    /// </summary>
    public class List
    {
        private int size;
        private Node head;
        private Node tail;

        /// <summary>
        /// Element in list
        /// </summary>
        private class Node
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
        public bool IsEmpty() => size == 0;

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

        /// <summary>
        /// Checks if this data is in list
        /// </summary>
        /// <param name="data"> data to find </param>
        /// <returns> true, if data is in list </returns>
        public bool IsValue(string data)
        {
            var temp = head;
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
            head = null;
            tail = null;
            size = 0;
        }
    }
}



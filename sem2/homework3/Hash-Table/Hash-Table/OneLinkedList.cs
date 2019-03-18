namespace Hash_Table
{
    /// <summary>
    /// One linked list for Hash-Table
    /// </summary>
    class OneLinkedList
    {
        /// <summary>
        /// Element of list
        /// </summary>
        class Node
        {
            public string Value { get; set; } = "";
            public Node Next { get; set; }
            public Node(string value)
            {
                Value = value;
            }
        }

        private bool IsWrongPosition(int position, int size) => position < 0 || position > size;

        /// <summary>
        /// Counts size of list
        /// </summary>
        /// <returns> size of list</returns>
        public int Count() => size;

        /// <summary>
        /// checks if list is empty
        /// </summary>
        /// <returns> true, if list is empty</returns>
        public bool IsEmpty() => size == 0;

        /// <summary>
        /// Adds user's string from list
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> if adding was successful </returns>
        public bool Add(string data)
        {
            var newElement = new Node(data);
            if (!IsEmpty())
            {
                Node temp = head;
                while (temp != null)
                {
                    if (temp.Value == data) return true;
                    temp = temp.Next;
                }
                tail.Next = newElement;
                tail = newElement;
            }
            else
            {
                head = newElement;
                tail = newElement;
            }
            ++size;
            return true;
        }

        /// <summary>
        /// Removes input string from list
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> if deleting was successful </returns>
        public bool Remove(string data)
        {
            if (IsEmpty()) return false;
            --size;
            if (data == head.Value)
            {
                if (IsEmpty())
                {
                    DeleteList();
                    return true;
                }
                head = head.Next;
                return true;
            }
            else
            {
                var temp = head;
                Node prev = null;
                while (temp != null && temp.Value != data)
                {
                    prev = temp;
                    temp = temp.Next;
                }
                if (temp == tail)
                {
                    if (temp.Value != data)
                    {
                        return false;
                    }
                    prev.Next = null;
                    tail = prev;
                    return true;
                }
                if (temp == null) return true;
                prev.Next = temp.Next;
            }
            return true;
        }

        /// <summary>
        /// Checks if data is in list
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> true if the string is in list</returns>
        public bool Find(string data)
        {
            if (size == 0)
            {
                return false;
            }
            var temp = head;
            while (temp.Value != data)
            {
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
                else
                {
                    break;
                }
            }
            if (temp.Value != data)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Deletes all data from list by making head and tail null
        /// </summary>
        public void DeleteList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        private int size = 0;
        private Node head;
        private Node tail;
    }
}



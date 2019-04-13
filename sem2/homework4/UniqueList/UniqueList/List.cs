namespace Lists
{
    /// <summary>
    /// List - a structure to collect data
    /// </summary>
    public class List
    {
        private Node head;
        private Node tail;

        /// <summary>
        /// Amount elments in list
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Element in list
        /// </summary>
        protected class Node
        {
            public string Value { get; set; }
            public Node Next { get; set; }
            public Node(string value)
            {
                Value = value;
            }
        }

        protected bool WrongPosition(int position, int size) => position < 0 || position > Size || Size == 0;

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
        public virtual bool Add(string data, int position)
        {
            if (position < 0 || position > Size)
            {
                return false;
            }
            var newElement = new Node(data);
            if (Size == 0)
            {
                head = newElement;
                tail = newElement;
            }
            else if (position == 0)
            {
                newElement.Next = head;
                head = newElement;
            }
            else if (position == Size)
            {
                tail.Next = newElement;
                tail = newElement;
            }
            else
            {
                var temp = head;
                Node prev = null;
                for (int i = 0; i < position; ++i)
                {
                    prev = temp;
                    temp = temp.Next;
                }
                prev.Next = newElement;
                newElement.Next = temp;
            }
            ++Size;
            return true;
        }


        /// <summary>
        /// Removes data from list
        /// </summary>
        /// <param name="position"> Position of deleting element </param>
        /// <returns> if removing was successful </returns>
        public virtual bool Remove(int position)
        {
            if (WrongPosition(position, Size) || IsEmpty() || position == Size)
            {
                return false;
            }
            --Size;
            if (position == 0)
            {
                head = head.Next;
                return true;
            }
            var temp = head;
            Node prev = null;
            for (int i = 0; i < position; ++i)
            {
                prev = temp;
                temp = temp.Next;
            }
            if (temp == tail)
            {
                prev.Next = null;
                tail = prev;
                return true;
            }
            prev.Next = temp.Next;
            return true;
        }

        private Node GetNode(int position)
        {
            var temp = head;
            for (int i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }
            return temp;
        }

        /// <summary>
        /// Sets value on position
        /// </summary>
        /// <param name="value"> value to set </param>
        /// <param name="position"> position of changing element </param>
        /// <returns></returns>
        public virtual bool SetValue(string value, int position)
        {
            if (WrongPosition(position, Size))
            {
                return false;
            }
            var temp = GetNode(position);
            temp.Value = value;
            return true;
        }

        /// <summary>
        /// Gets value from the position
        /// </summary>
        /// <param name="position"> position to take value </param>
        /// <returns> value from the position </returns>
        public string GetValue(int position)
        {
            if (WrongPosition(position, Size))
            {
                return "";
            }
            var temp = GetNode(position);
            return temp.Value;
        }

        /// <summary>
        /// Checks if value is in list
        /// </summary>
        /// <param name="data"> data to check </param>
        /// <returns> id value is in list </returns>
        public bool Exists(string data)
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

        /// <summary>
        /// Deletes all data from list
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            Size = 0;
        }
    }
}



using static System.Math;

namespace HashTable
{
    /// <summary>
    /// One linked list for Hash-Table
    /// </summary>
    public class OneLinkedList
    {
        /// <summary>
        /// Element of list
        /// </summary>
        private class Node
        {
            public string Value { get; set; } = "";
            public Node Next { get; set; }
            public Node(string value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Adds data from hash table to new array
        /// </summary>
        /// <param name="newArray"> array to add </param>
        public void AddToNewArray(OneLinkedList[] newArray, IHash hashfunction)
        {
            var temp = Head;
            while (temp != null)
            {
                int hashCode = Abs(hashfunction.CountHash(temp.Value) % newArray.Length);
                newArray[hashCode].Add(temp.Value);
                temp = temp.Next;
            }
        }

        /// <summary>
        /// checks if list is empty
        /// </summary>
        /// <returns> true, if list is empty</returns>
        public bool IsEmpty() => Size == 0;

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
                Node temp = Head;
                while (temp != null)
                {
                    if (temp.Value == data)
                    {
                        return true;
                    }
                    temp = temp.Next;
                }
                Tail.Next = newElement;
                Tail = newElement;
            }
            else
            {
                Head = newElement;
                Tail = newElement;
            }
            ++Size;
            return true;
        }

        /// <summary>
        /// Removes input string from list
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> success of deleting </returns>
        public bool Remove(string data)
        {
            if (IsEmpty())
            {
                return false;
            }
            --Size;
            if (data == Head.Value)
            {
                if (IsEmpty())
                {
                    DeleteList();
                    return true;
                }
                Head = Head.Next;
                return true;
            }
            else
            {
                var temp = Head;
                Node prev = null;
                while (temp != null && temp.Value != data)
                {
                    prev = temp;
                    temp = temp.Next;
                }
                if (temp == Tail)
                {
                    if (temp.Value != data)
                    {
                        return false;
                    }
                    prev.Next = null;
                    Tail = prev;
                    return true;
                }
                if (temp == null)
                {
                    return true;
                }
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
            if (Size == 0)
            {
                return false;
            }
            var temp = Head;
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
            Head = null;
            Tail = null;
            Size = 0;
        }

        /// <summary>
        /// amount of elements in list
        /// </summary>
        public int Size { get; set; } = 0;

        private Node Head { get; set; }
        private Node Tail { get; set; }
    }
}



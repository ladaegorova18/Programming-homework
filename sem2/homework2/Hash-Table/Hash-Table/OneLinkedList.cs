using static System.Math;

namespace HashTable
{
    public class OneLinkedList
    {
        private class Node
        {
            public string Value { get; set; } = "";
            public Node Next { get; set; }
            public Node(string value)
            {
                Value = value;
            }
        }

        public int Count() => Size;

        public bool IsEmpty() => Size == 0;

        public bool Add(string data)
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

        public bool Remove(string data)
        {
            --Size;
            if (data == Head.Value && Size == 0)
            {
                Head = null;
                Tail = null;
                return true;
            }
            var temp = Head;
            Node prev = null;
            while (temp.Value != data || temp.Next != null)
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
            prev.Next = temp.Next;
            return true;
        }

        public bool Exists(string data)
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
            return (temp.Value == data);
        }

        public void ClearList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public void AddToNewArray(OneLinkedList[] newArray)
        {
            var temp = Head;
            while (temp != null)
            {
                int hashCode = Abs(temp.Value.GetHashCode() % newArray.Length);
                newArray[hashCode].Add(temp.Value);
                temp = temp.Next;
            }
        }

        private int Size { get; set; } = 0;
        private Node Head { get; set; }
        private Node Tail { get; set; }
    }
}



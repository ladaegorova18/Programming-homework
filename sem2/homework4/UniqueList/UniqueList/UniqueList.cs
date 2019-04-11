namespace Lists
{
    /// <summary>
    /// List consising of unrepeating elements
    /// </summary>
    public class UniqueList : List
    {
        private Node head;
        private Node tail;
        private int size;

        /// <summary>
        /// Constructor of UniqueList
        /// </summary>
        public UniqueList()
        {
        }

        public UniqueList(List list)
        {
            if (!list.IsEmpty())
            {
                CopyData(list);
                DeleteRepeating();
            }
        }

        private void CopyData(List list)
        {
            var tempInList = list.Head.Next;
            Head = new Node(list.Head.Value);
            var tempInUniqueList = Head;
            ++Size;
            while(tempInList != null)
            {
                var toCopy = new Node(tempInList.Value);
                tempInUniqueList.Next = toCopy;
                tempInUniqueList = tempInUniqueList.Next;
                if (tempInList.Next == null)
                {
                    Tail = toCopy;
                }
                tempInList = tempInList.Next;
                ++Size;
            }
        }

        private void DeleteRepeating()
        {
            var tempBase = Head;
            while (tempBase != null)
            {
                var temp = tempBase;
                var prev = tempBase;
                while (temp != null)
                {
                    if ((temp.Value == tempBase.Value) && (temp != tempBase))
                    {
                        prev.Next = temp.Next;
                        temp = prev;
                        --Size;
                    }
                    prev = temp;
                    temp = temp.Next;
                }
                tempBase = tempBase.Next;
            }
        }

        /// <summary>
        /// Override adding in UniqueList throws exception if list already contains an element
        /// </summary>
        /// <param name="data"> data to add </param>
        /// <returns> if adding was successful </returns>
        public override bool Add(string data)
        {
            if (IsValue(data))
            {
                throw new AddingExistingNodeException("Этот элемент уже есть в списке!");
            }
            base.Add(data);
            return true;
        }

        /// <summary>
        /// Override removing in list throws an exception when you try to remove nonexisting element
        /// </summary>
        /// <param name="data"> data to remove </param>
        /// <returns> if removing was successful </returns>
        public override bool Remove(string data)
        {
            if (!IsValue(data))
            {
                throw new RemovingNonexistentNodeException("Этого значения не было в списке!");
            }
            base.Remove(data);
            return true;
        }
    }
}

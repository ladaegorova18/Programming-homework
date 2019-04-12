namespace Lists
{
    /// <summary>
    /// List consising of unrepeating elements
    /// </summary>
    public class UniqueList : List
    {
        private Node head = null;
        private Node tail = null;

        /// <summary>
        /// Amount elments in list
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Override adding in UniqueList throws exception if list already contains an element
        /// </summary>
        /// <param name="data"> data to add </param>
        /// <returns> if adding was successful </returns>
        public override bool Add(string data, int position)
        {
            if (Exists(data))
            {
                throw new AddingExistingNodeException("Этот элемент уже есть в списке!");
            }
            base.Add(data, position);
            return true;
        }

        /// <summary>
        /// Override removing in list throws an exception when you try to remove nonexisting element
        /// </summary>
        /// <param name="data"> data to remove </param>
        /// <returns> if removing was successful </returns>
        public override bool Remove(int position)
        {
            if (WrongPosition(position, Size))
            {
                throw new RemovingNonexistentNodeException("Этого значения не было в списке!");
            }
            base.Remove(position);
            return true;
        }

        /// <summary>
        /// If value already is in list, unique list throws an exception
        /// </summary>
        public override bool SetValue(string value, int position)
        {
            if (Exists(value))
            {
                throw new AddingExistingNodeException("Это значение уже есть в списке!");
            }
            return base.SetValue(value, position);
        }

        private bool Exists(string data)
        {
            var temp = head;
            while (temp != null)
            {
                if (temp.Value == data) return true;
                temp = temp.Next;
            }
            return false;
        }
    }
}

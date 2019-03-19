namespace Lists
{
    public class UniqueList : List
    {
        public UniqueList()
        {
            if (IsEmpty()) DeleteRepeating();
        }

        private void DeleteRepeating()
        {
            var tempBase = head;
            for (int i = 0; i < Count() - 1; ++i)
            {
                Node prev = null;
                var temp = tempBase;
                for (int j = i + 1; j < Count(); )
                {
                    prev = temp;
                    temp = temp.Next;
                    if (temp.Value == tempBase.Value)
                    {
                        prev.Next = temp.Next;
                        --size;
                    }
                    else ++j;
                }
                tempBase = tempBase.Next;
            }
        }

        public override bool Add(string data)
        {
            try
            {
                if (IsValue(data))
                {
                    throw new AddingExistingNodeException("Этот элемент уже есть в списке!");
                }
                base.Add(data);
                return true;
            }
            catch (AddingExistingNodeException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return true;
        }

        public override bool Remove(string data)
        {
            try
            {
                if (!IsValue(data))
                {
                    throw new RemovingNonexistentNodeException("Этого значения не было в списке!");
                }
                base.Remove(data);
            }
            catch (RemovingNonexistentNodeException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return true;
        }
    }
}

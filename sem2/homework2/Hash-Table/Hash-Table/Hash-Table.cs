using System;
using static System.Math;

namespace Hash_Table
{
    class Hash_Table
    {
        private const int MAX = 100;
        private OneLinkedList[] array = new OneLinkedList[MAX];

        public Hash_Table()
        {
            for (int i = 0; i < MAX; ++i)
            {
                array[i] = new OneLinkedList();
            }
        }

        private int CountHash(string data)
        {
            return Abs(data.GetHashCode() % 100);
        }

        public void AddData(string data)
        {
            int hashCode = CountHash(data);
            array[hashCode].Add(data);
        }

        public bool RemoveData(string data)
        {
            int hashCode = CountHash(data);
            return array[hashCode].Remove(data);
        }

        public bool IsData(string data)
        {
            int hashCode = CountHash(data);
            return array[hashCode].Find(data);
        }

        public void DeleteTable()
        {
            for (int i = 0; i < MAX; ++i)
            {
                array[i].DeleteList();
            }
        }
    }
}

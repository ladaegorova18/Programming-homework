using System;
using static System.Math;

namespace HashTable
{
    public class HashTable
    {
        public HashTable()
        {
            array = new OneLinkedList[Max];
            InitializeArray(array);
        }

        private void InitializeArray(OneLinkedList[] array)
        {
            for (int i = 0; i < Max; ++i)
            {
                array[i] = new OneLinkedList();
            }
        }

        private int CountHash(string data) => Abs(data.GetHashCode() % Max);

        public void AddData(string data)
        {
            int hashCode = CountHash(data);
            array[hashCode].Add(data);
            if (FillFactor() > critical)
            {
                Rehash();
            }
        }

        private void Rehash()
        {
            Max *= 2;
            var newArray = new OneLinkedList[Max];
            InitializeArray(newArray);
            foreach (var cell in array)
            {
                AddToNewArray(cell, newArray);
            }
            array = newArray;
        }

        private void AddToNewArray(OneLinkedList list, OneLinkedList[] newArray)
        {
            var temp = list.Head;
            while (temp != null)
            {
                int hashCode = CountHash(temp.Value);
                newArray[hashCode].Add(temp.Value);
                temp = temp.Next;
            }
        }

        public bool RemoveData(string data)
        {
            int hashCode = CountHash(data);
            return array[hashCode].Remove(data);
        }

        public bool IsData(string data)
        {
            int hashCode = CountHash(data);
            return array[hashCode].Exists(data);
        }

        public void ClearTable()
        {
            for (int i = 0; i < Max; ++i)
            {
                array[i].ClearList();
            }
        }

        private float FillFactor() => GetSize() / Max;

        public int GetSize()
        {
            var size = 0;
            foreach (var cell in array)
            {
                size += cell.Count();
            }
            return size;
        }

        private int Max = 100;
        private const int critical = 10;
        private OneLinkedList[] array;
    }
}

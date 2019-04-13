using static System.Math;

namespace HashTable
{
    public class Table
    {
        private int max = 100;
        private const int critical = 10;
        private OneLinkedList[] array;

        public Table()
        {
            array = new OneLinkedList[max];
            InitializeArray(array);
        }

        private void InitializeArray(OneLinkedList[] array)
        {
            for (int i = 0; i < max; ++i)
            {
                array[i] = new OneLinkedList();
            }
        }

        private int CountHash(string data) => Abs(data.GetHashCode() % max);

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
            max *= 2;
            var newArray = new OneLinkedList[max];
            InitializeArray(newArray);
            foreach (var cell in array)
            {
                cell.AddToNewArray(newArray);
            }
            array = newArray;
        }

        public bool RemoveData(string data)
        {
            int hashCode = CountHash(data);
            return array[hashCode].Remove(data);
        }

        public bool Exists(string data)
        {
            int hashCode = CountHash(data);
            return array[hashCode].Exists(data);
        }

        public void ClearTable()
        {
            for (int i = 0; i < max; ++i)
            {
                array[i].ClearList();
            }
        }

        private float FillFactor() => GetSize() / max;

        public int GetSize()
        {
            var size = 0;
            foreach (var cell in array)
            {
                size += cell.Count();
            }
            return size;
        }
    }
}

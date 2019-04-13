using System;
using System.IO;
using static System.Math;

namespace HashTable
{
    /// <summary>
    /// Hash-Table to collect text data
    /// </summary>
    public class Table
    {

        private int size = 100;
        private const int critical = 10;
        private OneLinkedList[] array;
        private IHash hashFunction;

        /// <summary>
        /// Constructor which gives the table hash function that user has chosen
        /// and creates a linked list for every cell in array
        /// </summary>
        /// <param name="hashFunction"> hash function from main program</param>
        public Table(IHash hashFunction)
        {
            array = new OneLinkedList[size];
            this.hashFunction = hashFunction;
            InitializeArray(array);
        }

        private void InitializeArray(OneLinkedList[] array)
        {
            for (int i = 0; i < size; ++i)
            {
                array[i] = new OneLinkedList();
            }
        }

        private int GetHash(string data) => hashFunction.CountHash(data);

        private float FillFactor() => GetSize() / size;

        public int GetSize()
        {
            var size = 0;
            foreach (var cell in array)
            {
                size += cell.Size;
            }
            return size;
        }

        /// <summary>
        /// Adds data to table
        /// </summary>
        /// <param name="data"> input string </param>
        public void AddData(string data)
        {
            int hashCode = Abs(hashFunction.CountHash(data) % size);
            array[hashCode].Add(data);
            if (FillFactor() > critical)
            {
                Rehash();
            }
        }

        private void Rehash()
        {
            size *= 2;
            var newArray = new OneLinkedList[size];
            InitializeArray(newArray);
            foreach (var cell in array)
            {
                cell.AddToNewArray(newArray, hashFunction);
            }
            array = newArray;
        }

        /// <summary>
        /// Removes data from table
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> if removing was successful </returns>
        public bool RemoveData(string data)
        {
            int hashCode = GetHash(data) % size;
            return array[hashCode].Remove(data);
        }

        /// <summary>
        /// Checks if data is in table
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> true, if it is </returns>
        public bool Exists(string data)
        {
            int hashCode = GetHash(data) % size;
            return array[hashCode].Find(data);
        }

        /// <summary>
        /// Deleting all information from table
        /// </summary>
        public void ClearTable()
        {
            for (int i = 0; i < size; ++i)
            {
                array[i].DeleteList();
            }
        }

        /// <summary>
        /// Reading text for table from file
        /// </summary>
        /// <param name="filePath"> Path to the file </param>
        public void FillingTheTable(string filePath)
        {
            try
            {
                using var stream = new StreamReader(filePath);
                while (stream.Peek() >= 0)
                {
                    var str = stream.ReadLine();
                    string[] words = str.Split();
                    foreach (string word in words)
                    {
                        AddData(word);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
                return;
            }
        }
    }
}

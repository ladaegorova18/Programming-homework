using System.IO;

namespace Hash_Table
{
    /// <summary>
    /// Hash-Table to collect text data
    /// </summary>
    public class Hash_Table
    {
        /// <summary>
        /// Constructor which gives the table hash function that user has chosen
        /// and creates a linked list for every cell in array
        /// </summary>
        /// <param name="hashFunction"> hash function from main program</param>
        public Hash_Table(IHash hashFunction)
        {
            this.hashFunction = hashFunction;
            for (int i = 0; i < SIZE; ++i)
            {
                array[i] = new OneLinkedList();
            }
        }

        private int GetHash(string data) => hashFunction.CountHash(data);

        /// <summary>
        /// Adds data to table
        /// </summary>
        /// <param name="data"> input string </param>
        public void AddData(string data)
        {
            int hashCode = GetHash(data);
            array[hashCode].Add(data);
        }

        /// <summary>
        /// Removes data from table
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> if removing was successful </returns>
        public bool RemoveData(string data)
        {
            int hashCode = GetHash(data);
            return array[hashCode].Remove(data);
        }

        /// <summary>
        /// Checks if data is in table
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> true, if it is </returns>
        public bool IsData(string data)
        {
            int hashCode = GetHash(data);
            return array[hashCode].Find(data);
        }

        /// <summary>
        /// Deleting all information from table
        /// </summary>
        public void ClearTable()
        {
            for (int i = 0; i < SIZE; ++i)
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
            using var stream = new StreamReader(filePath);
            {
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
        }

        private const int SIZE = 100;
        private OneLinkedList[] array = new OneLinkedList[SIZE];
        private IHash hashFunction;
    }
}

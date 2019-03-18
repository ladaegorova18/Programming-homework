using static System.Math;

namespace Hash_Table
{
    /// <summary>
    /// Hash-Function which uses multiplication by prime number
    /// </summary>
    public class HashFunctionByMultiplication : IHash
    {
        /// <summary>
        /// Function multiplies every symbol from string by 31 and adds them all 
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> hash code </returns>
        public int CountHash(string data)
        {
            int hash = 0;
            foreach (char symbol in data)
            {
                hash += symbol * 31; // 31 - простое число, примерно равное длине русского алфавита
            } // поэтому оно должно хорошо работать с нашей хеш-функцией
            return Abs(hash % 100);
        }
    }
}

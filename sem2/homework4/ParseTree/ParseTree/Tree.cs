using System;
using System.IO;

namespace ParseTree
{
    /// <summary>
    /// Parse tree to count ariphmetical expressions
    /// </summary>
    public class Tree
    {
        private void Add(char value)
        {
            if (IsEmpty())
            {
                if (Char.IsDigit(value))
                {
                    root = new Operand(value);
                    return;
                }
                else if (IsOperation(value))
                {
                    root = new Operation(value);
                    current = (Operation)root;
                    return;
                }
            }
            else
            {
                current = root.AddChild(value, current);
            }
        }

        /// <summary>
        /// Reads expression fron file
        /// </summary>
        /// <param name="filePath"> path to file </param>
        public void ReadFromFile(string filePath)
        {
            using var stream = new StreamReader(filePath);
            var str = stream.ReadLine();
            AddString(str);
            stream.Close();
        }

        /// <summary>
        /// Adds expression to tree
        /// </summary>
        /// <param name="str"> expression to add </param>
        public void AddString(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                Add(str[i]);
            }
        }

        /// <summary>
        /// Cleans tree by making the root null
        /// </summary>
        public void Clean()
        {
            root = null;
        }

        /// <summary>
        /// Checks if this char is ariphmetic operation of division, multiplication,
        /// addition or subtraction
        /// </summary>
        /// <param name="value"> symbol to check </param>
        /// <returns> true or false </returns>
        private bool IsOperation(char value) => value == '/' || value == '*'
            || value == '+' || value == '-';

        /// <summary>
        /// Counts ariphmetic expression from root
        /// </summary>
        /// <returns> integer number: result </returns>
        public int Count() => root.Count();

        private bool IsEmpty() => root == null;

        public Operation current { get; set; }

        private INode root;
    }
}

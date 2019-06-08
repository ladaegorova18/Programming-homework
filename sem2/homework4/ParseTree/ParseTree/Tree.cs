using System;
using System.IO;

namespace ParseTree
{
    /// <summary>
    /// Parse tree to count ariphmetical expressions
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// root of tree - node on the top
        /// </summary>
        private INode root;

        /// <summary>
        /// current node
        /// </summary>
        public Operation Current { get; set; }

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
                    Current = (Operation)root;
                    return;
                }
            }
            else
            {
                Current = root.AddChild(value, Current);
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
            foreach (var ch in str)
            {
                Add(ch);
            }
        }

        /// <summary>
        /// Cleans tree by making the root null
        /// </summary>
        public void Clean() => root = null;

        /// <summary>
        /// Checks if current char is ariphmetic operation of division, multiplication,
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

        /// <summary>
        /// checks if tree is empty
        /// </summary>
        private bool IsEmpty() => root == null;

        /// <summary>
        /// prints whole tree on console
        /// </summary>
        public void Print() => root.Print(Tabulation, 0);

        private static void Tabulation(int level)
        {
            for (var i = 0; i < level; ++i)
            {
                Console.Write("\t");
            }
        }
    }
}

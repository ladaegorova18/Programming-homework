﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    /// <summary>
    /// main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method; unnecessary here, though
        /// </summary>
        public static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(3);
            list.Add(8);
            list.Add(7);
            foreach (var node in list)
            {
                Console.Write(node + " ");
            }
        }
    }
}

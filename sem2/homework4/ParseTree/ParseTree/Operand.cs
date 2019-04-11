﻿using System;

namespace ParseTree
{
    /// <summary>
    /// Integer number as part of expression
    /// </summary>
    public class Operand : INode
    {
        public Operand(char value)
        {
            Value = value;
        }

        /// <summary>
        /// Count value here means to return its value
        /// </summary>
        /// <returns> number itself </returns>
        public int Count() => Value - '0';

        public int Value { get; set; }

        /// <summary>
        /// Operand as node of tree can not have children
        /// </summary>
        public Operation AddChild(char symbol, Operation current)
        {
            throw new NotImplementedException();
        }
    }
}
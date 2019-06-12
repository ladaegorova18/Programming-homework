using System;

namespace ParseTree
{
    /// <summary>
    /// Node of tree: operand or operation
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Counts result of ariphmetic expression
        /// </summary>
        /// <returns> integer number: result </returns>
        int Count();

        /// <summary>
        /// Adds symbol to parse tree
        /// </summary>
        /// <param name="value"> symbol to add </param>
        /// <param name="current"> parent node of tree </param>
        /// <returns> current node to add next symbols </returns>
        Operation AddChild(char value, Operation current);

        /// <summary>
        /// Prints tree on console
        /// </summary>
        void Print(Action<int> tabulation, int level);
    }
}

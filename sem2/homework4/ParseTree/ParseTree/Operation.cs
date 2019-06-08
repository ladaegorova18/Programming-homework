using System;

namespace ParseTree
{
    /// <summary>
    /// node with ariphmetic operation
    /// </summary>
    public class Operation : INode
    {
        /// <summary>
        /// operation in node
        /// </summary>
        public char AriphmeticOperation { get; set; }

        /// <summary>
        /// left child of node
        /// </summary>
        public INode LeftChild { get; set; }

        /// <summary>
        /// right child of node
        /// </summary>
        public INode RightChild { get; set; }
        private INode parent;

        /// <summary>
        /// Constructor for Operation
        /// </summary>
        /// <param name="symbol"> symbol of operation </param>
        public Operation(char symbol) => AriphmeticOperation = symbol;

        /// <summary>
        /// Counts value of this node by its children
        /// </summary>
        /// <returns> integer result </returns>
        public int Count()
        {
            LeftChild.Count();
            if (RightChild != null)
            {
                RightChild.Count();
            }
            return DoOperation(LeftChild, RightChild);
        }

        private int DoOperation(INode leftChild, INode rightChild)
        {
            if (leftChild == null || rightChild == null)
            {
                if (leftChild is Operand && AriphmeticOperation == '-')
                {
                    return -leftChild.Count();
                }
                throw new ArgumentException("Похоже, выражение в файле некорректно :(");
            }
            return AriphmeticOperation switch
            {
                '+' => leftChild.Count() + rightChild.Count(),
                '-' => leftChild.Count() - rightChild.Count(),
                '*' => leftChild.Count() * rightChild.Count(),
                '/' => leftChild.Count() / rightChild.Count(),
            };
        }

        /// <summary>
        /// Adds new node to tree
        /// </summary>
        /// <param name="symbol"> symbol as value of new node </param>
        /// <param name="current"> current node will be parent of new </param>
        /// <returns> new current node </returns>
        public Operation AddChild(char symbol, Operation current)
        {
            if (symbol == ')')
            {
                current = (Operation)current.parent;
                return current;
            }
            else if (IsOperation(symbol))
            {
                var child = new Operation(symbol);
                child.parent = current;
                if (current.LeftChild == null)
                {
                    current.LeftChild = child;
                    current = (Operation)current.LeftChild;
                }
                else if (current.RightChild == null)
                {
                    current.RightChild = child;
                    current = (Operation)current.RightChild;
                }
            }
            else if (char.IsDigit(symbol))
            {
                var child = new Operand(symbol);
                if (current.LeftChild == null)
                {
                    current.LeftChild = child;
                }
                else if (current.RightChild == null)
                {
                    current.RightChild = child;
                }
            }
            return current;
        }

        private bool IsOperation(char value) => value == '/' || value == '*'
            || value == '+' || value == '-';

        /// <summary>
        /// prints operation on console
        /// </summary>
        public void Print(Action<int> tabulation, int level)
        {
            if (this != null)
            {
                {
                    Operation temp = this;
                    LeftChild.Print(tabulation, level + 1);
                    tabulation(level);
                    Console.WriteLine(temp.AriphmeticOperation);
                    RightChild.Print(tabulation, level + 1);
                }
            }
        }
    }
}

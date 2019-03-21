using System;

namespace ParseTree
{
    public class Operation : INode
    {
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
            if (leftChild is Operation)
            {
                leftChild.Count();
            }
            if (rightChild is Operation)
            {
                rightChild.Count();
            }
            return DoOperation(leftChild, rightChild);
        }

        private int DoOperation(INode leftChild, INode rightChild)
        {
            if (leftChild == null || rightChild == null)
            {
                if (leftChild is Operand && AriphmeticOperation == '-') return (-1) * leftChild.Count();
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
                if (current.leftChild == null)
                {
                    current.leftChild = child;
                    current = (Operation)current.leftChild;
                }
                else if (current.rightChild == null)
                {
                    current.rightChild = child;
                    current = (Operation)current.rightChild;
                }
            }
            else if (char.IsDigit(symbol))
            {
                var child = new Operand(symbol);
                if (current.leftChild == null)
                {
                    current.leftChild = child;
                }
                else if (current.rightChild == null)
                {
                    current.rightChild = child;
                }
            }
            return current;
        }

        private bool IsOperation(char value) => value == '/' || value == '*'
            || value == '+' || value == '-';

        private char AriphmeticOperation { get; set; }
        private INode leftChild;
        private INode rightChild;
        private INode parent;
    }
}

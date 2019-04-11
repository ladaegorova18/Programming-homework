using System;

namespace ParseTree
{
    public class Operation : INode
    {
        public char AriphmeticOperation { get; set; }
        public INode leftChild { get; set; }
        public INode rightChild { get; set; }
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
            leftChild.Count();
            if (rightChild != null)
            {
                rightChild.Count();
            }
            return DoOperation(leftChild, rightChild);
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

        public void Printing(INode current, int level)
        {
            if (current != null)
            {
                Tabulation(level);
                if (current is Operand)
                {
                    Console.WriteLine(current.Count());
                }
                else
                {
                    Operation temp = (Operation)current;
                    Printing(temp.leftChild, level + 1);
                    Tabulation(level);
                    Console.WriteLine(temp.AriphmeticOperation);
                    Printing(temp.rightChild, level + 1);
                }
            }
        }

        private static void Tabulation(int level)
        {
            for (var i = 0; i < level; ++i)
            {
                Console.Write("\t");
            }
        }
    }
}

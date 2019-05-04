using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    /// <summary>
    /// Queue first in - first out with priorities
    /// </summary>
    public class PriorityQueue
    {
        private Node head;

        public int Size { get; private set; } = 0;

        private class Node
        {
            public Node(int value, int priority)
            {
                Value = value;
                Priority = priority;
            }

            public Node Next { get; set; }
            public int Value { get; set; }
            public int Priority { get; set; }
        }

        /// <summary>
        /// Enqueue - adding to queue
        /// </summary>
        /// <param name="newValue"> value to add </param>
        /// <param name="priority"> priority of adding </param>
        public void Enqueue(int newValue, int priority)
        {
            var data = new Node(newValue, priority);
            ++Size;
            if (IsEmpty())
            {
                head = data;
                data.Next = null;
                return;
            }
            Node previous = null;
            var current = head;
            while (current != null)
            {
                if (current.Priority < priority)
                {
                    data.Next = current;
                    if (previous != null)
                    {
                        previous.Next = data;
                    }
                    else
                    {
                        head = data;
                    }
                    return;
                }
                if (current.Next == null)
                {
                    current.Next = data;
                    data.Next = null;
                    return;
                }
                previous = current;
                current = current.Next;
            }
            previous.Next = data;
        }

        /// <summary>
        /// Dequeue - deleting first node from queue
        /// </summary>
        /// <returns> value of deleted node </returns>
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new EmptyQueueException("Очередь пуста!");
            }
            --Size;
            int result = head.Value;
            head = head.Next;
            return result;
        }

        /// <summary>
        /// Checks if queue is empty
        /// </summary>
        /// <returns> true if queue is empty </returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Deletes all values from queue
        /// </summary>
        public void DeleteQueue()
        {
            head = null;
            Size = 0;
        }
    }
}

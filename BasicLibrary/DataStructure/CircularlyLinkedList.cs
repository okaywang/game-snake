using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.DataStructure
{
    public class CircularlyLinkedList<T>
    {
        private DoubleLinkedNode<T>[] _nodes;
        private int _currentIndex;
        public CircularlyLinkedList(T t1, T t2, T t3)
        {
            _nodes = new DoubleLinkedNode<T>[3];
            _nodes[0] = new DoubleLinkedNode<T>(t1);
            _nodes[1] = new DoubleLinkedNode<T>(t2);
            _nodes[2] = new DoubleLinkedNode<T>(t3);

            _nodes[0].Next = _nodes[1];
            _nodes[1].Next = _nodes[2];
            _nodes[2].Next = _nodes[0];
        }

        public DoubleLinkedNode<T> Current
        {
            get { return _nodes[_currentIndex]; }
        }

        public void MoveNext()
        {
            _currentIndex = ++_currentIndex % 3;
        }

        public void MovePrevious()
        {
            _currentIndex = --_currentIndex % 3;
        }
    }

    public class DoubleLinkedNode<T>
    {
        private T _t;
        private DoubleLinkedNode<T> _previous;
        private DoubleLinkedNode<T> _next;
        public DoubleLinkedNode(T t)
        {
            _t = t;
        }
        public DoubleLinkedNode<T> Previous
        {
            get { return _previous; }
            private set { _previous = value; }
        }
        public T Value { get { return _t; } }
        public DoubleLinkedNode<T> Next
        {
            get { return _next; }
            set
            {
                value.Previous = this;
                _next = value;
            }
        }
    }
}

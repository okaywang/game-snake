using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.DataStructure
{
    public class CircularlyLinkedList<T>
    {
        private CircularlyLinkedNode<T>[] _nodes;
        private int _currentIndex;
        public CircularlyLinkedList(T t1, T t2, T t3)
        {
            _nodes = new CircularlyLinkedNode<T>[3];
            _nodes[0] = new CircularlyLinkedNode<T>(t1);
            _nodes[1] = new CircularlyLinkedNode<T>(t2);
            _nodes[2] = new CircularlyLinkedNode<T>(t3);

            _nodes[0].Next = _nodes[1];
            _nodes[1].Next = _nodes[2];
            _nodes[2].Next = _nodes[0];
        }

        public CircularlyLinkedNode<T> Current
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

    public class CircularlyLinkedNode<T>
    {
        private T _t;
        private CircularlyLinkedNode<T> _previous;
        private CircularlyLinkedNode<T> _next;
        public CircularlyLinkedNode(T t)
        {
            _t = t;
        }
        public CircularlyLinkedNode<T> Previous
        {
            get { return _previous; }
            private set { _previous = value; }
        }
        public T Value { get { return _t; } }
        public CircularlyLinkedNode<T> Next
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.DataStructure
{
    public class CircularlyLinkedList<T>
    {
        private DoubleLinkedNode<T> _node1, _node2, _node3;
        public CircularlyLinkedList(T t1, T t2, T t3)
        {
            _node1 = new DoubleLinkedNode<T>(t1);
        }
    }

    public class DoubleLinkedNode<T>
    {
        private T _t;
        public DoubleLinkedNode(T t)
        {
            _t = t;
        }
        public T Previous { get; set; }
        public T Value { get; set; }
        public T Next { get; set; }
    }
}

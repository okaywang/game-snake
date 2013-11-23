using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class SnakeBody
    {
        private Snake _owner;
        private LinkedList<Segment> _segments;
        public SnakeBody(LinkedList<Segment> segments)
        { 
            _segments = segments;
        }

        public void SetOwner(Snake owner)
        {
            _owner = owner;
        }

        public List<Segment> Segments
        {
            get
            {
                return _segments.ToList().GetRange(0, _segments.Count - 1);
            }
        }

        public void AddSegment()
        {
            var head = _segments.Last;
            var newSegment = head.Value.Clone() as Segment;
            _segments.AddBefore(head, newSegment);
        }

        public void Creep(OrientationInterpreter orientation)
        {
            var node = _segments.First;

            while (node.Next != null)
            {
                node.Value.Poisition = node.Next.Value.Poisition;
                node = node.Next;
            }
        }

        public bool IsCover(Coordinate pos)
        {
            return this.Segments.Any(s => s.Poisition == pos);
        }
    }
}

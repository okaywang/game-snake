using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfGreedySnake
{
    public class Snake : ISnake, IMoveable
    {
        private List<Segment> _segments;
        public Snake(List<Segment> segments)
        {
            _segments = segments;
        }

        public List<Segment> Segments
        {
            get { return _segments; }
        }

        public void Move(Direction direction)
        {
            for (int i = 0; i < _segments.Count-1; i++)
            {
                _segments[i].Poisition = _segments[i + 1].Poisition;
            }
            _segments.Last().Move(direction);
        }

        public void Eat(Food food)
        {
            var seg = new Segment();
            seg.Poisition = food.Position;
            _segments.Insert(0, seg);
        }

        public void Crash()
        {
            throw new NotImplementedException();
        }
    }
}

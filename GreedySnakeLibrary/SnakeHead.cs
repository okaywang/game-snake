using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class SnakeHead
    {
        private Snake _owner;
        private Segment _segment;
        public SnakeHead(Segment segment)
        {
            _segment = segment;
        }

        public void SetOwner(Snake owner)
        {
            _owner = owner;
        }

        public Segment Segment
        {
            get { return _segment; }
        }

        public void Creep(OrientationInterpreter orientation)
        {
            _segment.Creep(orientation);
            var isPosOccupied = _owner.Body.Segments.Any(s => s.Poisition == _segment.Poisition);
            if (isPosOccupied)
            {
                throw new SelfCrashedException("crashed oneself");
            }
        }
    }
}

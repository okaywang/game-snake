using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class Snake 
    {
        private SnakeHead _head;
        private SnakeBody _body;

        public Snake(SnakeHead head, SnakeBody body)
        {
            _head = head;
            _body = body;

            _head.SetOwner(this);
            _body.SetOwner(this);
        }

        public SnakeHead Head
        {
            get { return _head; }
        }

        public SnakeBody Body
        {
            get { return _body; }
        }

        public void Creep(OrientationInterpreter orientation, bool growth)
        {
            if (growth)
            {
                _body.AddSegment();
            }
            else
            {
                _body.Creep(orientation);
            }
            _head.Creep(orientation);
        }
    }
}

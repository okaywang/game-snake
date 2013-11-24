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
        private CommandOrientation _command;

        public Snake(SnakeHead head, SnakeBody body, CommandOrientation command)
        {
            _head = head;
            _body = body;
            _command = command;

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

        public CommandOrientation Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public bool IsCover(Coordinate pos)
        {
            return _head.IsCover(pos) || _body.IsCover(pos);
        }

        public void Creep(bool growth)
        {
            if (growth)
            {
                _body.AddSegment();
            }
            else
            {
                _body.Creep(_command);
            }
            _head.Creep(_command);
        }

        public Coordinate ImmediatePosition
        {
            get
            {
                var expectedPosition = _command.GetExpectedResult(_head.Segment.Poisition);
                return expectedPosition;
            }
        }
    }
}

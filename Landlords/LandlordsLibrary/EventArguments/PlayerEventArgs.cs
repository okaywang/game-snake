using BasicLibrary.DataStructure;
using LandlordsLibrary.Formation;
using LandlordsLibrary.Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary
{
    public class PlayerEventArgs : EventArgs
    {
        private CircularlyLinkedNode<IPlayer> _player;
        public PlayerEventArgs(CircularlyLinkedNode<IPlayer> player)
        {
            _player = player;
        }
        public CircularlyLinkedNode<IPlayer> Player
        {
            get { return _player; }
        }
    }

    public class PlayerTakeoutFormationEventArgs : EventArgs
    {
        private CircularlyLinkedNode<IPlayer> _player;
        private IFormation _formation;
        public PlayerTakeoutFormationEventArgs(CircularlyLinkedNode<IPlayer> player, IFormation formation)
        {
            _player = player;
            _formation = formation;
        }

        public CircularlyLinkedNode<IPlayer> Player
        {
            get { return _player; }
        }

        public IFormation Formation
        {
            get { return _formation; }
        }
    }
}

using LandlordsLibrary.Formation;
using LandlordsLibrary.Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.DataContext
{
    public class RoundInfo
    {
        private IPlayer _player;
        private IFormation _formation;
        public RoundInfo(IPlayer player, IFormation formation)
        {
            _player = player;
            _formation = formation;
        }
        public IPlayer Player
        {
            get { return _player; }
        }
        public IFormation Formation
        {
            get { return _formation; }
        }
    }

    public class RoundRecorder
    {
        private static Stack<RoundInfo> _rounds;
        static RoundRecorder()
        {
            _rounds = new Stack<RoundInfo>();
        }

        public static void Add(IPlayer player, IFormation formation)
        {
            var round = new RoundInfo(player, formation);
            Add(round);
        }

        public static void Add(RoundInfo round)
        {
            _rounds.Push(round);
        }

        public static RoundInfo ImmediateRound
        {
            get
            {
                return _rounds.Peek();
            }
        }
    }
}

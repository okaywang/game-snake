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
    public class GameViewEventArgs : EventArgs
    {
        private ILandlordsGameView _view;
        public GameViewEventArgs(ILandlordsGameView view)
        {
            _view = view;
        }
        public ILandlordsGameView View
        {
            get { return _view; }
        }
    }

    public class GameViewTakeoutFormationEventArgs : EventArgs
    {
        private ILandlordsGameView _view;
        private IFormation _formation;
        public GameViewTakeoutFormationEventArgs(ILandlordsGameView view, IFormation formation)
        {
            _view = view;
            _formation = formation;
        }

        public ILandlordsGameView View
        {
            get { return _view; }
        }

        public IFormation Formation
        {
            get { return _formation; }
        }
    }
}

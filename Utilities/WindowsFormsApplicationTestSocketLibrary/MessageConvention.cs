using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplicationTestSocketLibrary
{
    [Serializable]
    public class MessageConvention
    {
        public MessageType MsgType { get; set; }
        public Seat Seat { get; set; }
        public List<Seat> OccupiedSeats { get; set; }
    }

    [Serializable]
    public class Seat
    { 
        public int SeatNumber { get; set; }
        public string UserName { get; set; }
    }

    [Serializable]
    public enum MessageType
    {
        QueryOccupiedSeats,
        OccupySeat,
        Talk
    }
}

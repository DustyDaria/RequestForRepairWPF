using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data.Room
{
    public class Rooms_DataModel
    {
        public int id_room { get; set; }
        public int room_number { get; set; }
        public bool room_status { get; set; }
        public static List<int> AllRoomsNumber { get; set; } = new List<int>();
        public static List<int> AllLibertyRoomsNumber { get; set; } = new List<int>();
    }
}

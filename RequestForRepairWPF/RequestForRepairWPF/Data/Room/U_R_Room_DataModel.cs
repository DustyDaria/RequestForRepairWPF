using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data.Room
{
    public class U_R_Room_DataModel
    {
        /// <summary>
        /// Избавиться от static - каша
        /// </summary>

        public static int _userID { get; set; }
        public int userID { get; set; }

        public static int _idRoom { get; set; }
        public int idRoom { get; set; }

        public static int _idTypeRoom { get; set; }
        public int idTypeRoom { get; set; }

        public static List<int> _listAll_idRoom { get; set; } = new List<int>();
        public List<int> listAll_idRoom { get; set; } = new List<int>();

        /// <summary>
        /// Нахрена???
        /// </summary>
        public static List<int> _listUserRoomsNumber { get; set; } = new List<int>();
        public List<int> listUserRoomsNumber { get; set; } = new List<int>();


        /// связь к room 
        /// 

    }
}

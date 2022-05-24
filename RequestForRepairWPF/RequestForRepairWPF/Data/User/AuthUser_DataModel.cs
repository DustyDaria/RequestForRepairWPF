using RequestForRepairWPF.Data.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data.User
{
    public class AuthUser_DataModel
    {
        public static int _idUser { get; set; }

        public static int _idType { get; set; }
        public static string _typeOfAccount { get; set; }

        public static string _userLogin { get; set; }

        public static string _userPassword { get; set; }

        public static string _lastName { get; set; }

        public static string _name { get; set; }

        public static string _middleName { get; set; }

        public static string _position { get; set; }

        public static string _categoryExecutors { get; set; }

        public static string _phone { get; set; }

        public string FullName
        {
            get
            {
                return $"{ _lastName } { _name } { _middleName }";
            }
        }

        /// <summary>
        /// Связь с U_R_Room
        /// </summary>
        public static List<U_R_Room_DataModel> _U_R_Room_IdRooms { get; set; } = new List<U_R_Room_DataModel>();
    }
}

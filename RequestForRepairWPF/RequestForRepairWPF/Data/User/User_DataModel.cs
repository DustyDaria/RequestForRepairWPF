using System.Collections.Generic;

namespace RequestForRepairWPF.Data.User
{
    public class User_DataModel
    {
        /// избавиться от static, они здесь не нужны (каша)
        public static int _idUser { get; set; }
        public int idUser { get; set; }

        public static int _idType { get; set; }
        public int idType { get; set; }
        public string typeOfAccount { get; set; }

        public static string _userLogin { get; set; }
        public string userLogin { get; set; }

        public static string _userPassword { get; set; }
        public string userPassword { get; set; }

        public static string _lastName { get; set; }
        public string lastName { get; set; }

        public static string _name { get; set; }
        public string name { get; set; }

        public static string _middleName { get; set; }
        public string middleName { get; set; }

        public static string _position { get; set; }
        public string position { get; set; }

        public static string _categoryExecutors { get; set; }
        public string categoryExecutors { get; set; }

        public static string _phone { get; set; }
        public string phone { get; set; }

        public static List<string> AllCategoryExecutors { get; set; } = new List<string>();
        public static List<int> AllUsersID { get; set; } = new List<int>();

        //public List<int> ListUserIdRooms { get; set; } = new List<int>();
        public List<int> ListUserRooms { get; set; } = new List<int>();
        public List<int> ListUserActiveRequest { get; set; } = new List<int>();
        public List<string> ListUserActiveRequest_Name { get; set; } = new List<string>();
        public string PrimaryRequest { get; set; }
        public int PrimaryRoom { get; set; }
        public bool userSelect { get; set; }

        public string FullName
        {
            get
            {
                return $"{ lastName } { name } { middleName }";
            }
        }
    }
}

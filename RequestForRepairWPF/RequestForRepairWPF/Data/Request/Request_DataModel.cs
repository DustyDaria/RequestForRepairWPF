using RequestForRepairWPF.Data.User;
using System;
using System.Collections.Generic;

namespace RequestForRepairWPF.Data.Request
{
    public class Request_DataModel
    {
        public int id_request { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public string status_request { get; set; }
        public int room_number { get; set; }
        public string name_request { get; set; }
        public string description_request { get; set; }
        public string comment_request { get; set; }
        public string inventory_number { get; set; }
        public DateTime? actual_date_end { get; set; }
        public string category_request { get; set; }

        public string FullNameCustomer { get; set; }
        public string FullNameExecutor { get; set; }

        public static List<int> AllRequestID { get; set; } = new List<int>();
    }
}

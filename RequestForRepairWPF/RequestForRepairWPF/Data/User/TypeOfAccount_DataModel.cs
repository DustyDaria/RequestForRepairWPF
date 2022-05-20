using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data.User
{
    public class TypeOfAccount_DataModel
    {
        public int id_type { get; set; }
        public string name_type { get; set; }

        public static List<string> AllType { get; set; } = new List<string>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagement.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            { _ins = value; }
        }

        public LibraryManagementPteamEntities db { get; set; }
        public DataProvider()
        {
            db = new LibraryManagementPteamEntities();
        }
    }
}

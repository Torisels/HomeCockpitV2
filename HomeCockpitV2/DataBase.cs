using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCockpitV2
{
    class DataBase
    {
        public DataBase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }
    }
}

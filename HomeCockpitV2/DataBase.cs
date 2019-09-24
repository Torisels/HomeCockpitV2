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
        private SQLiteConnection connection;


        public DataBase()
        {
           connection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
           connection.Open();
        }

        public HashSet<BitRegisterPair> GetBitRegisterPairs()
        {
            var ret = new HashSet<BitRegisterPair>();
            string sqlcommand = "select mcu_id, mcu_reg, reg_bit from Pins";
            SQLiteCommand cmd = new SQLiteCommand(sqlcommand,connection);
            SQLiteDataReader reader= cmd.ExecuteReader();
            while (reader.Read())
            {
                ret.Add(new BitRegisterPair
                {
                    Register = (byte)McuRegisterToMasterBufferRegisterIndex((int)reader["mcu_id"],reader["mcu_reg"]),
                    Bit = Convert.ToByte(reader["reg_bit"])
                });
            }

            return ret;
        }

        public List<DataGridViewList> GetDataGridViewList()
        {
            var ret = new List<DataGridViewList>();
            string commandString = "select pin_id, mcu_id, mcu_reg, reg_bit from Pins";
            SQLiteCommand cmd = new SQLiteCommand(commandString, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ret.Add(new DataGridViewList
               {
                   Pin = Convert.ToString(reader["pin_id"]),
                   McuId = (Convert.ToString((int)reader["mcu_id"]+1)),
                   McuRegister = "P"+RegisterIdToLetter((int)reader["mcu_reg"])+Convert.ToString(reader["reg_bit"]),
                   MasterBufferRegisterIndex = Convert.ToString(McuRegisterToMasterBufferRegisterIndex((int)reader["mcu_id"], reader["mcu_reg"]))
                });
            }

            return ret;
        }

        public string RegisterIdToLetter(int id)
        {
            var ret = String.Empty;
            switch (id)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
            }
            return ret;
        }

        public int McuRegisterToMasterBufferRegisterIndex(object mcuId, object mcuRegister)
        {
            return Convert.ToInt32(4 * Convert.ToInt16(mcuId) + Convert.ToInt16(mcuRegister));
        }



    }

    class DataGridViewList
    {
        public string Pin { get; set; }
        public string McuId { get; set; }
        public string McuRegister { get; set; }
        public string MasterBufferRegisterIndex { get; set; }
    }

}

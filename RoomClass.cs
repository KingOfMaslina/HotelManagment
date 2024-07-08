using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace отель_администрирование
{
    internal class RoomClass
    {
        Class1 connect = new Class1();

        public DataTable getRoomType()
        {
            string selectQuery = "SELECT * FROM `category`";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        public bool InsertRoom(string id, int type, string phone, string status)
        {
            string InsertQuerry = "INSERT INTO `room`(`RoomId`, `RoomType`, `RoomPhone`, `RoomStatus`) VALUES (@id,@type,@phone,@status)";
            MySqlCommand command = new MySqlCommand(InsertQuerry, connect.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            
            connect.OpenCon();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseCon();
                return true;
            }
            else
            {
                connect.CloseCon();
                return false;
            }
        }
        public DataTable getRoomList()
        {
            string selectQuery = "SELECT * FROM `room`";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool EditRoom(string id, int type, string phone, string status)
        {
            string EditQuerry = "UPDATE `room` SET `RoomType`= @type,`RoomPhone`=@phone,`RoomStatus`= @status WHERE `RoomId`= @id";
            MySqlCommand command = new MySqlCommand(EditQuerry, connect.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

            connect.OpenCon();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseCon();
                return true;
            }
            else
            {
                connect.CloseCon();
                return false;
            }
        }

        public bool removeRoom(string id)
        {
            string insertQuerry = "DELETE FROM `room` WHERE `RoomId` = @id";
            MySqlCommand command = new MySqlCommand(insertQuerry, connect.GetConnection());
            //@id
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            connect.OpenCon();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseCon();
                return true;
            }
            else
            {
                connect.CloseCon();
                return false;
            }

        }
    }
}

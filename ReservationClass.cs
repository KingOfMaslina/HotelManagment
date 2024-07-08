using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace отель_администрирование
{
    internal class ReservationClass
    {
        Class1 connect = new Class1();

        public DataTable roomByType(int type)
        {
            string selectQuery = "SELECT * FROM `room` WHERE `RoomType` = @type AND `RoomStatus` = 'Свободна';";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
       
        public int typeByRoomNo(string rno)
        {
            string selectQuery = "SELECT `RoomType` FROM `room` WHERE `RoomId`=@rno";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            command.Parameters.Add("@rno", MySqlDbType.VarChar).Value = rno;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0].ToString());

        }
        public DataTable getReserv()
        {
            string selectQuery = "SELECT * FROM `reservation`";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool setReservRoom(string rno,string sts)
        {
            string UpdateQuerry = "UPDATE `room` SET `RoomStatus`=@sts WHERE `RoomId`=@rno";
            MySqlCommand command = new MySqlCommand(UpdateQuerry, connect.GetConnection());

            command.Parameters.Add("@rno",MySqlDbType.VarChar).Value = rno;
            command.Parameters.Add("@sts", MySqlDbType.VarChar).Value = sts;

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

        public bool addReserv(string guestId, string roomNo, DateTime dateIn, DateTime dateOut)
        {
            string insertQuerry = "INSERT INTO `reservation`(`GuestId`, `RoomNo`, `DateIn`, `DateOut`) VALUES (@Gid,@Rno,@Din,@Dout)";
            MySqlCommand command = new MySqlCommand(insertQuerry, connect.GetConnection());
            //@Gid,@Rno,@Din,@Dout

            command.Parameters.Add("@Gid", MySqlDbType.VarChar).Value = guestId;
            command.Parameters.Add("@Rno", MySqlDbType.VarChar).Value = roomNo;
            command.Parameters.Add("@Din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@Dout", MySqlDbType.Date).Value = dateOut;

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
        public bool removeReserv(int id)
        {
            string insertQuerry = "DELETE FROM `reservation` WHERE `ReservId`=@id";
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
        public bool editReserv(int ReservId, string guestId, string roomNo, DateTime dateIn, DateTime dateOut)
        {
            string insertQuerry = "UPDATE `reservation` SET `GuestId`=@Gid,`RoomNo`=@Rno,`DateIn`=@Din,`DateOut`=@Dout WHERE `ReservId`=@rid";
            MySqlCommand command = new MySqlCommand(insertQuerry, connect.GetConnection());
            //@rid@Gid,@Rno,@Din,@Dout
            command.Parameters.Add("@rid", MySqlDbType.Int32).Value = ReservId;
            command.Parameters.Add("@Gid", MySqlDbType.VarChar).Value = guestId;
            command.Parameters.Add("@Rno", MySqlDbType.VarChar).Value = roomNo;
            command.Parameters.Add("@Din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@Dout", MySqlDbType.Date).Value = dateOut;


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

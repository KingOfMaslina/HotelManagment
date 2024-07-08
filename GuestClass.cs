using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace отель_администрирование
{
    internal class GuestClass
    {
        Class1 connect = new Class1();
        public bool InsertGuest(string id,string fname, string lname, string phone, string comm,string comp)
        {
            string InsertQuerry = "INSERT INTO `guest`(`GuestId`, `GuestName`, `GuestLastName`, `GuestTel`, `GuestComm`,`GuestComp`) VALUES (@id,@fname,@lname,@ph,@comm,@comp)";
            MySqlCommand command = new MySqlCommand(InsertQuerry,connect.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@comm", MySqlDbType.VarChar).Value = comm;
            command.Parameters.Add("@comp", MySqlDbType.VarChar).Value = comp;

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

        public DataTable getGuest()
        {
            string selectQuery = "SELECT * FROM `guest`";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        public bool EditGuest(string id, string fname, string lname, string phone, string comm,string comp)
        {
            string EditQuerry = "UPDATE `guest` SET `GuestName`=@fname,`GuestLastName`=@lname,`GuestTel`=@ph,`GuestComm`=@comm,`GuestComp`=@comp WHERE `GuestId`=@id";
            MySqlCommand command = new MySqlCommand(EditQuerry, connect.GetConnection());


            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@comm", MySqlDbType.VarChar).Value = comm;
            command.Parameters.Add("@comp", MySqlDbType.VarChar).Value = comp;

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
        public bool removeGuest(string id)
        {
            string insertQuerry = "DELETE FROM `guest` WHERE `GuestId`=@id";
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

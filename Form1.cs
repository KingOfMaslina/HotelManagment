using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace отель_администрирование
{
    public partial class Form1 : Form
    {
        Class1 connect = new Class1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim().Equals("") || textBox4.Text == "")
            {
                MessageBox.Show("Введите пароль и логин", "Недостоющая информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string selectquery = "SELECT * FROM `users` WHERE `username` = @usn AND `password` = @pass";
                MySqlCommand command = new MySqlCommand(selectquery, connect.GetConnection());
                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBox3.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox4.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);


                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Такого логина/пароля не существует", "Неправильный логин или пароль", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private bool addUser(string User, string Pass)
        {
            string insertQuerry = "INSERT INTO `users`(`username`, `password`) VALUES (@usn,@pass)";
            MySqlCommand command = new MySqlCommand(insertQuerry, connect.GetConnection());
            //@Gid,@Rno,@Din,@Dout

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = User;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Pass;

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
        private void button4_Click(object sender, EventArgs e)
        {
            string User = textBox3.Text;
            string Pass= textBox4.Text;

            try
            {
                if (addUser(User,Pass))
                {
                    MessageBox.Show("Пользователь добавлен", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Пользователь не добавлен", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
